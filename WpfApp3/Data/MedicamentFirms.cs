using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Data
{
    public class MedicamentFirms
    {
        [Key]
        public int id_Firms { get; set; }

        public string? nameFirms { get; set; }
        public string? countryPlace { get; set; }

        public int id_Medicament { get; set; }

        [ForeignKey("id_Medicament")]
        public Medicament? Medicaments { get; set; }
    }
}
