using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class UserToDoList : Base
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public int ToDoListId { get; set; }
        public ToDoLists? ToDoList { get; set; }
    }
}
