using BaseProject.Domain.Entities;
using System.Linq;

namespace BaseProject.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Save(T obj);

        void Update(T obj);

        void Delete(T obj);

        T Get(int id);

        IQueryable<T> GetAll();
    }
}
