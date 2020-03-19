using BaseProject.Domain.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace BaseProject.Infra.Data.Mapping
{
    public class UsuarioMap : ClassMapping<Usuario>
    {
        public UsuarioMap()
        {
            Schema("portal_seguranca");
            Table("usuario");

            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Increment);
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.UnsavedValue(0);
            });

            Property(b => b.Nome, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.Column("nome");
                x.NotNullable(true);
            });

            Property(b => b.Cpf, x =>
            {
                x.Length(14);
                x.Type(NHibernateUtil.String);
                x.Column("cpf");
                x.NotNullable(true);
            });

            Property(b => b.DataNascimento, x =>
            {
                x.Type(NHibernateUtil.Date);
                x.Column("data_nascimento");
                x.NotNullable(true);
            });

            Property(b => b.Senha, x =>
            {
                x.Length(25);
                x.Type(NHibernateUtil.String);
                x.Column("senha");
                x.NotNullable(true);
            });
        }
    }
}
