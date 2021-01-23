using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace WebDiabloMvc.Models
{
    public class Personaje
    {
        public int Persj_Id { get; set; }
        public string Persj_Nombre { get; set; }
        public int Cls_Id { get; set; }
        public Clase Clase { get; set; }
        public int Persj_Lvl { get; set; }
        public int Persj_Xp { get; set; }
        public int Persj_HP { get; set; }
        public int Persj_Mp { get; set; }
    }
}
