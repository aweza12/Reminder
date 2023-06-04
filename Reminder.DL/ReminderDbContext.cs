using Microsoft.EntityFrameworkCore;
using Reminder.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DL
{
    public class ReminderDbContext : DbContext
    {
        public ReminderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    }
}
