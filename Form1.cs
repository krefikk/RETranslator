using System.Windows.Forms;
using System;
using System.IO;
using static System.Windows.Forms.LinkLabel;
using System.Diagnostics;

namespace RE_Translator
{
    public partial class Form1 : Form
    {

        private string directoryToSave = "";

        private bool choosedENFile = false;
        private string ENFileName = "";

        private bool modified = false;

        private bool choosedTRFile = false;
        private string TRFileName = "";

        public Form1()
        {
            InitializeComponent();
            TRFileBrowse.Visible = false;
            TRFileReset.Visible = false;
            TRFileLabel.Visible = false;
            TRFileTextBox.Visible = false;
        }

        private void ENFileBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Document |*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                choosedENFile = true;
                ENFileTextBox.Text = openFileDialog1.FileName;
                ENFileName = openFileDialog1.FileName;
            }
        }

        private void ENFileReset_Click(object sender, EventArgs e)
        {
            choosedENFile = false;
            ENFileTextBox.Text = "Didn't choose anything";
            ENFileName = "";
        }

        private void TranslatedOrNot_CheckedChanged(object sender, EventArgs e)
        {
            modified = !modified;
            if (!modified)
            {
                TRFileBrowse.Visible = false;
                TRFileReset.Visible = false;
                TRFileLabel.Visible = false;
                TRFileTextBox.Visible = false;
            }
            else
            {
                TRFileBrowse.Visible = true;
                TRFileReset.Visible = true;
                TRFileLabel.Visible = true;
                TRFileTextBox.Visible = true;
            }
        }

        private void TRFileBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Document |*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                choosedTRFile = true;
                TRFileTextBox.Text = openFileDialog1.FileName;
                TRFileName = openFileDialog1.FileName;
            }
        }

        private void TRFileReset_Click(object sender, EventArgs e)
        {
            choosedTRFile = false;
            TRFileTextBox.Text = "Didn't choose anything";
            TRFileName = "";
        }

        private void Translate_Click(object sender, EventArgs e)
        {   
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) 
            {
                directoryToSave = folderBrowserDialog1.SelectedPath;
                if (choosedENFile)
                {
                    if (modified)
                    {
                        if (choosedTRFile)
                        {
                            int ENcount = 0;
                            int TRcount = 0;

                            try
                            {
                                using (StreamReader ENreader = new StreamReader(ENFileName))
                                {
                                    string line;

                                    while ((line = ENreader.ReadLine()) != null)
                                    {
                                        ENcount++;
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine($"The file could not be read: {exception.Message}");
                            }

                            try
                            {
                                using (StreamReader TRreader = new StreamReader(TRFileName))
                                {
                                    string line;

                                    while ((line = TRreader.ReadLine()) != null)
                                    {
                                        TRcount++;
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine($"The file could not be read: {exception.Message}");
                            }

                            if (ENcount == TRcount)
                            {
                                Translator translator = new Translator(true, directoryToSave, ENFileName, TRFileName);
                                List<int> returnList = translator.Translate();
                                ReportRichTextBox.Text = "Common Lines: " + returnList[0] +  "\nLines Modified: " + returnList[1];
                                MessageBox.Show("Translation completed.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("The number of lines of files does not match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("You did not select the modified file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Translator translator = new Translator(false, directoryToSave, ENFileName, TRFileName);
                        List<int> returnList = translator.Translate();
                        ReportRichTextBox.Text = "Common Lines: " + returnList[0] + "\nLines Modified: " + returnList[1];
                        MessageBox.Show("Translation completed.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("You did not select the original file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
    }

    public class Translator
    {
        private string directoryToSave = "";

        private bool modified = false;
        List<string> EN = new List<string>();
        List<string> TR = new List<string>();

        private string re_en = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "textFiles"), "re_en.txt");
        private string re_tr = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "textFiles"), "re_tr.txt");

        List<string> EN_RE = new List<string>();
        List<string> TR_RE = new List<string>();

        public Translator(bool modified, string directoryToSave, string ENFile, string TranslatedFile)
        {
            this.modified = modified;
            this.directoryToSave = directoryToSave;

            try
            {
                EN = new List<string>(File.ReadAllLines(ENFile));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The file could not be read: {ex.Message}");
            }

            if (modified)
            {
                try
                {
                    TR = new List<string>(File.ReadAllLines(TranslatedFile));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"The file could not be read: {ex.Message}");
                }
            }
            else 
            {
                TR = EN;
            }

            try
            {
                if (!File.Exists(re_en)) 
                {
                    Debug.Print("file not exist");
                }
                EN_RE = new List<string>(File.ReadAllLines(re_en));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The file could not be read: {ex.Message}");
            }

            try
            {
                TR_RE = new List<string>(File.ReadAllLines(re_tr));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The file could not be read: {ex.Message}");
            }

        }

        public List<int> Translate()
        {
            if (EN_RE.Count == 0) 
            {
                Debug.Print("0 error");
            }
            
            List<int> returnList = new List<int>();
            int commonLines = 0;
            int changedLines = 0;

            if (EN_RE.Count == TR_RE.Count) 
            {
                for (int i = 0; i < EN.Count; i++) 
                {
                    for (int j = 0; j < EN_RE.Count; j++) 
                    {
                        if (EN[i] == EN_RE[j]) 
                        {
                            commonLines++;
                            if (modified)
                            {
                                if (EN[i] == TR[i])
                                {
                                    TR[i] = TR_RE[j];
                                    changedLines++;
                                }
                            }
                            else 
                            {
                                TR[i] = TR_RE[j];
                                changedLines++;
                            }
                        }
                    }
                }
            }

            ListToFile(TR);

            returnList.Add(commonLines);
            returnList.Add(changedLines);
            return returnList;
        }

        public void ListToFile(List<string> list)
        {
            try
            {
                File.WriteAllLines(Path.Combine(directoryToSave, "new.txt"), list);
                Console.WriteLine($"File written successfully to {Path.Combine(directoryToSave, "new.txt")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
        }

    }

}
