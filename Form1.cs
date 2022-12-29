namespace Text_Editor
{
    public partial class Form1 : Form
    {

        StreamReader reading = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void New()
        {
            richTextBox1.Clear(); // Limpa a caixa de texto
            richTextBox1.Focus(); // Posiciona o cursor na caixa de texto
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            New();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New();
        }

        private void Save()
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream file = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write); // cria o arquivo
                    StreamWriter streamWriter01 = new StreamWriter(file); // escreve o arquivo
                    streamWriter01.Flush(); // zera/prepara o buffer para receber os componentes
                    streamWriter01.BaseStream.Seek(0, SeekOrigin.Begin); // informa o streamWriter de onde ele deve começar
                    streamWriter01.Write(this.richTextBox1.Text); // Define o que será escrito
                    streamWriter01.Flush();
                    streamWriter01.Close(); // Fecha e conclui a gravação (IMPORTANTE)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Open()
        {
            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Open file";
            openFileDialog1.InitialDirectory = @"C:\\Users\\filip\\Desktop\\";
            openFileDialog1.Filter = "Text file (*.txt) | *.txt";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream file = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader streamReader01 = new StreamReader(file);
                    streamReader01.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string line = streamReader01.ReadLine();
                    while (line != null)
                    {
                        this.richTextBox1.Text += line + "\n";
                        line = streamReader01.ReadLine();
                    }
                    streamReader01.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void Copy()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void Paste()
        {
            richTextBox1.Paste();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void btn_paste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void Bold()
        {
            string font_name = null;
            float font_size = 0;
            bool bold = false;

            font_name = richTextBox1.Font.Name;
            font_size = richTextBox1.Font.Size;
            bold = richTextBox1.Font.Bold;

            if (bold == false)
            {
                richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Bold);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Regular);
            }
        }

        private void Italic()
        {
            string font_name = null;
            float font_size = 0;
            bool italic = false;

            font_name = richTextBox1.Font.Name;
            font_size = richTextBox1.Font.Size;
            italic = richTextBox1.Font.Italic;

            if (italic == false)
            {
                richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Italic);
            }
        }

        private void Underline()
        {
            string font_name = null;
            float font_size = 0;
            bool underline = false;

            font_name = richTextBox1.Font.Name;
            font_size = richTextBox1.Font.Size;
            underline = richTextBox1.Font.Italic;

            if (underline == false)
            {
                richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Underline);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Underline);
            }
        }

        private void btn_bold_Click(object sender, EventArgs e)
        {
            Bold();
        }

        private void btn_italic_Click(object sender, EventArgs e)
        {
            Italic();
        }

        private void btn_underline_Click(object sender, EventArgs e)
        {
            Underline();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bold();
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italic();
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Underline();
        }
    }
}