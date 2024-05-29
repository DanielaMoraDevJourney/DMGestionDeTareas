using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DMGestionDeTareas.Models;

    public class DMGestionDeTareasContext : DbContext
    {
        public DMGestionDeTareasContext (DbContextOptions<DMGestionDeTareasContext> options)
            : base(options)
        {
        }

        public DbSet<DMGestionDeTareas.Models.DMCategoria> DMCategoria { get; set; } = default!;
    }
