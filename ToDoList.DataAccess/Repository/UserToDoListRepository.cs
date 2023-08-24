using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.IRepository;
using ToDoList.Models;

namespace ToDoList.DataAccess.Repository
{
    public class UserToDoListRepository : GenericRepository<UserToDoList>, IUserToDoListRepository
    {
        public UserToDoListRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
