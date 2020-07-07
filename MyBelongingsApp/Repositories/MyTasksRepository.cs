using MyBelongingsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBelongingsApp.Repositories
{
    public interface IMyTasksRepository
    {
        IEnumerable<MyTasks> GetTasks();
        void AddTask(MyTasks task);
        void UpdateTask(MyTasks task);
        MyTasks GetTask(int id);
        void DeleteTask(int id);
    }
    public class MyTasksRepository : IMyTasksRepository
    {
        readonly private MyBelongingsAppDBContext _context = new MyBelongingsAppDBContext(); 

        public void AddTask(MyTasks task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.MyTasks.Find(id);
            _context.Remove(task);
            _context.SaveChanges();
        }

        public MyTasks GetTask(int id)
        {
            var task = _context.MyTasks.Find(id);
            return task;
        }

        public IEnumerable<MyTasks> GetTasks()
        {
            return _context.MyTasks.ToList();
        }

        public void UpdateTask(MyTasks task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }
    }
}
