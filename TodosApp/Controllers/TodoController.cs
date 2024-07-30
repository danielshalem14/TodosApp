using Microsoft.AspNetCore.Mvc;
using TodosApp.Models;
using TodosApp.DAL;
using Microsoft.EntityFrameworkCore;

namespace TodosApp.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            List<Todo> todos = Data.Get.Todos.Include(todo => todo.Teammate).ToList();
            return View(todos);
        }
    }
}
