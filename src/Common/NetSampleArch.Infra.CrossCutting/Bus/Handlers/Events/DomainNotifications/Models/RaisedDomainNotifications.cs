
using System.Collections.Generic;
using System.Linq;
using NetSampleArch.Infra.CrossCutting.Bus.Events;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Enums;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Interfaces;

namespace NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Models
{
    public class RaisedDomainNotifications
        : IRaisedDomainNotifications
    {
        // Attributes
        public List<DomainNotification> DomainNotificationEventCollection { get; }

        public RaisedDomainNotifications()
        {
            DomainNotificationEventCollection = new List<DomainNotification>();
        }

        // Properties
        public IEnumerable<DomainNotification> AllDomainNotificationEventCollection => DomainNotificationEventCollection.AsEnumerable();
        public IEnumerable<DomainNotification> InfoDomainNotificationEventCollection => DomainNotificationEventCollection.Where(q => q.NotificationTypeCode == NotificationType.Info);
        public IEnumerable<DomainNotification> WarningDomainNotificationEventCollection => DomainNotificationEventCollection.Where(q => q.NotificationTypeCode == NotificationType.Warning);
        public IEnumerable<DomainNotification> ErrorDomainNotificationEventCollection => DomainNotificationEventCollection.Where(q => q.NotificationTypeCode == NotificationType.Error);

        public bool HasDomainNotificationEvents => AllDomainNotificationEventCollection.Any();
        public bool HasInfoDomainNotificationEvents => InfoDomainNotificationEventCollection.Any();
        public bool HasWarningDomainNotificationEvents => WarningDomainNotificationEventCollection.Any();
        public bool HasErrorDomainNotificationEvents => ErrorDomainNotificationEventCollection.Any();

        public ValidationStatus ValidationStatus
        {
            get
            {
                var validationStatus = default(ValidationStatus);

                if (!DomainNotificationEventCollection.Any())
                    validationStatus = ValidationStatus.Success;
                else if (DomainNotificationEventCollection.All(q => q.NotificationTypeCode == NotificationType.Error))
                    validationStatus = ValidationStatus.Error;
                else if (DomainNotificationEventCollection.Any(q => q.NotificationTypeCode == NotificationType.Error))
                    validationStatus = ValidationStatus.Partial;
                else
                    validationStatus = ValidationStatus.Success;

                return validationStatus;
            }
        }
        public bool IsSuccess => ValidationStatus == ValidationStatus.Success;

        // Methods
        public void AddValidationMessage(NotificationType messageType, string source, string code)
        {
            DomainNotificationEventCollection.Add(new DomainNotification
            (
                notificationType: messageType,
                code: code,
                source: source
            ));
        }
        public void AddInfoValidationMessage(string source, string code)
        {
            AddValidationMessage(NotificationType.Info, source, code);
        }
        public void AddWarningValidationMessage(string source, string code)
        {
            AddValidationMessage(NotificationType.Warning, source, code);
        }
        public void AddErrorValidationMessage(string source, string code)
        {
            AddValidationMessage(NotificationType.Error, source, code);
        }
    }
}
