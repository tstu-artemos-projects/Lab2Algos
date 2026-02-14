namespace Lab2
{
    public partial class TextForm : Form
    {
        public TextForm()
        {
            InitializeComponent();
        }

        public void Analize(object sender, EventArgs e)
        {
            string text = this.textAnalizeTextBox.Text;
            if (text.Trim().Length == 0)
            {
                MessageBox.Show("Пожалуйста, введите текст для анализа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var (chars, words, sentences) = TextClass.Count(text);
            this.charCountTextBox.Text = chars.ToString();
            this.wordCountTextBox.Text = words.ToString();
            this.sentenceCountTextBox.Text = sentences.ToString();

            var stats = TextClass.CharStats(text);

            var statsText = string.Join(
                Environment.NewLine,
                stats
                    .OrderByDescending(kv => kv.Value)
                    .Take(5)
                    .Select(kv => $"{kv.Key}: {kv.Value}")
            );
            this.charTopTextBox.Text = statsText;

            var drawedStats = TextClass.DrawStatic(
                histogramPictureBox.Width,
                histogramPictureBox.Height,
                stats
            );
            this.histogramPictureBox.Image = drawedStats;
        }
    }
}
