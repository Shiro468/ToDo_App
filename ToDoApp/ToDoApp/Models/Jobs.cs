using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace ToDoApp.Models
{
    public class Jobs
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime FinishTime { get; set; }

    }
}