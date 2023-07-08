using Reminder.DL.GenericRepository;
using Reminder.DL.IRepositories;
using Reminder.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.DL.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        private readonly ReminderDbContext _reminderDbContext;

        public UsersRepository(ReminderDbContext reminderDbContext) : base(reminderDbContext)
        {
            this._reminderDbContext = reminderDbContext;
        }
    }
}
