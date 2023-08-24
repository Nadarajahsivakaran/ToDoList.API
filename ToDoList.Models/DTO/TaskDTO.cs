using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models.DTO
{
    public class TaskDTO
    {
        [Required, StringLength(30)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Date), Required]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date), Required]
        public DateTime EndDate { get; set; }

        [Required]
        public TaskStatus Status { get; set; }

        [Required]
        public int ToDoListsId { get; set; }
    }
}
