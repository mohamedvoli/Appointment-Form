using Microsoft.EntityFrameworkCore;

namespace Appointment_form.Models
{
    public class AppointementDbContext:DbContext
    {
        public AppointementDbContext(DbContextOptions<AppointementDbContext> options) : base(options)
        {

        }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
