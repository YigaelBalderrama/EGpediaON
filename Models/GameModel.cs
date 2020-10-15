using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace EGpediaON.Models
{
    public class GameModel
    {
        public int Id{ get; set; }
        [Required]
        [StringLength(15,
         ErrorMessage ="Error {0} the max lenght of name is 15 min lenght is 2",MinimumLength =2)]
        public string Name { get; set; }
        [DataType (DataType.Date)]
        public DateTime? Lauchdate { get; set; }
        [Range(1000, 100000000,
         ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Numberofplayers { get; set; }
        public string? Company { get; set; }

    }
}
