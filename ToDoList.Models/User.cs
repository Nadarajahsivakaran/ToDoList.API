using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Enum;

namespace ToDoList.Models
{
    public class User : Base
    {
        [Required,StringLength(30)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public Gender Gender { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public ICollection<UserToDoList>? UserToDoList { get; set; }
    }
}
