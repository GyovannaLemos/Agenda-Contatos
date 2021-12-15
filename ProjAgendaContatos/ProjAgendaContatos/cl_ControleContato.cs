using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjAgendaContatos
{
    class cl_ControleContato
    {
        cl_Conexao c = new cl_Conexao();

        public string cadastrar(cl_Contato cont)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tbcontato (nome, telefone, celular, email) " +
                                                    "VALUES ( '" + cont.Nome + "', '" + cont.Telefone + "', '" + cont.Celular + "', ' " + cont.Email + "')", c.con);
                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                
                return ("Cadastro realizado com sucesso!");

            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }


        public string alterar(cl_Contato cont)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tbcontato set nome = '" + cont.Nome + "' , " + "telefone = '" + cont.Telefone + "' ," + "celular = '" 
                                                    + cont.Celular + "', email = '" + cont.Email + "' where codcontato = " + cont.Codcontato + " ; ", c.con);
                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();

                return ("Alteração realizada com sucesso!");

            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        public string excluir(cl_Contato cont)
        {
            try
            {
                
                MySqlCommand cmd = new MySqlCommand("delete from tbcontato where codcontato = " + cont.Codcontato + " ; ", c.con);

                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();

                return ("Registro exluído com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        public cl_Contato buscar(int codigo)
        {
            cl_Contato cont = new cl_Contato();

            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tbcontato where codcontato = " + codigo + " ; ", c.con);

                c.conectar();

                // MySqlDataReader faz a leitura dos dados no banco 
                MySqlDataReader objDados = cmd.ExecuteReader();

                //if com ! - se não
                //hasRows - se tem o regis~tro
                if (!objDados.HasRows)
                {
                    return null;
                }
                else
                {
                    objDados.Read(); // Tudo o que foi lido irá passar para a classe 
                    cont.Codcontato = Convert.ToInt32(objDados["codcontato"]);
                    cont.Nome = objDados["nome"].ToString();
                    cont.Telefone = objDados["telefone"].ToString();
                    cont.Celular = objDados["celular"].ToString();
                    cont.Email = objDados["email"].ToString();

                    objDados.Close();
                    return cont;
                }
            }
            catch (MySqlException e)
            {
                throw (e);
            }
            finally
            {
                c.desconectar();
            }
        }

        // DataTable - tabela de dados
        public DataTable PreencherTodos() // Listar todas as informações e colocar no DataGridView
        {
            MySqlCommand cmd = new MySqlCommand("select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato ; ", c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd); // Pegar uma tabela de dados

            DataTable contato = new DataTable();
            da.Fill(contato); // Preencher uma tabela 'da'
            c.desconectar();

            return contato;
        }

        // A diferença é o parametro
        public DataTable PesquisaCodigo(int codigo)
        {
            MySqlCommand cmd = new MySqlCommand("select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where codcontato = " + codigo + " ; ", c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();

            return contato;
        }

        public DataTable PesquisaNome(string nome)
        {
            MySqlCommand cmd = new MySqlCommand("select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where nome like '%" + nome + "%' ; ", c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();

            return contato;
        }

        public DataTable PesquisaCelular(string celular)
        {
            MySqlCommand cmd = new MySqlCommand("select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where celular like '%" + celular + "%' ; ", c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();

            return contato;
        }

        public DataTable PesquisaTelefone(string telefone)
        {
            MySqlCommand cmd = new MySqlCommand("select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where telefone like '%" + telefone + "%' ; ", c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();

            return contato;
        }

        public DataTable PesquisaEmail(string email)
        {
            MySqlCommand cmd = new MySqlCommand("select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where email like '%" + email + "%' ; ", c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();

            return contato;
        }

        public string Backup(string Caminho)
        {
            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            string CaminhoBackup = Caminho + "\\backupContatos_" + dataAtual + ".sql"; //arquivo irá se chamar backupcontatos_ e tera a data atual

            try
            {
                MySqlCommand cmd = new MySqlCommand(CaminhoBackup, c.con);
                MySqlBackup mb = new MySqlBackup(cmd);

                c.conectar();
                mb.ExportToFile(CaminhoBackup);
                c.desconectar();

                return ("Backup do banco de dados realizado com sucesso!");
            }
            catch(MySqlException e)
            {
                return (e.ToString());
            }
        }

        public string Restore(string Caminho) //Backup e MySQL database
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(Caminho, c.con);
                MySqlBackup mb = new MySqlBackup(cmd);

                c.conectar();
                mb.ImportFromFile(Caminho);
                c.desconectar();

                return ("Banco de Dados restaurado com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

    }
}
