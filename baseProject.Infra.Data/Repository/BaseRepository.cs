using BaseProject.Domain.Entities;
using BaseProject.Domain.Interfaces;
using NHibernate;
using System.Linq;

namespace BaseProject.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ISession Sessao;
        public BaseRepository(ISession sessao)
        {
            Sessao = sessao;
        }

        public void Save(T obj)
        {
            Sessao.Save(obj);
        }

        public void Update(T obj)
        {
            Sessao.Update(obj);
        }

        public void Delete(T obj)
        {
            Sessao.Delete(obj);
        }

        public T Get(int id)
        {
            return GetAll().FirstOrDefault(o => o.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return Sessao.Query<T>();
        }
    }
}
