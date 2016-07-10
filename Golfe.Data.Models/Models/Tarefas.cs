using Golfe.Web.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golfe.Data.Models
{
    public class Tarefas 
    {
        public int Id { get; set; }
        public string AreaJogo { get; set; }
        public string Operacao { get; set; }
        public string Maquina { get; set; }
        public string Funcionario { get; set; }
        public System.DateTime Data { get; set; }
        public bool Concluida { get; set; }

    }

}
