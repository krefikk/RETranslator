namespace RE_Translator
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            ENFileBrowse = new Button();
            TRFileBrowse = new Button();
            ENFileReset = new Button();
            TRFileReset = new Button();
            ENFileLabel = new Label();
            ENFileTextBox = new TextBox();
            TRFileLabel = new Label();
            TRFileTextBox = new TextBox();
            TranslatedOrNot = new CheckBox();
            ReportRichTextBox = new RichTextBox();
            Report = new Label();
            Translate = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Title = "Choose specified file.";
            // 
            // ENFileBrowse
            // 
            ENFileBrowse.Location = new Point(32, 112);
            ENFileBrowse.Name = "ENFileBrowse";
            ENFileBrowse.Size = new Size(94, 29);
            ENFileBrowse.TabIndex = 0;
            ENFileBrowse.Text = "Browse";
            ENFileBrowse.UseVisualStyleBackColor = true;
            ENFileBrowse.Click += ENFileBrowse_Click;
            // 
            // TRFileBrowse
            // 
            TRFileBrowse.Location = new Point(32, 351);
            TRFileBrowse.Name = "TRFileBrowse";
            TRFileBrowse.Size = new Size(94, 29);
            TRFileBrowse.TabIndex = 1;
            TRFileBrowse.Text = "Browse";
            TRFileBrowse.UseVisualStyleBackColor = true;
            TRFileBrowse.Click += TRFileBrowse_Click;
            // 
            // ENFileReset
            // 
            ENFileReset.Location = new Point(177, 112);
            ENFileReset.Name = "ENFileReset";
            ENFileReset.Size = new Size(94, 29);
            ENFileReset.TabIndex = 2;
            ENFileReset.Text = "Reset";
            ENFileReset.UseVisualStyleBackColor = true;
            ENFileReset.Click += ENFileReset_Click;
            // 
            // TRFileReset
            // 
            TRFileReset.Location = new Point(177, 351);
            TRFileReset.Name = "TRFileReset";
            TRFileReset.Size = new Size(94, 29);
            TRFileReset.TabIndex = 3;
            TRFileReset.Text = "Reset";
            TRFileReset.UseVisualStyleBackColor = true;
            TRFileReset.Click += TRFileReset_Click;
            // 
            // ENFileLabel
            // 
            ENFileLabel.AutoSize = true;
            ENFileLabel.Location = new Point(32, 27);
            ENFileLabel.Name = "ENFileLabel";
            ENFileLabel.Size = new Size(141, 20);
            ENFileLabel.TabIndex = 4;
            ENFileLabel.Text = "Choose original file.";
            // 
            // ENFileTextBox
            // 
            ENFileTextBox.Location = new Point(32, 65);
            ENFileTextBox.Name = "ENFileTextBox";
            ENFileTextBox.Size = new Size(239, 27);
            ENFileTextBox.TabIndex = 5;
            ENFileTextBox.Text = "Didn't choose any file.";
            // 
            // TRFileLabel
            // 
            TRFileLabel.AutoSize = true;
            TRFileLabel.Location = new Point(32, 271);
            TRFileLabel.Name = "TRFileLabel";
            TRFileLabel.Size = new Size(156, 20);
            TRFileLabel.TabIndex = 6;
            TRFileLabel.Text = "Choose translated file.";
            // 
            // TRFileTextBox
            // 
            TRFileTextBox.Location = new Point(32, 306);
            TRFileTextBox.Name = "TRFileTextBox";
            TRFileTextBox.Size = new Size(239, 27);
            TRFileTextBox.TabIndex = 7;
            TRFileTextBox.Text = "Didn't choose any file.";
            // 
            // TranslatedOrNot
            // 
            TranslatedOrNot.AutoSize = true;
            TranslatedOrNot.Location = new Point(34, 196);
            TranslatedOrNot.Name = "TranslatedOrNot";
            TranslatedOrNot.Size = new Size(153, 24);
            TranslatedOrNot.TabIndex = 8;
            TranslatedOrNot.Text = "I modified the file.";
            TranslatedOrNot.UseVisualStyleBackColor = true;
            TranslatedOrNot.CheckedChanged += TranslatedOrNot_CheckedChanged;
            // 
            // ReportRichTextBox
            // 
            ReportRichTextBox.Location = new Point(528, 65);
            ReportRichTextBox.Name = "ReportRichTextBox";
            ReportRichTextBox.ShowSelectionMargin = true;
            ReportRichTextBox.Size = new Size(243, 257);
            ReportRichTextBox.TabIndex = 9;
            ReportRichTextBox.Text = "";
            // 
            // Report
            // 
            Report.AutoSize = true;
            Report.Location = new Point(531, 25);
            Report.Name = "Report";
            Report.Size = new Size(54, 20);
            Report.TabIndex = 10;
            Report.Text = "Report";
            // 
            // Translate
            // 
            Translate.Location = new Point(528, 351);
            Translate.Name = "Translate";
            Translate.Size = new Size(243, 29);
            Translate.TabIndex = 11;
            Translate.Text = "Translate";
            Translate.UseVisualStyleBackColor = true;
            Translate.Click += Translate_Click;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.Description = "Choose a folder to save new file.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Translate);
            Controls.Add(Report);
            Controls.Add(ReportRichTextBox);
            Controls.Add(TranslatedOrNot);
            Controls.Add(TRFileTextBox);
            Controls.Add(TRFileLabel);
            Controls.Add(ENFileTextBox);
            Controls.Add(ENFileLabel);
            Controls.Add(TRFileReset);
            Controls.Add(ENFileReset);
            Controls.Add(TRFileBrowse);
            Controls.Add(ENFileBrowse);
            Name = "Form1";
            Text = "RE Translator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button ENFileBrowse;
        private Button TRFileBrowse;
        private Button ENFileReset;
        private Button TRFileReset;
        private Label ENFileLabel;
        private TextBox ENFileTextBox;
        private Label TRFileLabel;
        private TextBox TRFileTextBox;
        private CheckBox TranslatedOrNot;
        private RichTextBox ReportRichTextBox;
        private Label Report;
        private Button Translate;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}
