using BaseProject.Domain.Entities;
using BaseProject.Domain.Interfaces;
using BaseProject.Infra.Data.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace BaseProject.Services.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository = new BaseRepository<T>();

        public T Save<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Save(obj);
            return obj;
        }

        public T Update<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser 0.");

            repository.Delete(id);
        }

        public IList<T> GetAll()
        {
            return repository.GetAll();
        }

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser 0.");

            return repository.Get(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros inválidos.");

            validator.ValidateAndThrow(obj);
        }
    }
}
