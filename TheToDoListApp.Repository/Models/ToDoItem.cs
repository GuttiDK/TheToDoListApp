using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheToDoListApp.Repository.Enums;

namespace TheToDoListApp.Repository.Models
{
    public class ToDoItem
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public DateTime? FinishedTime { get; set; }
        [MaxLength(25)]
        public string? TaskDescription { get; set; }
        [DefaultValue(PrioryEnum.Normal)]
        public PrioryEnum Priority { get; set; }
        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
    }
}
