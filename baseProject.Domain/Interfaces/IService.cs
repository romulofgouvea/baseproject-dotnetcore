using BaseProject.Domain.Entities;
using FluentValidation;
using System.Linq;

namespace BaseProject.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Save<V>(T obj) where V : AbstractValidator<T>;

        T Update<V>(T obj) where V : AbstractValidator<T>;

        void Delete(T obj);

        T Get(int id);

        IQueryable<T> GetAll();
    }
}
