using System;
using FluentValidation;
using NetSampleArch.Domain.Entities.Interfaces;

namespace NetSampleArch.Domain.Specifications
{
    public class EntitySpecification<TEntity>
        : IEntitySpecification<TEntity>
        where TEntity : IEntity
    {
        public static string ID_IS_REQUIRED_MESSAGE = "Id is required";

        public static string CREATED_AT_IS_REQUIRED_MESSAGE = "CreatedAt is required";
        public static string CREATED_AT_MUST_HAVE_VALID_LENGTH_MESSAGE = "CreatedAt must be less than current date";
        public static string CREATED_BY_IS_REQUIRED_MESSAGE = "CreatedBy is required";
        public static string CREATED_BY_HAVE_VALID_LENGTH_MESSAGE = "CreatedBy length must be between 1 and 150";

        public static string UPDATED_AT_IS_REQUIRED_MESSAGE = "CreatedAt is required";
        public static string UPDATED_AT_MUST_HAVE_VALID_LENGTH_MESSAGE = "CreatedAt must be less than current date";
        public static string UPDATED_BY_IS_REQUIRED_MESSAGE = "CreatedBy is required";
        public static string UPDATED_BY_MUST_HAVE_VALID_LENGTH_MESSAGE = "CreatedBy length must be between 1 and 150";

        public static string ROW_VERSION_IS_REQUIRED_MESSAGE = "RowVersion is required";

        public void AddRuleIdIsRequired(AbstractValidator<TEntity> validator)
        {
            validator.RuleFor(entity => entity.Id)
                .Must(q => q != Guid.Empty).WithMessage(ID_IS_REQUIRED_MESSAGE);
        }
        public void AddRuleMustHaveCreationInfo(AbstractValidator<TEntity> validator)
        {
            validator.RuleFor(entity => entity.CreatedAt)
                .GreaterThan(q => default).WithMessage(CREATED_AT_IS_REQUIRED_MESSAGE);

            validator.RuleFor(entity => entity.CreatedAt)
                .Must(q => q <= DateTime.UtcNow).WithMessage(CREATED_AT_MUST_HAVE_VALID_LENGTH_MESSAGE)
                .When(q => q.CreatedAt != default);

            validator.RuleFor(entity => entity.CreatedBy)
                .Must(q => !string.IsNullOrWhiteSpace(q)).WithMessage(CREATED_BY_IS_REQUIRED_MESSAGE);

            validator.RuleFor(entity => entity.CreatedBy)
                .Must(q => q.Length <= 150).WithMessage(CREATED_BY_HAVE_VALID_LENGTH_MESSAGE)
                .When(q => !string.IsNullOrWhiteSpace(q.CreatedBy));
        }
        public void AddRuleMustHaveUpdateInfo(AbstractValidator<TEntity> validator)
        {
            validator.RuleFor(entity => entity.UpdatedAt)
                .GreaterThan(q => default).WithMessage(UPDATED_AT_IS_REQUIRED_MESSAGE);

            validator.RuleFor(entity => entity.UpdatedAt)
                .Must(q => q <= DateTime.UtcNow).WithMessage(UPDATED_AT_MUST_HAVE_VALID_LENGTH_MESSAGE)
                .When(q => q.UpdatedAt != default);

            validator.RuleFor(entity => entity.UpdatedBy)
                .Must(q => !string.IsNullOrWhiteSpace(q)).WithMessage(UPDATED_BY_IS_REQUIRED_MESSAGE);

            validator.RuleFor(entity => entity.UpdatedBy)
                .Must(q => q.Length <= 150).WithMessage(UPDATED_BY_MUST_HAVE_VALID_LENGTH_MESSAGE)
                .When(q => !string.IsNullOrWhiteSpace(q.UpdatedBy));
        }
        public void AddRuleMustHaveRowVersion(AbstractValidator<TEntity> validator)
        {
            validator.RuleFor(entity => entity.RowVersion)
                .GreaterThan(q => TimeSpan.MinValue).WithMessage(ROW_VERSION_IS_REQUIRED_MESSAGE);
        }
    }
}