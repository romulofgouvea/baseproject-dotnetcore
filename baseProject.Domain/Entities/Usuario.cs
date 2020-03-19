using BaseProject.Domain.Models;
using System;

namespace BaseProject.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual DateTime DataNascimento { get; set; }

        public virtual string Senha { get; set; }

        public virtual MUsuario ToModel()
        {
            return new MUsuario
            {
                Nome = Nome,
                Cpf = Cpf,
                DataNascimento = DataNascimento,
                Senha = Senha
            };
        }
    }
}
