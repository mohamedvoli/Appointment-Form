using Microsoft.EntityFrameworkCore;

namespace Appointment_form.Models.Repo_s
{
    public class AppointmentRepo : IAppointmentRepo<Appointment>
    {
        protected AppointementDbContext db;

        public AppointmentRepo(AppointementDbContext _db)
        {
               db = _db;
        }
        public void create(Appointment entity)
        {
            db.Appointments.Add(entity);
            Commit();
        }

        public void Delete(Appointment appointment)
        {
            db.Appointments.Remove(appointment);
            Commit();   
        }

        public IList<Appointment> List()
        {
           var ApponitmentList =  db.Appointments.ToList();
            return ApponitmentList;
        }
        public void Commit() 
        {
            db.SaveChanges();
        }

        public Appointment Find(int id)
        {
            var appointment = db.Appointments.SingleOrDefault(s => s.Id == id);
            return appointment;
        }
    }
}
