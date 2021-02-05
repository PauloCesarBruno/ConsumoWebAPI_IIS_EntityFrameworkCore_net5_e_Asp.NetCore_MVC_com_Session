using ConsumoWebAPI_IIS_MVC.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoWebAPI_IIS_MVC.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Entre 03 e 100 Caracteres !")]
        [Display(Name = "Nome")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Máximo 100 Caracteres !")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O Email não possui um Formato Valido !")]
        public String Email { get; set; }

        public List<Usuarios> ListarTodosUsuarios()
        {
            List<Usuarios> lista = new List<Usuarios>();
            Usuarios item;
            DAL objDAL = new DAL();
            objDAL.LimparParametros();
            String sql = "Select Id, Nome, Email From Usuarios order by id asc";
            DataTable dt = objDAL.RetDatatable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Usuarios
                {
                    Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                    Nome = dt.Rows[i]["Nome"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString()
                };
                lista.Add(item);
                objDAL.FecharConexao();
            }
            return lista;
        }
    }
}
