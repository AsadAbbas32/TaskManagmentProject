using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementWebAPI.Enum;
using TaskManagementWebAPI.Models;
using Task = TaskManagementWebAPI.Models.Task;

namespace TaskManagementWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private sakilaContext _context;
        public TaskController(sakilaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return Ok(_context.Task.ToArray());
        }
        public IActionResult getUsers(bool includeAdmins=false)
        {
            if(includeAdmins)
            {
                return Ok(_context.User.ToArray());
            }
            return Ok(_context.User.Where(x=>x.Usertype==(int)UserType.Supervisor).ToArray());
        }
        public IActionResult getStatusesList()
        {
            var ss = System.Enum.GetNames(typeof(statuses)).ToList();
            return Ok(ss);
        }
        public IActionResult updateStatus(int TaskId,int statusId)
        {
            Task tsk;
            tsk = _context.Task.Where(x => x.Id == TaskId).FirstOrDefault();
            tsk.Statusid = statusId;
            _context.Task.Update(tsk);
            _context.SaveChanges();
            return Ok(tsk);
        }
        public IActionResult getAllTasks(int? id)
        {
            Task[] tsk;
            if(id.HasValue)
            {
                tsk = _context.Task.Where(x=>x.UserId==id).ToArray();
            }
            else
            {
                tsk = _context.Task.ToArray();
            }
           
            foreach (var item in tsk)
            {
               item.Username = _context.User.Where(x => x.Id == item.UserId).Select(x=>x.Displayname).FirstOrDefault();
            }
                return Ok(tsk);
          
        }
        public IActionResult deleteTask(int TaskId)
        {
            var task = new Task{ Id = TaskId };
            _context.Task.Attach(task);
            _context.Task.Remove(task);
            _context.SaveChanges();
            var ss = _context.Task.ToArray();
            foreach (var item in ss)
            {
                item.Username = _context.User.Where(x => x.Id == item.UserId).Select(x => x.Displayname).FirstOrDefault();
            }
            return Ok(ss);

        }
        [HttpPost]

        public IActionResult createTask([FromBody]Task task)
        {
            _context.Task.Add(task);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult login([FromBody] User user)
        {
            var ss = _context.User.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
            
            return Ok(ss);
        }

    }
}