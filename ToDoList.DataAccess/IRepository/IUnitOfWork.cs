using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataAccess.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; } 
        IToDoListRepository ToDoList { get; }
        IUserToDoListRepository UserToDoList { get; }
        ITaskRepository Task { get; }
    }
}
