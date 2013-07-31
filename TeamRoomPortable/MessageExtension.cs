using Newtonsoft.Json;
using TeamRoomPortable.Chat;
using TeamRoomPortable.Notification;

namespace TeamRoomPortable
{
    public static class MessageExtension
    {
        /// <summary>
        /// Converts basic Message object to a typed instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Message<T> ConvertMessageTo<T>(this Message<object> msg) where T : class
        {
            return new Message<T>
            {
                Id = msg.Id,
                Content = typeof(T) == typeof(string)
                    ? msg.Content as T
                    : JsonConvert.DeserializeObject<T>(msg.Content.ToString()),
                MessageType = msg.MessageType,
                PostedByUserTfid = msg.PostedByUserTfid,
                PostedRoomId = msg.PostedRoomId,
                PostedTime = msg.PostedTime
            };
        }

        public static T ToNotificationType<T>(this NotificationMessage msg)
        {
            return JsonConvert.DeserializeObject<T>(msg.Data.ToString());
        }
    }
}
