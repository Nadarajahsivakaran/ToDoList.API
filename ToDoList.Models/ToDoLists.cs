using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ToDoLists : Base
    {
        [Required, StringLength(30)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public ICollection<UserToDoList>? UserToDoList { get; set; }

        public ICollection<Tasks>? Tasks { get; set; }
    }
}
