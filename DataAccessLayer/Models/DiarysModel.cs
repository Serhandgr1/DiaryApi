using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Metods
{
    public class DiarysModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
    }
}
