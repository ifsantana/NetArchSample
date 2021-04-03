using FluentValidation;
using NetSampleArch.Domain.Entities.Interfaces;
using NetSampleArch.Infra.CrossCutting.Specification;

namespace NetSampleArch.Domain.Specifications
{
     public interface IEntitySpecification<TEntity>
        : ISpecification<TEntity>
        where TEntity : IEntity
    {
        void AddRuleIdIsRequired(AbstractValidator<TEntity> validator);
        void AddRuleMustHaveCreationInfo(AbstractValidator<TEntity> validator);
        void AddRuleMustHaveRowVersion(AbstractValidator<TEntity> validator);
        void AddRuleMustHaveUpdateInfo(AbstractValidator<TEntity> validator);
    }
}