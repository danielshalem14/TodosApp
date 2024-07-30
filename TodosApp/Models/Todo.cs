using System.ComponentModel.DataAnnotations;

namespace TodosApp.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Todo text")]
        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        public Teammate Teammate { get; set; }
    }
}
