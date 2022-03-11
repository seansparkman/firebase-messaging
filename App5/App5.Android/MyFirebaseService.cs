using Android.App;
using AndroidX.Core.App;
using Firebase.Messaging;
using Plugin.LocalNotifications;
using Xamarin.Essentials;

namespace App5.Droid
{
    [Service(Name = "com.westnet.Android.MyFirebaseMessagingService", Exported = false)]
    [IntentFilter(new[]
    {
        "com.google.firebase.MESSAGING_EVENT",
        "com.google.firebase.INSTANCE_ID_EVENT"
    })]
    [MetaData("com.google.firebase.messaging.default_notification_icon",
        Resource = "@drawable/xamarin_logo")]
    [MetaData("com.google.firebase.messaging.default_notification_color",
        Value = "#FF4081")]
    [MetaData("com.google.firebase.messaging.default_notification_channel_id",
        Value = "my_notification_channel")]
    public class MyFirebaseService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage parameter)
        {
            var notification = parameter.GetNotification();
            System.Console.WriteLine($"Message received: {notification.Title}: {notification.Body}");
            Preferences.Set("Title", notification.Title);
            Preferences.Set("Body", notification.Body);

            SendNotification(parameter);
        }

        public override void OnDeletedMessages()
        {
            System.Console.WriteLine("Message deleted");
        }

        public override void OnNewToken(string token)
        {
            System.Console.WriteLine($"New Token: {token}");
        }

        private void SendNotification(RemoteMessage message)
        {
            var notification = message.GetNotification();
            // Build the notification:
            var builder = new NotificationCompat.Builder(this, "my_notification_channel")
                .SetAutoCancel(true) // Dismiss the notification from the notification area when the user clicks on it
                .SetContentTitle(notification.Title) // Set the title
                .SetSmallIcon(Resource.Drawable.xamarin_logo) // This is the icon to display
                .SetContentText(notification.Body); // the message to display.

            // Finally, publish the notification:
            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(0, builder.Build());
        }
    }
}