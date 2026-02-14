using static System.Net.Mime.MediaTypeNames;

namespace Lab2
{
    partial class TextForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();

            // Инициализация страниц
            InitializeTextAnalizePage();
            InitializeHistogramPage();

            // Настройка главного окна
            this.SuspendLayout();
            this.tabControl1.Controls.Add(this.textAnalizePage);
            this.tabControl1.Controls.Add(this.histogramPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.SelectedIndex = 0;

            this.Controls.Add(this.tabControl1);
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Text = "Лабораторная работа №2 - Вариант 12";
            this.Name = "TextForm";

            this.tabControl1.ResumeLayout(false);
            this.textAnalizePage.ResumeLayout(false);
            this.textAnalizePage.PerformLayout();
            this.histogramPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.histogramPictureBox)).EndInit();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ResumeLayout(false);
        }

        private void InitializeTextAnalizePage()
        {
            this.textAnalizePage = new ();
            this.textAnalizeTextBox = new ();
            this.analizeButton = new ();

            // Поля вывода статистики
            this.charCountTextBox = new ();
            this.wordCountTextBox = new ();
            this.sentenceCountTextBox = new ();
            this.charTopTextBox = new ();
            this.analizeLabel = new ();

            // Подписи
            this.charCountLabel = new ();
            this.wordCountLabel = new ();
            this.sentenceCountLabel = new ();
            this.charTopLabel = new ();

            // Настройка страницы
            this.textAnalizePage.Text = "Ввод, Статистика и Анализ";
            this.textAnalizePage.Padding = new (10);

            // Главное поле ввода
            this.textAnalizeTextBox.Multiline = true;
            this.textAnalizeTextBox.ScrollBars = ScrollBars.Vertical;
            this.textAnalizeTextBox.Location = new (20, 20);
            this.textAnalizeTextBox.Size = new (500, 350);
            this.textAnalizeTextBox.Name = "textAnalizeTextBox";

            // Позиционирование элементов статистики справа
            int statsLeft = 550;

            this.analizeLabel.Text = "Введите текст для рассчёта количества букв, слов, предложений";
            this.analizeLabel.Location = new(statsLeft, 20);
            this.analizeLabel.AutoSize = true;
            this.analizeLabel.Name = "analizeLabel";

            SetupStatControl(charCountLabel, charCountTextBox, "Символов:", statsLeft, 40, "charCountTextBox");
            SetupStatControl(wordCountLabel, wordCountTextBox, "Слов:", statsLeft, 100, "wordCountTextBox");
            SetupStatControl(sentenceCountLabel, sentenceCountTextBox, "Предложений:", statsLeft, 160, "sentenceCountTextBox");
            SetupStatControl(charTopLabel, charTopTextBox, "Топ 5 букв:", statsLeft, 220, "charTopTextBox");

            this.charTopTextBox.Multiline = true;
            this.charTopTextBox.Size = new(150, 23 * 5 - 7 * 4);

            // Кнопка
            this.analizeButton.Text = "Рассчитать";
            this.analizeButton.Location = new (20, 380);
            this.analizeButton.Size = new (150, 40);
            this.analizeButton.Click += this.Analize;
            this.analizeButton.Name = "analizeButton";

            // Добавление на страницу
            this.textAnalizePage.Controls.AddRange(new Control[] {
                textAnalizeTextBox, analizeButton, charCountLabel, charCountTextBox,
                wordCountLabel, wordCountTextBox, sentenceCountLabel, sentenceCountTextBox,
                charTopTextBox, charTopLabel, analizeLabel
            });
        }

        private void SetupStatControl(Label lbl, TextBox txt, string title, int x, int y, string? name)
        {
            lbl.Text = title;
            lbl.Location = new (x, y);
            lbl.AutoSize = true;

            txt.Location = new (x, y + 20);
            txt.Size = new (150, 23);
            txt.Name = name ?? title.Replace(" ", "") + "TextBox";
            txt.ReadOnly = true;
        }

        private void InitializeHistogramPage()
        {
            this.histogramPage = new ();
            this.histogramPictureBox = new ();
            this.histogramLabel = new ();

            this.histogramPage.Text = "Визуализация";

            this.histogramLabel.Text = "Частотное распределение букв (A-Z):";
            this.histogramLabel.Location = new (20, 15);
            this.histogramLabel.AutoSize = true;

            this.histogramPictureBox.BackColor = Color.White;
            this.histogramPictureBox.BorderStyle = BorderStyle.Fixed3D;
            this.histogramPictureBox.Location = new (20, 40);
            this.histogramPictureBox.Size = new (780, 380);

            this.histogramPage.Controls.Add(this.histogramLabel);
            this.histogramPage.Controls.Add(this.histogramPictureBox);
        }

        // UI Components
        private TabControl tabControl1;

        private TabPage textAnalizePage;
        private TabPage histogramPage;

        // Text Analize Page
        private Label analizeLabel;

        private TextBox textAnalizeTextBox;

        private TextBox charCountTextBox;
        private TextBox wordCountTextBox;
        private TextBox sentenceCountTextBox;

        private TextBox charTopTextBox;

        private Label charCountLabel;
        private Label wordCountLabel;
        private Label sentenceCountLabel;

        private Label charTopLabel;

        private Button analizeButton;

        // Histogram Page
        private Label histogramLabel;
        private PictureBox histogramPictureBox;
    }
}
