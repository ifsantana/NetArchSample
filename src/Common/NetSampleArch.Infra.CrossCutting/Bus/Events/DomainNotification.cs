using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;

namespace NetSampleArch.Infra.CrossCutting.Bus.Events
{
    public class DomainNotification : IEvent
    {
        public NotificationType NotificationTypeCode { get; }
        public string NotificationTypeName => NotificationTypeCode.ToString();
        public string Source { get; }
        public string Code { get; }

        public DomainNotification(
            NotificationType notificationType,
            string source,
            string code
        )
        {
            NotificationTypeCode = notificationType;
            Source = source;
            Code = code;
        }
    }
}