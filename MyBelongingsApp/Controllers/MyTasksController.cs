using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBelongingsApp.Models;
using MyBelongingsApp.Repositories;

namespace MyBelongingsApp.Controllers
{
    public class MyTasksController : Controller
    {
        private readonly MyBelongingsAppDBContext _context;

        private readonly UserManager<AppUser> _user;

        IMyTasksRepository _myTasks;
        public MyTasksController(MyBelongingsAppDBContext context, UserManager<AppUser> user, IMyTasksRepository myTasks)
        {
            _context = context;
            _user = user;
            _myTasks = myTasks;
        }

        // GET: MyTasks
        public IActionResult Index()
        {
            return View(_myTasks.GetTasks());
        }

        // GET: MyTasks/Details/5
        public IActionResult Details(int id)
        {
            if (id.Equals(null))
            {
                return NotFound();
            }

            var myTask = _myTasks.GetTask(id);
            if (myTask == null)
            {
                return NotFound();
            }

            return View(myTask);
        }

        //GET: MyTasks/Done
        public IActionResult TaskDone(int id)
        {
            if (id.Equals(null))
            {
                return NotFound();
            }

            var myTask = _myTasks.GetTask(id);
            myTask.isDone = true;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: MyTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyTasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MyTaskId,UserId,Text,MeantDay,StartTime,DeadLine,ImgName")] MyTasks myTask, IFormFile Pic)
        {
            if (Pic == null)
            {
                myTask.ImgName = "task.png";
            }

            else
            {

                string fileExt = Path.GetExtension(Pic.FileName);

                string fileName = myTask.MyTaskId.ToString() + fileExt;

                string pathToSave = "wwwroot/images/TasksImgs/" + fileName;


                using (var stream = System.IO.File.Open(pathToSave, FileMode.Create))
                {
                    Pic.CopyToAsync(stream);

                    myTask.ImgName = fileName;

                    stream.Close();
                }

            }

            if (ModelState.IsValid)
            {
                _myTasks.AddTask(myTask);

                return RedirectToAction(nameof(Index));
            }

            return View(myTask);
        }

        // GET: MyTasks/Edit/5
        public IActionResult Edit(int id)
        {
            if (id.Equals(null))
            {
                return NotFound();
            }

            var myTask = _myTasks.GetTask(id);

            if (myTask == null)
            {
                return NotFound();
            }

            return View(myTask);
        }

        // POST: MyTasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("MyTaskId,UserId,Text,MeantDay,StartTime,DeadLine,ImgName")] MyTasks myTask, IFormFile newPic)
        {
            if (newPic == null)
            {
                myTask.ImgName = "task.png";
            }

            else
            {

                string fileExt = Path.GetExtension(newPic.FileName);

                string fileName = myTask.MyTaskId.ToString() + fileExt;

                string pathToSave = "wwwroot/images/TasksImgs/" + fileName;


                using (var stream = System.IO.File.Open(pathToSave, FileMode.Create))
                {
                    newPic.CopyToAsync(stream);

                    myTask.ImgName = fileName;

                    stream.Close();
                }

            }

            if (id != myTask.MyTaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _myTasks.UpdateTask(myTask);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyTasksExists(myTask.MyTaskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(myTask);
        }

        // GET: MyTasks/Delete/5
        public IActionResult Delete(int id)
        {
            if (id.Equals(null))
            {
                return NotFound();
            }

            var myTask = _myTasks.GetTask(id);
            if (myTask == null)
            {
                return NotFound();
            }

            return View(myTask);
        }

        // POST: MyTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _myTasks.DeleteTask(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MyTasksExists(int id)
        {
            return _context.MyTasks.Any(e => e.MyTaskId == id);
        }
    }
}
