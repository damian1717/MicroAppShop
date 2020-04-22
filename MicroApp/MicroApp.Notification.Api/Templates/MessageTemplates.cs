namespace MicroApp.Notification.Api.Templates
{
    public static class MessageTemplates
    {
        public static string ProductAddedSubject => "Product {0} has been created.";
        public static string ProductAddedBody => @"
            Hi,
            Your product id: {0} has been created. We will inform you about its status changes.

            Best regards,
            Product Team";
    }
}
