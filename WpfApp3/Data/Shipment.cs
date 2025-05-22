using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Data
{
    public class Shipment
    {
        [Key]
        public int id_Shipment { get; set; }
        public int id_Medicament { get; set; }
        public int id_Firms { get; set; }
        public int id_Employee { get; set; }
        public DateTime dateShipment { get; set; }

        [ForeignKey("id_Medicament")]
        public Medicament? Medicaments { get; set; }

        [ForeignKey("id_Firms")]
        public MedicamentFirms? MedicamentFirms { get; set; }

        [ForeignKey("id_Employee")]
        public Employee? Employee { get; set; }

    }
}
