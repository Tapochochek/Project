using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Data
{
    public class Storage
    {
        [Key]
        public int id_MedicamentPosition { get; set; }

        public int id_Medicament { get; set; }

        public int countOnStorage { get; set; }

        [ForeignKey("id_Medicament")]
        public Medicament? Medicaments { get; set; }
    }
}
