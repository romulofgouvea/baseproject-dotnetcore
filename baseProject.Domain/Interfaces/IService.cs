using BaseProject.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace BaseProject.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Save<V>(T obj) where V : AbstractValidator<T>;

        T Update<V>(T obj) where V : AbstractValidator<T>;

        void Delete(int id);

        T Get(int id);

        IList<T> GetAll();
    }
}
