namespace Text_Editor
{
    public partial class Form1 : Form
    {

        StringReader reading = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void New()
        {
            richTextBox1.Clear(); // Limpa a caixa de texto
            richTextBox1.Focus(); // Posiciona o cursor na caixa de texto
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

        private void Cut()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void Bold()
        {
            string font_name = null;
            float font_size = 0;
            bool b, i, u = false;

            font_name = richTextBox1.Font.Name;
            font_size = richTextBox1.Font.Size;
            b = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            u = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Regular);

            if (b == false)
            {
                if (i == true & u == true)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false & u == true)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Bold | FontStyle.Underline);
                }
                else if (i == true & u == false)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Bold | FontStyle.Italic);
                }
                else if (i == false & u == false)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Bold);
                }
            }
            else
            {
                if (i == true & u == true)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false & u == true)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Underline);
                }
                else if (i == true & u == false)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Italic);
                }
            }
        }

        private void Italic()
        {
            string font_name = null;
            float font_size = 0;
            bool b, i, u = false;

            font_name = richTextBox1.Font.Name;
            font_size = richTextBox1.Font.Size;
            b = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            u = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Regular);

            if (i == false)
            {
                if (b == true & u == true)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (b == false & u == true)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Italic | FontStyle.Underline);
                }
                else if (b == true & u == false)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Bold | FontStyle.Italic);
                }
                else if (b == false & u == false)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Italic);
                }
            }
            else
            {
                if (b == true & u == true)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Bold | FontStyle.Underline);
                }
                else if (b == false & u == true)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Underline);
                }
                else if (b == true & u == false)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Bold);
                }
            }
        }

        private void Underline()
        {
            string font_name = null;
            float font_size = 0;
            bool b, i, u = false;

            font_name = richTextBox1.Font.Name;
            font_size = richTextBox1.Font.Size;
            b = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            u = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Regular);

            if (u == false)
            {
                if (i == true & b == true)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false & b == true)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Bold | FontStyle.Underline);
                }
                else if (i == true & b == false)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Underline | FontStyle.Italic);
                }
                else if (i == false & b == false)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Underline);
                }
            }
            else
            {
                if (i == true & b == true)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Italic | FontStyle.Bold);
                }
                else if (i == false & b == true)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Bold);
                }
                else if (i == true & b == false)
                {
                    richTextBox1.SelectionFont = new Font(font_name, font_size, FontStyle.Italic);
                }
            }
        }

        private void LeftAlign()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void CenterAlign()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void RightAlign()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void Print()
        {
            printDialog1.Document = printDocument1;
            string text = this.richTextBox1.Text;
            reading = new StringReader(text);

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void Undo()
        {
            richTextBox1.Undo();
        }

        private void Redo()
        {
            richTextBox1.Redo();
        }




        private void btn_new_Click(object sender, EventArgs e)
        {
            New();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btn_open_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void btn_paste_Click(object sender, EventArgs e)
        {
            Paste();
        }
        private void btn_bold_Click(object sender, EventArgs e)
        {
            Bold();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bold();
        }

        private void btn_italic_Click(object sender, EventArgs e)
        {
            Italic();
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italic();
        }
        private void btn_underline_Click(object sender, EventArgs e)
        {
            Underline();
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Underline();
        }
        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeftAlign();
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            LeftAlign();
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CenterAlign();
        }

        private void btn_center_Click(object sender, EventArgs e)
        {
            CenterAlign();
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RightAlign();
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            RightAlign();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int count = 0;
            float CordY = 0;
            float pageLines = 0;
            string line = null;
            float leftMargin = e.MarginBounds.Left - 50;
            float upperMargin = e.MarginBounds.Top - 50;


            Font font = this.richTextBox1.Font;
            SolidBrush brush = new SolidBrush(Color.Black);

            pageLines = e.MarginBounds.Height / font.GetHeight(e.Graphics);
            line = reading.ReadLine();

            if (leftMargin < 5)
            {
                leftMargin = 20;
            }
            if (upperMargin < 5)
            {
                upperMargin = 20;
            }

            while (count < pageLines)
            {
                CordY = (upperMargin + (count * font.GetHeight(e.Graphics)));
                e.Graphics.DrawString(line, font, brush, leftMargin, CordY, new StringFormat());
                count += 1;
                line = reading.ReadLine();
            }
            if (line != null)
            {
                e.HasMorePages = true;
            }
            brush.Dispose();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void btn_cut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_undo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void btn_redo_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void btn_font_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Font font = fontDialog1.Font;
                this.richTextBox1.SelectionFont = font;
            }
        }
    }
}