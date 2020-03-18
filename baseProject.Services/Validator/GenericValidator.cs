using BaseProject.Domain.Entities;
using FluentValidation;
using System;

namespace BaseProject.Services.Validator
{
    public class GenericValidator<T> : AbstractValidator<T> where T : BaseEntity
    {
        public GenericValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Não é possível salvar um objeto vazio.");
                    });
        }
    }
}
