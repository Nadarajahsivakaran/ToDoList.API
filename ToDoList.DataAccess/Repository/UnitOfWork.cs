using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.IRepository;

namespace ToDoList.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; private set; }

        public IToDoListRepository ToDoList { get; private set; }

        public IUserToDoListRepository UserToDoList { get; private set; }

        public ITaskRepository Task { get; private set; }


        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            User = new UserRepository(applicationDbContext);
            ToDoList = new ToDoListRepository(applicationDbContext);
            UserToDoList = new UserToDoListRepository(applicationDbContext);
            Task = new TaskRepository(applicationDbContext);
        }
    }
}
