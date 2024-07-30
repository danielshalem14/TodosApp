using System.ComponentModel.DataAnnotations;

namespace TodosApp.Models
{
    public class Teammate
    {
        public Teammate()
        {
            TodoList = new List<Todo>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Team mate name")]
        public string Name { get; set; }

        public List<Todo> TodoList { get; set; }

        public void AddTodo(string todoTitle)
        {
            Todo newTodo = new Todo { Title = todoTitle, Teammate = this };
            TodoList.Add(newTodo);
        }


    }
}
