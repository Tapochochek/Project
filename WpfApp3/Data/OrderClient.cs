using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Data
{
    public class OrderClient
    {
        [Key]
        public int id_Order { get; set; }
        public DateTime dateOrder { get; set; }
        public int id_Basket { get; set; }
        public int id_Employee { get; set; }

        [ForeignKey("id_Basket")]
        public Basket? Basket { get; set; }

        [ForeignKey("id_Employee")]
        public Employee? Employee { get; set; }
    }
}
