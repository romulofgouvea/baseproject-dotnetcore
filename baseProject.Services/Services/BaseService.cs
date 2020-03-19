using BaseProject.Domain.Entities;
using BaseProject.Domain.Interfaces;
using BaseProject.Infra.Data.Repository;
using FluentValidation;
using NHibernate;
using System;
using System.Linq;

namespace BaseProject.Services.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly BaseRepository<T> Repository;
        public BaseService(ISession sessao)
        {
            Repository = new BaseRepository<T>(sessao);
        }

        public T Save<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            Repository.Save(obj);
            return obj;
        }

        public T Update<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            Repository.Update(obj);
            return obj;
        }

        public void Delete(T obj)
        {
            if (obj == null || obj.Id == 0)
                throw new ArgumentException("Objeto inválido.");
            Repository.Delete(obj);
        }

        public IQueryable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser 0.");

            return Repository.Get(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros inválidos.");

            validator.ValidateAndThrow(obj);
        }
    }
}
