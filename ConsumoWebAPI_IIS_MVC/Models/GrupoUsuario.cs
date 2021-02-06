using ConsumoWebAPI_IIS_MVC.DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoWebAPI_IIS_MVC.Models
{
    public class GrupoUsuario
    {
        public String GruposId { get; set; }
        public String GrupoNome { get; set; }
        public int UsuariosId { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }

        public List<GrupoUsuario> RetornarListagem()
        {
            List<GrupoUsuario> lista = new List<GrupoUsuario>();
            GrupoUsuario item;
            DAL objDAL = new DAL();
            objDAL.LimparParametros();

            //Consulta para Listar a Relação -> INNER JOIN
            String sql = "Select GruposId, GrupoNome, UsuariosId, Nome, Email From GrupoUsuario Inner Join Grupos on Grupos.Id = GrupoUsuario.GruposId Inner Join Usuarios on UsuariosId = Usuarios.Id order by GruposId".ToString();

            DataTable dt = objDAL.RetDatatable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new GrupoUsuario
                {
                    GruposId = dt.Rows[i]["GruposId"].ToString(),
                    GrupoNome = dt.Rows[i]["GrupoNome"].ToString(),
                    UsuariosId = int.Parse(dt.Rows[i]["UsuariosId"].ToString()),
                    Nome = dt.Rows[i]["Nome"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString()
                };
                lista.Add(item);
                objDAL.FecharConexao();
            }
            return lista;
        }

        public List<GrupoUsuario> RetornarListagemId(String GruposId)
        {
            List<GrupoUsuario> lista = new List<GrupoUsuario>();
            GrupoUsuario item;
            DAL objDAL = new DAL();
            objDAL.LimparParametros();

            //Consulta para Listar a Relação -> INNER JOIN
            String sql = $"Select GruposId, GrupoNome, UsuariosId, Nome, Email From GrupoUsuario Inner Join Grupos on Grupos.Id = GrupoUsuario.GruposId Inner Join Usuarios on UsuariosId = Usuarios.Id Where GruposId = '{GruposId}' order by GruposId".ToString();

            DataTable dt = objDAL.RetDatatable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new GrupoUsuario
                {
                    GruposId = dt.Rows[i]["GruposId"].ToString(),
                    GrupoNome = dt.Rows[i]["GrupoNome"].ToString(),
                    UsuariosId = int.Parse(dt.Rows[i]["UsuariosId"].ToString()),
                    Nome = dt.Rows[i]["Nome"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString()
                };
                lista.Add(item);
                objDAL.FecharConexao();
            }
            return lista;
        }

        public List<Grupo> RetornarListaGrupo()
        {
            return new Grupo().ListarTodosGrupos();
        }

        public List<Usuarios> RetornarListaUsuario()
        {
            return new Usuarios().ListarTodosUsuarios();
        }

        public void Inserir()
        {
            try
            {
                DAL objDAL = new DAL();
                objDAL.LimparParametros();

                string sql = "INSERT INTO GrupoUsuario (GruposId,UsuariosId) " +
                  $"VALUES('{GruposId}', '{UsuariosId}')";
                objDAL.RetDatatable(sql);

                DataTable dt = objDAL.RetDatatable(sql);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sql = "insert into Usuarios(Nome, Email) " +
                        $"values({dt.Rows[i]["Nome"]}, {dt.Rows[i]["Email"]}";
                    objDAL.RetDatatable(sql);
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sql = "insert into Grupos(GrupoNome) " +
                        $"values({dt.Rows[i]["GrupoNome"]}";
                    objDAL.RetDatatable(sql);
                    objDAL.FecharConexao();
                }
            }
            catch
            {
                //
            }
        }          
    }
}