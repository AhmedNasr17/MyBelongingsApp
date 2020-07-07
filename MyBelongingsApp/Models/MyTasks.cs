using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBelongingsApp.Models
{
    public partial class MyTasks
    {
        public int MyTaskId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string MeantDay { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }
        public string ImgName { get; set; }
        public bool isDone { get; set; }

    }
}