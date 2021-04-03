using NetSampleArch.Domain.Entities.Interfaces;
using NetSampleArch.Domain.Specifications;
using NetSampleArch.Infra.CrossCutting.Validators;

namespace NetSampleArch.Domain.Validators
{
     public class EntityValidator<TEntity>
        : ValidatorBase<TEntity>
        where TEntity : IEntity
    {
        protected void AddSpecificationsForEntityCreation(IEntitySpecification<TEntity> entitySpecifications)
        {
            entitySpecifications.AddRuleIdIsRequired(this);
            entitySpecifications.AddRuleMustHaveCreationInfo(this);
            entitySpecifications.AddRuleMustHaveRowVersion(this);
        }
        protected void AddSpecificationsForEntityUpdate(IEntitySpecification<TEntity> entitySpecifications)
        {
            AddSpecificationsForEntityCreation(entitySpecifications);
            entitySpecifications.AddRuleMustHaveUpdateInfo(this);
        }
    }
}