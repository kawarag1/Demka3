using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demka3.Models;

namespace Demka3.Services
{
    public class Helper
    {
        public static Deemka3Entities _context;

        public static Deemka3Entities GetContext()
        {
            if (_context == null)
            {
                _context = new Deemka3Entities();
            }
            return _context;
        }
    }
}
