using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOLLibrary.Models
{
    public class User
    {

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [StringLength(300)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string AvatarPath { get; set; }

    }
}
