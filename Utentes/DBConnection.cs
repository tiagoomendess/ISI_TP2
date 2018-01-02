﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Utentes
{
    public class DBConnection
    {

        private SqlConnection connection;
        private SqlCommand cmd;
        private string server;
        private string database;
        private string uid;
        private string password;

        /// <summary>
        /// Construtor do objeto
        /// </summary>
        public DBConnection()
        {
            Initialize();
        }

        /// <summary>
        /// Inicializa os valores
        /// </summary>
        private void Initialize()
        {
            string connectionString = "Server=tcp:tiagoomendess.database.windows.net,1433;Initial Catalog=isi_trabalho_2;Persist Security Info=False;User ID=isiapp;Password=istoeumapassTabem?;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=10;";

            connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Abre a conexão à base de dados
        /// </summary>
        /// <returns>Verdadeiro se abrir com sucesso ou falso se não conseguir abrir</returns>
        private bool OpenConnection()
        {
            try
            {
                Log.Info("A abrir conexão com a Base de Dados.");
                connection.Open();
                Log.Info("Conexão com a base de dados aberta.");
                return true;
            }
            catch (SqlException ex)
            {
                //Caso não consiga conectar vai dar log do erro
                switch (ex.Number)
                {
                    case 0:
                        Log.Erro("Não foi possivel conectar com o servidor.");
                        break;

                    case 1045:
                        Log.Erro("Utilizador ou password errada na base de dados.");
                        break;
                    default:
                        Log.Erro("Erro ao conectar à base de dados:\n" + ex.ToString());
                        break;

                }
                return false;
            }
        }

        /// <summary>
        /// Fecha a conexão à base de dados
        /// </summary>
        /// <returns>Verdadeiro se sucesso ou falso se nao fechar</returns>
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                Log.Info("Conexão com a Base de dados foi fechada.");
                return true;
            }
            catch (SqlException ex)
            {
                Log.Erro(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Metodo para executar um insert ou um update, não retorna nenhum dataset
        /// </summary>
        /// <param name="query">Query </param>
        /// <param name="parametros">Parametros a preencher na query</param>
        /// <returns>Retorna o numero de linhas afetadas pela query</returns>
        public int NonQuery(string query, params object[] parametros)
        {
            int rowsAfected;
            cmd = new SqlCommand();
            cmd.Connection = this.connection;

            if (OpenConnection() == true)
            {
                cmd.CommandText = query;

                for (int i = 0; i < parametros.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + i, parametros[i]);
                }

                cmd.Prepare();
                rowsAfected = cmd.ExecuteNonQuery();
                CloseConnection();
                return rowsAfected;
            }

            return 0;
        }


        /// <summary>
        /// Faz uma query à base de dados
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="parametros">Parametros por ordem na query</param>
        /// <returns>Retorna o resultado da query da base de dados</returns>
        public DataTable Query(string query, params object[] parametros)
        {
            cmd = new SqlCommand();
            cmd.Connection = this.connection;
            DataTable dt = new DataTable();

            if (this.OpenConnection())
            {
                cmd.CommandText = query;

                for (int i = 0; i < parametros.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + i, parametros[i]);
                }

                dr = cmd.ExecuteReader();
                dt.Load(dr);
                CloseConnection();

                return dt;
            }

            return null;
        }

    }
}