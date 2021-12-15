using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjAgendaContatos
{
    public partial class Form1 : Form
    {
        cl_ControleContato controle = new cl_ControleContato();

        public Form1()
        {
            InitializeComponent();
        }


        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormContatos contatos = new FormContatos();
            contatos.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsultas consultas = new FormConsultas();
            consultas.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(controle.Backup("C:\\Backup"), "Backup do Banco de Dados", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void restauracaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1  = new OpenFileDialog();

            openFileDialog1.Filter = "sql files (*.sql) |*.sql | All files (*.*)|*.*"; // Todo tipo de arquivo MySql

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string CaminhoBackup = openFileDialog1.FileName;
                MessageBox.Show(controle.Restore(CaminhoBackup), "Restauração do Banco de Dados", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormLogin TelaLogin = new FormLogin();
            TelaLogin.ShowDialog();

            cl_Conexao c = new cl_Conexao();
            MessageBox.Show(c.conectar());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolSLHora.Text = DateTime.Now.ToString(" dd/MM/yyyy H:mm:ss ");
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.ShowDialog();
        }
    }
}
