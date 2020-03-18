using BaseProject.Domain.Entities;
using System.Collections.Generic;

namespace BaseProject.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Save(T obj);

        void Update(T obj);

        void Delete(int id);

        T Get(int id);

        IList<T> GetAll();
    }
}
