using FluentValidation;
using FluentValidation.Results;
using NetSampleArch.Infra.CrossCutting.Bus.Events;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using Serilog;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Domain.Services
{
    public abstract class BaseService
    {
		protected ILogger Logger { get; }
		protected IBus Bus { get; }

		protected BaseService(ILogger logger, IBus bus)
		{
			Logger = logger;
			Bus = bus;
		}

		private static NotificationType GetNotificationMessageType(Severity severity)
		{
			return severity switch
			{
				Severity.Error => NotificationType.Error,
				Severity.Warning => NotificationType.Warning,
				Severity.Info => NotificationType.Info,
				_ => NotificationType.Info
			};
		}

		protected async Task<bool> CheckValidationResultAndSendDomainNotificationsAsync(string source, ValidationResult[] validationResultArray, CancellationToken cancellationToken)
		{
			var isValid = !validationResultArray.Any(
				validationResult => validationResult.Errors.Any(
					validationFailure => validationFailure.Severity == Severity.Error
				)
			);

			foreach (var validationResult in validationResultArray)
				foreach (var validationFailure in validationResult.Errors)
					await Bus.SendEventAsync(
						new DomainNotification(
							notificationType: GetNotificationMessageType(validationFailure.Severity),
							source: source,
							code: validationFailure.ErrorMessage
						),
						cancellationToken
					).ConfigureAwait(false);

			return isValid;
		}

		protected async Task<bool> CheckObjectIsNullAndSendDomainNotificationsAsync<T>(T @object, CancellationToken cancellationToken, [CallerMemberName] string source = null)
		{

			if (@object is null)
			{
				await Bus.SendEventAsync(
					new DomainNotification(
						notificationType: NotificationType.Error,
						source: source,
						code: $"Object cannot be null [{typeof(T).Name.ToUpper()}​​​​]"
					),
					cancellationToken
				).ConfigureAwait(false);

				return false;

			}
			return true;
		}
	}
}
