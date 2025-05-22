using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Data
{
    public class Employee
    {
        [Key]
        public int id_Employee { get; set; }
        public string? fioEmployee { get; set; }

        [MaxLength(1)]
        public string? gender { get; set; }

        public int id_JobTitle { get; set; }
        [ForeignKey("id_JobTitle")]
        public JobTitle? JobTitle { get; set; }
    }
}
