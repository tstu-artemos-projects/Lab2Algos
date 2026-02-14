using Xunit;
using Lab2;
using System.Windows.Forms;

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
    }
}