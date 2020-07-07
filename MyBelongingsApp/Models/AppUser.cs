using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBelongingsApp.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            MyTasks = new HashSet<MyTasks>();
        }

        public virtual ICollection<MyTasks> MyTasks { get; set; }
    }
}