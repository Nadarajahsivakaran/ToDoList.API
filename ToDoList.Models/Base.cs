using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}