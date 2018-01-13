using Maps.Entidade;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Maps.Models
{
    public class PibModels
    {
        private string stringConexao { get; set; }

        public PibModels()
        {
            this.stringConexao = ConfigurationManager.ConnectionStrings["CONN_MAPS"].ToString();
        }

        public List<PibEntidade> SelecionarPib(PibEntidade entidade)
        {
            SqlDataReader reader = null;

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                //criação do objeto que realizará o comando no banco de dados
                SqlCommand command = new SqlCommand("PR_S_PIB", connection);

                //setando o tipo de artefato que será chamado no banco de dados
                command.CommandType = System.Data.CommandType.StoredProcedure;

                //Adição dos parâmetros das procedures
                command.Parameters.Add(new SqlParameter("@NOME_CIDADE", entidade.cidade));

                try
                {
                    //abre conexão com banco de dados
                    connection.Open();
                    //executa o comando
                    reader = command.ExecuteReader();

                    return GerarPib(reader);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //verifica se a conexão não está fechada
                    if (connection.State != System.Data.ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private List<PibEntidade> GerarPib(SqlDataReader reader)
        {
            List<PibEntidade> lPib = new List<PibEntidade>();

            try
            {
                //Verifica se o objeto retornado do banco de dados possui dados
                if (reader.HasRows)
                {
                    PibEntidade entidade = null;

                    int inteiro = -1;
                    double flutuante = -1;
                    DateTime data = DateTime.Now;

                    //faz o loop para ler os dados retornados
                    while (reader.Read())
                    {
                        inteiro = -1;
                        data = DateTime.Now;

                        entidade = new PibEntidade();
                        entidade.idPib = (int.TryParse(reader["ID_PIB"].ToString(), out inteiro) ? inteiro : -1);
                        entidade.posicao = (int.TryParse(reader["POSICAO"].ToString(), out inteiro) ? inteiro : -1);
                        entidade.cidade = reader["CIDADE"].ToString();
                        entidade.valor = (double.TryParse(reader["VALOR"].ToString(), out flutuante) ? flutuante : -1);
                        entidade.percentualRelativo = (double.TryParse(reader["PERCENTUAL_RELATIVO"].ToString(), out flutuante) ? flutuante : -1);
                        entidade.percentualTotal = (double.TryParse(reader["PERCENTUAL_TOTAL"].ToString(), out flutuante) ? flutuante : -1);
                        entidade.coordenadaX = (double.TryParse(reader["COORDENADA_X"].ToString(), out flutuante) ? flutuante : -1);
                        entidade.coordenadaY = (double.TryParse(reader["COORDENADA_Y"].ToString(), out flutuante) ? flutuante : -1);

                        lPib.Add(entidade);
                    }
                }

                return lPib;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}