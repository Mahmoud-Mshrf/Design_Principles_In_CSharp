namespace TightlyCoupling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var notification = new Notification();
            notification.SendNotification("Hello World");

        }
    }
    class SmsSender
    {
        public void SendSms(string message)
        {
            // send sms
            Console.WriteLine("Send sms");
        }
    }
    class EmailSender
    {
        public void SendEmail(string message)
        {
            // send email
            Console.WriteLine("Send email");
        }
    }
    class Notification
    {
        private readonly SmsSender _smsSender;
        private readonly EmailSender _emailSender;
        public Notification()
        {
            _smsSender = new SmsSender();
            _emailSender = new EmailSender();
        }
        public void SendNotification(string message)
        {
            _smsSender.SendSms(message);
            _emailSender.SendEmail(message);
        }
    }
    // The Notification class is tightly coupled with the SmsSender and EmailSender classes.
    // If we want to change the SmsSender or EmailSender class, we need to change the Notification class.
    // This is not a good design because it violates the Open/Closed principle.
    // The Open/Closed principle states that a class should be open for extension but closed for modification.
    // In other words, we should be able to add new functionality to a class without changing its existing code.
    // In this case, if we want to add a new way of sending notifications, we need to change the Notification class.
}
