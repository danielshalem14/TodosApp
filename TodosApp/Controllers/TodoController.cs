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

        public IActionResult ToggleIsCompleted(int id)
        {
            Todo? todoFromDb = Data.Get.Todos.FirstOrDefault(todo => todo.Id == id);

            if (todoFromDb == null)
            {
                return NotFound();
            }

            todoFromDb.IsCompleted = !todoFromDb.IsCompleted;
            Data.Get.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteTodo(int id)
        {
            Todo? todoFromDb = Data.Get.Todos.FirstOrDefault(todo => todo.Id == id);

            if (todoFromDb == null)
            {
                return NotFound();
            }

            Data.Get.Todos.Remove(todoFromDb);
            Data.Get.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
