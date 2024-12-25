namespace LooselyCoupling
{
    internal class Program
    {
        // In this lesson, we will create a NotificationFactory class that will create instances of the INotificationSender interface.
        // We will create a SmsSender and EmailSender class that will implement the INotificationSender interface.
        // We will create a NotificationService class that will send notifications using the INotificationSender interface.
        // We will create a NotificationType enum that will define the types of notifications.
        // We will create a NotificationFactory class that will create instances of the INotificationSender interface based on the NotificationType enum.
        // We will create a NotificationService class that will send notifications using the INotificationSender interface.

        static void Main(string[] args)
        {
            var notificationFactory = new NotificationFactory();
            var smsNotification = notificationFactory.CreateNotificationSender(NotificationType.Sms);
            var emailNotification = notificationFactory.CreateNotificationSender(NotificationType.Email);
            var smsSender = new NotificationService(smsNotification);
            var emailSender = new NotificationService(emailNotification);
            smsSender.SendNotification();
            emailSender.SendNotification();
        }
    }
    enum NotificationType
    {
        Sms,
        Email
    }
    class NotificationFactory
    {
        public INotificationSender CreateNotificationSender(NotificationType notificationType)
        {
            switch (notificationType)
            {
                case NotificationType.Sms:
                    return new SmsSender();
                case NotificationType.Email:
                    return new EmailSender();
                default:
                    return new EmailSender();// default to email
            }
        }
    }// The NotificationFactory class is responsible for creating instances of the INotificationSender interface.
    interface INotificationSender
    {
        void SendNotification();
    }
    class SmsSender : INotificationSender
    {
        public void SendNotification()
        {
            // send sms
            Console.WriteLine("Send sms");
        }
    }
    class EmailSender : INotificationSender
    {
        public void SendNotification()
        {
            // send email
            Console.WriteLine("Send email");
        }
    }
    class NotificationService
    {
        private readonly INotificationSender _notificationSender;
        public NotificationService(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }
        public void SendNotification()
        {
            _notificationSender.SendNotification();
        }
    }
    // The Notification class is now loosely coupled with the SmsSender and EmailSender classes.
    // We can easily add new ways of sending notifications without changing the Notification class.
    // This is a good design because it follows the Open/Closed principle.
    // The Open/Closed principle states that a class should be open for extension but closed for modification.
    // In other words, we should be able to add new functionality to a class without changing its existing code.

}
