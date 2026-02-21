using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class TextClass
    {
        public static string Alpha = "abcdefghijklmnopqrstuvwxyz";

        private static readonly char[] SentenceDelimiters = ['.', '!', '?'];
        private static readonly char[] WordDelimiters = [' ', '\n', '\t', '\r'];

        /// <summary>
        /// Вычисляет количество символов, слов и предложений в указанном тексте.
        /// </summary>
        /// <remarks>
        /// Слова определяются путем разделения текста по пробельным символам, а предложения —
        /// по знакам '.', '!' или '?'. Количество символов основано на общей длине входной строки.
        /// </remarks>
        /// <param name="text">Входная строка для анализа. Не может быть null или пустой.</param>
        /// <returns>Кортеж, содержащий три целых числа: общее количество символов, общее количество слов и общее
        /// количество предложений во входном тексте.</returns>
        public static (int,int,int) Count(string text)
        {
            string cleanedText = text.Trim();
            string[] sentenceArray = cleanedText.Split(SentenceDelimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] wordArray = cleanedText.Split(WordDelimiters, StringSplitOptions.RemoveEmptyEntries);


            int chars = 0;
            int words = 0;
            int sentences = 0;

            chars = cleanedText.Length;
            words = wordArray.Length;
            sentences = sentenceArray.Length;
            
            return (chars, words, sentences);
        }

        /// <summary>
        /// Вычисляет частоту появления каждого символа в указанном тексте, исключая пробелы и символы переноса строки.
        /// </summary>
        /// <remarks>
        /// Метод удаляет пробелы, символы новой строки и табуляции перед подсчетом вхождений.
        /// Подсчет символов нечувствителен к регистру (в данной реализации все приводится к нижнему регистру).
        /// </remarks>
        /// <param name="text">Входная строка для анализа. Не может быть null или пустой.</param>
        /// <returns>Словарь, где каждый ключ — это символ (в виде строки), а каждое значение — количество раз, которое
        /// этот символ встречается во входном тексте.</returns>
        public static Dictionary<string, int> CharStats(string text) {
            Dictionary<string, int> dict = new();

            var cleanedText = text.Replace(" ", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");

            foreach (char c in cleanedText) {
                string key = c.ToString();
                key = key.ToLower();

                if (Alpha.Contains(key))
                {
                    if (dict.ContainsKey(key))
                        dict[key]++;
                    else
                        dict[key] = 1;
                }
            }

            return dict;
        }

        /// <summary>
        /// Генерирует изображение (Bitmap) со статической гистограммой, используя указанные размеры и данные.
        /// </summary>
        /// <remarks>
        /// Если словарь данных пуст, метод возвращает изображение с нулевой высотой столбцов.
        /// Максимальное значение в данных используется для масштабирования высоты столбцов. 
        /// Гистограмма использует фиксированный набор меток, определенных в массиве Alpha; 
        /// столбцы отрисовываются для каждой метки алфавита независимо от того, есть ли она в данных.
        /// </remarks>
        /// <param name="width">Ширина результирующего изображения в пикселях. Должна быть положительным целым числом.</param>
        /// <param name="height">Высота результирующего изображения в пикселях. Должна быть положительным целым числом.</param>
        /// <param name="data">Словарь, содержащий данные для представления на гистограмме, где каждый ключ — строковая метка,
        /// а каждое значение — целое число, представляющее значение соответствующего столбца. Не может быть null.</param>
        /// <returns>Объект Bitmap, содержащий отрисованное изображение гистограммы.</returns>
        public static Bitmap DrawStatic(int width, int height, Dictionary<string, int> data)
        {
            Bitmap bmp = new(width, height);

            using Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            float barWidth = (float)width / Alpha.Length;
            int maxValue = data.Count > 0 ? data.Values.Max() : 1;

            for (int i = 0; i < Alpha.Length; i++)
            {
                string key = Alpha[i].ToString();
                int value = data.ContainsKey(key) ? data[key] : 0;

                float barHeight = (float)value / maxValue * height;

                g.FillRectangle(Brushes.Blue, i * barWidth, height - barHeight, barWidth - 2, barHeight);
                g.DrawString(key, SystemFonts.DefaultFont, Brushes.Black, i * barWidth + barWidth / 2 - 5, height - 20);
            }

            return bmp;
        }
    }
}
