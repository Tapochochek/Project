using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Data
{
    public class Client
    {
        
        public int id_Client { get; set; }
        
        [Key]
        public string? fioClient { get; set; }

        [MaxLength(1)]
        public string? gender { get; set; }

        public int ageClient { get; set; }

        [MaxLength(11)]
        public string? phoneNumber { get; set; }

        public bool hasRecept { get; set; }
    }
}
