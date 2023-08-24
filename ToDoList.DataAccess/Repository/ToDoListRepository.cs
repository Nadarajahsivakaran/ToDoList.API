using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.IRepository;
using ToDoList.Models;

namespace ToDoList.DataAccess.Repository
{
    public class ToDoListRepository : GenericRepository<ToDoLists>, IToDoListRepository
    {
        public ToDoListRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
