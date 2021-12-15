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
    public partial class FormConsultas : Form
    {
        cl_Contato cont = new cl_Contato();
        cl_ControleContato controle = new cl_ControleContato();

        public FormConsultas()
        {
            InitializeComponent();
        }

        private void FormConsultas_Load(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            //DataSource é a fonte
            dataGridView1.DataSource = controle.PreencherTodos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbOpcoes.SelectedIndex == 0)
            {
                int codigo = Convert.ToInt32(txtBuscar.Text);

                dataGridView1.DataSource = controle.PesquisaCodigo(codigo);
                /*try
                {
                    int codigo = Convert.ToInt32(txtBuscar.Text);

                    dataGridView1.DataSource = controle.PesquisaCodigo(codigo);
                }
                catch
                {
                    MessageBox.Show("Digite um valor inteiro valido!");
                    txtBuscar.Clear();
                    txtBuscar.Focus();
                }*/
            } 
            else if (cbOpcoes.SelectedIndex == 1)
            {
                string nome = txtBuscar.Text;
                dataGridView1.DataSource = controle.PesquisaNome(nome);
            } 
            
            else if (cbOpcoes.SelectedIndex == 2)
            {
                string celular = txtBuscar.Text;
                dataGridView1.DataSource = controle.PesquisaCelular(celular);
            }

            else if (cbOpcoes.SelectedIndex == 3)
            {
                string telefone = txtBuscar.Text;
                dataGridView1.DataSource = controle.PesquisaTelefone(telefone);
            }

            else if (cbOpcoes.SelectedIndex == 4)
            {
                string email = txtBuscar.Text;
                dataGridView1.DataSource = controle.PesquisaEmail(email);
            }
        }

        private void cbOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOpcoes.SelectedIndex < 0)
            {
                txtBuscar.Enabled = false;
                btnBuscar.Enabled = false;
                lblOpcao.Text = "";
            }
            else
            {
                txtBuscar.Enabled = true;
                btnBuscar.Enabled = true;
                lblOpcao.Text = "Digite o " + cbOpcoes.Text;
                txtBuscar.Clear();
                txtBuscar.Focus();
            }
        }
    }
}
