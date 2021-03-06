﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Add
using System.Data;
using System.Data.SqlClient;

namespace ConsumoWebAPI_IIS_MVC.DataAccessLayer
{  
    public class DAL
    {
        public static readonly String Server = "DESKTOP-EJP79KA";
        public static readonly String Database = "Grupo";
        public static readonly String User = "sa";
        public static readonly String Password = "Paradoxo22";

        public static readonly String StrSql = $"Server = {Server}; Database = {Database}; Uid = {User}; Pwd ={Password}";

        public SqlConnection Conexao()
        {
            return new SqlConnection(StrSql);
        }

        public void FecharConexao()
        {
            SqlConnection conn = Conexao();
            conn.Close();
        }

        private readonly SqlParameterCollection Colecao = new SqlCommand().Parameters;

        public void LimparParametros()
        {
            Colecao.Clear();
        }

        public void AddParametros(String nome, Object valor)
        {
            Colecao.Add(new SqlParameter(nome, valor));
        }

        public Object ExecutarManipulacao(CommandType commandType, String Sp_Ou_Texto)
        {
            try
            {
                SqlConnection conn = Conexao();
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = commandType;
                cmd.CommandText = Sp_Ou_Texto;
                cmd.CommandTimeout = 3600;

                foreach (SqlParameter param in Colecao)
                {
                    cmd.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                }
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ExecutarConsulta(CommandType commandType, String Sp_Ou_Texto)
        {
            try
            {
                SqlConnection conn = Conexao();
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = commandType;
                cmd.CommandText = Sp_Ou_Texto;
                cmd.CommandTimeout = 3600;

                foreach (SqlParameter param in Colecao)
                {
                    cmd.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                }
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable RetDatatable(string sql)
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, Conexao());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        // Polimorfismo para Evitar ataque de injeção de SQL
        public DataTable RetDatatable(SqlCommand cmd)
        {

            DataTable dt = new DataTable();
            cmd.Connection = Conexao();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }            
    }
}