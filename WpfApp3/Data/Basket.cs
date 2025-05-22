using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Data
{
    public class Basket
    {
        [Key]
        public int id_Basket { get; set; }
        public int id_Medicament { get; set; }
        public string? fioClient { get; set; }
        public int countMedicament { get; set; }

        [ForeignKey("id_Medicament")]
        public Medicament? Medicaments { get; set; }

        [ForeignKey("fioClient")]
        public Client? Client { get; set; }

    }
}
