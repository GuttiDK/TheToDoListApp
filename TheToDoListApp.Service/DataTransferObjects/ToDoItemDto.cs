using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTodoService.Enums;
using TheToDoListApp.Repository.Enums;

namespace TheToDoListApp.Service.DataTransferObjects
{
    public class ToDoItemDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? FinishedTime { get; set; } = default;
        [MaxLength(25)]
        public string? TaskDescription { get; set; }
        public PrioryEnum Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
