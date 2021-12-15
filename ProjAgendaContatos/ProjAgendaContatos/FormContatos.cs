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
    public partial class FormContatos : Form
    {
        cl_Contato cont = new cl_Contato();
        cl_ControleContato controle = new cl_ControleContato();

        public FormContatos()
        {
            InitializeComponent();
        }

        private void limpar()
        {
            txtEmail.Clear();
            txtNome.Clear();
            MtxtCelu.Clear();
            MtxtTele.Clear();
            txtEmail.Focus();
        }

        public void AlterarBotoes(int op)
        {
            btnNovo.Enabled = false;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnBuscar.Enabled = false;
            btnCancelar.Enabled = false;

            if (op == 1)
            {
                btnNovo.Enabled = true;
            }

            if (op == 2)
            {
                btnCadastrar.Enabled = true;
                btnCancelar.Enabled = true;
            }

            if (op == 3)
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text == "")
            {
                MessageBox.Show("Não é permitido cadastrar sem um nome!", "Informe um Nome", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cont.Nome = txtNome.Text;
                cont.Telefone = MtxtTele.Text;
                cont.Celular = MtxtCelu.Text;
                cont.Email = txtEmail.Text;

                MessageBox.Show(controle.cadastrar(cont));
                limpar();

                AlterarBotoes(1);
                
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCod.Text == "")
            {
                MessageBox.Show("Para alterar, favor informar o código!", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                try
                {

                    cont.Codcontato = int.Parse(txtCod.Text);
                    cont.Nome = txtNome.Text;
                    cont.Telefone = MtxtTele.Text;
                    cont.Celular = MtxtCelu.Text;
                    cont.Email = txtEmail.Text;

                    MessageBox.Show(controle.alterar(cont));

                    AlterarBotoes(1);
                    limpar();
                }
                catch
                {
                    MessageBox.Show("Informe um número", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //"Tem certeza que deseja excluir?", "Excluindo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
            //if (MessageBox.Show("Tem certeza que deseja excluir?", "Excluindo o registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            //{
                cont.Codcontato = int.Parse(txtCod.Text);
                MessageBox.Show(controle.excluir(cont));

                limpar();
                AlterarBotoes(1);
            //}
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Metodo para busca   parametro     
                cont = controle.buscar(int.Parse(txtCod.Text));
                
                if (cont is null)
                {
                    MessageBox.Show("Registro não encontrado", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpar();
                }
                else
                {
                    txtCod.Text = cont.Codcontato.ToString();
                    txtNome.Text = cont.Nome;
                    txtEmail.Text = cont.Email;
                    MtxtCelu.Text = cont.Celular;
                    MtxtTele.Text = cont.Telefone;
                }

                AlterarBotoes(3);
            }
            // Buscar erros
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            AlterarBotoes(2);
            limpar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AlterarBotoes(1);
            limpar();
        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {
            if (txtCod.Text == "")
            {
                btnBuscar.Enabled = false;
            }
            else
            {
                btnBuscar.Enabled = true;
            }
        }

        private void FormContatos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo só aceita números", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
