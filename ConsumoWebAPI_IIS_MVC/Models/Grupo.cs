using ConsumoWebAPI_IIS_MVC.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoWebAPI_IIS_MVC.Models
{
    public class Grupo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Entre 03 e 100 Caracteres !")]
        [Display(Name = "Nome do Grupo")]
        public String GrupoNome { get; set; }

        public List<Grupo> ListarTodosGrupos()
        {
            List<Grupo> lista = new List<Grupo>();
            Grupo item;
            DAL objDAL = new DAL();
            objDAL.LimparParametros();
            String sql = "Select Id, GrupoNome From Grupos order by id asc";
            DataTable dt = objDAL.RetDatatable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Grupo
                {
                    Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                    GrupoNome = dt.Rows[i]["GrupoNome"].ToString()
                };
                lista.Add(item);
                objDAL.FecharConexao();
            }
            return lista;
        }
    }
}
