namespace Appointment_form.Models.Repo_s
{
    public interface IAppointmentRepo<TEntity>
    {
        public IList<TEntity> List();
        public void create(TEntity entity);
        public void Delete(TEntity entity);
        public void Commit();
        public TEntity Find(int id);
    }
}
