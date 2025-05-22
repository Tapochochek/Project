using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Data
{
    public class JobTitle
    {
        [Key]
        public int id_JobTitle { get; set; }
        public string? nameJobTitle { get; set; }
        public int seylary { get; set; }
    }
}
