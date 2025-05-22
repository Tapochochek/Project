using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Data
{
    public class Medicament
    {
        [Key]
        public int  id_Medicament { get; set; }

        public string? nameMedicament { get; set; }
        public bool medicamentOnRecept { get; set; }
        public string? healthEffect { get; set; }
        public int priceMedicament { get; set; }
    }
}
