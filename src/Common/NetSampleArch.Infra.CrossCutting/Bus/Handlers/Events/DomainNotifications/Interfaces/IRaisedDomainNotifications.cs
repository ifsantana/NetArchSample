
using System.Collections.Generic;
using NetSampleArch.Infra.CrossCutting.Bus.Events;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Enums;

namespace NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Interfaces
{
    public interface IRaisedDomainNotifications
    {
        List<DomainNotification> DomainNotificationEventCollection { get; }
        IEnumerable<DomainNotification> AllDomainNotificationEventCollection { get; }
        IEnumerable<DomainNotification> InfoDomainNotificationEventCollection { get; }
        IEnumerable<DomainNotification> WarningDomainNotificationEventCollection { get; }
        IEnumerable<DomainNotification> ErrorDomainNotificationEventCollection { get; }
        bool HasDomainNotificationEvents { get; }
        bool HasInfoDomainNotificationEvents { get; }
        bool HasWarningDomainNotificationEvents { get; }
        bool HasErrorDomainNotificationEvents { get; }
        ValidationStatus ValidationStatus { get; }
        bool IsSuccess { get; }

        void AddErrorValidationMessage(string source, string code);
        void AddInfoValidationMessage(string source, string code);
        void AddValidationMessage(NotificationType messageType, string source, string code);
        void AddWarningValidationMessage(string source, string code);
    }
}
