using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Agenda_Telefonica.Models;

    public class AgendaTelefonicaDbContext : DbContext
    {
        public AgendaTelefonicaDbContext (DbContextOptions<AgendaTelefonicaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Agenda_Telefonica.Models.ListaTelefonica> ListaTelefonica { get; set; } = default!;
    }
