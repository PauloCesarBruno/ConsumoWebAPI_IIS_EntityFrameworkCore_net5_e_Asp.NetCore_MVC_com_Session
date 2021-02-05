using ConsumoWebAPI_IIS_MVC.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoWebAPI_IIS_MVC.Models
{
    public class ModelLogin
    {
        public String Id { get; set; }

        [Display(Name = "Nome")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O Email não possui um formato válido !")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public String Senha { get; set; }

        public Boolean ValidarLogin()
        {

            DAL objDAL = new DAL();
            String sql = $"Select Id, Nome From Login Where Email = '{Email}' And Senha = '{Senha}'";
            DataTable dt = objDAL.RetDatatable(sql);

            if (dt.Rows.Count == 1)
            {
                Id = dt.Rows[0]["Id"].ToString();
                Nome = dt.Rows[0]["Nome"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
