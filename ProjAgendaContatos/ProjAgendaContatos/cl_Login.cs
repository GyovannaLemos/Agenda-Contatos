using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace ProjAgendaContatos
{
    class cl_Login
    {
        cl_Conexao c = new cl_Conexao();

        // metodo bool retorna true e false
        public bool Logar(string l, string s)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select login, senha from tblogin where login like '" + l + "' and senha like '" + s + "'; ", c.con);


                c.conectar();

                MySqlDataReader objDados = cmd.ExecuteReader();

                if (!objDados.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
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

    }
}
