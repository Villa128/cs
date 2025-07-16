using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ContactsService
    {
        private readonly DbContext _context;

        public ContactsService(DbContext context)
        {
            _context = context;
        }

        // public DbContext Context => _context;

        
    }




}
