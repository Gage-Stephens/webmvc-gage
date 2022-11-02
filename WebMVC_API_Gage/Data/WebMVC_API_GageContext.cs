using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMVC_API_Gage.Models;

namespace WebMVC_API_Gage.Data
{
    public class WebMVC_API_GageContext : DbContext
    {
        public WebMVC_API_GageContext (DbContextOptions<WebMVC_API_GageContext> options)
            : base(options)
        {
        }

        public DbSet<WebMVC_API_Gage.Models.Character> Character { get; set; } = default!;
    }
}
