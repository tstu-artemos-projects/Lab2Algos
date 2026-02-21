using Lab2;
using System.Drawing;
using System.Windows.Forms;
using Xunit;

namespace Lab2.Tests
{
    public class TextClassTests
    {
        [Theory]
        [InlineData("Hello world!", 12, 2, 1)] // Текст, символы, слова, предложения
        [InlineData("One. Two? Three!", 16, 3, 3)]
        [InlineData("  Trim me  ", 7, 2, 1)]
        public void Count_ReturnsCorrectValues(string input, int expChars, int expWords, int expSentences)
        {
            // Act
            var (chars, words, sentences) = TextClass.Count(input);

            // Assert
            Assert.Equal(expChars, chars);
            Assert.Equal(expWords, words);
            Assert.Equal(expSentences, sentences);
        }

        [Fact]
        public void CharStats_FiltersNonAlphaAndCountsCorrectly()
        {
            // Arrange
            string input = "Aa123 !!! b"; // 2 'a', 1 'b', цифры и знаки игнорируются

            // Act
            var stats = TextClass.CharStats(input);

            // Assert
            Assert.Equal(2, stats["a"]);
            Assert.Equal(1, stats["b"]);
            Assert.False(stats.ContainsKey("1")); // Проверка, что цифры не попали
        }

        [Fact]
        public void Form_AnalizeClick_UpdatesLabels()
        {
            // Arrange
            var form = new TextForm();
            // Находим TextBox внутри формы (нужно убедиться, что модификатор доступа в дизайнере позволяет это, 
            // либо использовать Controls.Find)
            var input = (TextBox)form.Controls.Find("textAnalizeTextBox", true)[0];
            var charResult = (TextBox)form.Controls.Find("charCountTextBox", true)[0];
            var wordResult = (TextBox)form.Controls.Find("wordCountTextBox", true)[0];
            var sentenceResult = (TextBox)form.Controls.Find("sentenceCountTextBox", true)[0];

            input.Text = "Sample text.";

            // Act
            form.Analize(null, EventArgs.Empty);

            // Assert
            Assert.Equal("12", charResult.Text); // "Sample text." = 12 символов
            Assert.Equal("2", wordResult.Text); // "Sample" и "text."
            Assert.Equal("1", sentenceResult.Text); // "Sample text." - одно предложение
        }

        [Theory]
        [InlineData("Привет!!! Как дела??", 20, 3, 2)] // Несколько знаков препинания подряд
        [InlineData("Много   пробелов\nи\tтабуляций", 28, 4, 1)] // Разные типы пустот
        [InlineData("...!!!???", 9, 1, 0)] // Только знаки препинания (слов нет)
        public void Count_HandlesComplexFormatting(string input, int expChars, int expWords, int expSentences)
        {
            var (chars, words, sentences) = TextClass.Count(input);

            Assert.Equal(expChars, chars);
            Assert.Equal(expWords, words);
            Assert.Equal(expSentences, sentences);
        }

        [Fact]
        public void CharStats_IgnoresCyrillicAndSpecialSymbols()
        {
            // Arrange
            string input = "abc ФЫВА !@#";

            // Act
            var stats = TextClass.CharStats(input);

            // Assert
            Assert.True(stats.ContainsKey("a"));
            Assert.False(stats.ContainsKey("ф")); // Кириллицы нет в Alpha
            Assert.Equal(3, stats.Count); // Только a, b, c
        }

        [Fact]
        public void DrawStatic_ReturnsValidBitmap_EvenWithEmptyData()
        {
            // Arrange
            int w = 500, h = 300;
            var emptyData = new Dictionary<string, int>();

            // Act
            using var bmp = TextClass.DrawStatic(w, h, emptyData);

            // Assert
            Assert.NotNull(bmp);
            Assert.Equal(w, bmp.Width);
            Assert.Equal(h, bmp.Height);
            // Проверяем цвет первого пикселя (должен быть белым после g.Clear)
            Assert.Equal(Color.FromArgb(255, 255, 255, 255), bmp.GetPixel(0, 0));
        }

        [Fact]
        public void Form_Analize_ShowsTop5SortedByCount()
        {
            // Arrange
            var form = new TextForm();
            var input = (TextBox)form.Controls.Find("textAnalizeTextBox", true)[0];
            var topResult = (TextBox)form.Controls.Find("charTopTextBox", true)[0];

            // 'a' - 3 раза, 'b' - 2 раза, 'c' - 1 раз
            input.Text = "aaabbc";

            // Act
            form.Analize(null, EventArgs.Empty);

            // Assert
            // Ожидаем, что первыми будут самые частые
            Assert.StartsWith("a: 3", topResult.Text);
            Assert.Contains("b: 2", topResult.Text);
        }
    }
}