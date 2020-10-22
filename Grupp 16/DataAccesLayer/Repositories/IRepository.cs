namespace DataAccesLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Ny(T podcast);
        void Spara(int index);
        void TaBort(int index, T entity);
    }
}
