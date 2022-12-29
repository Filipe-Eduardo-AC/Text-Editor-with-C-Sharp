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
    }
}