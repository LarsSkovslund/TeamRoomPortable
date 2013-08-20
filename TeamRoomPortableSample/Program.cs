using System;
using System.Linq;
using System.Threading.Tasks;
using TeamRoomPortable;
using TeamRoomPortable.Chat;
using TeamRoomPortable.Notification;

namespace TeamRoomPortableSample
{
    class Program
    {
        static void Main()
        {
            var t = new Sample();
            t.QueryMessagesFromTeamRoom().Wait();

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }

    public class Sample
    {
        public async Task<ITeamRoomClient> GetClient()
        {
            return await TeamRoomClientFactory.Create(
                 "{Team Foundation Service Account}", 
                 "{Alternative Credentials - User name (secondary)}", 
                 "{password}"
             );
        }

        public async Task ManageTeamRooms()
        {
            var client = await GetClient();

            var newTeamRoom = await client.CreateTeamRoomAsync("MyNewRoom", null);
            await client.DeleteTeamRoomAsync(newTeamRoom);            
        }

        public async Task QueryMessagesFromTeamRoom()
        {
            var client = await GetClient();
            var myTeamRoom = await client.GetTeamRoomAsync("{TEAM ROOM NAME GOES HERE}");
            var roomSession = await client.Join(myTeamRoom);

            // Get todays messages
            var messages = await roomSession.GetMessagesAsync();
            foreach (var message in messages)
            {
                switch (message.MessageType)
                {
                    case MessageType.Normal:
                        var postedBy = roomSession.Members.FirstOrDefault(m => m.Id == message.PostedByUserTfid);
                        if (postedBy != null)
                            Console.WriteLine("Posted by: {0}", postedBy.DisplayName);
                        else // This will most likely be TFS service accounts identity.
                            Console.WriteLine("Posted by: unknown identity {0}", message.PostedByUserTfid);
                        DisplayChatMessage(message.ConvertMessageTo<string>());
                        break;

                    case MessageType.Notification:
                        DisplayNotificationMessage(message.ConvertMessageTo<NotificationMessage>());
                        break;

                    case MessageType.System:
                        DisplaySystemMessage(message.ConvertMessageTo<string>());
                        break;
                }
            }

            // Post a message to the room.
            await roomSession.PostMessageAsync("I did it!");
        }

        private static void DisplaySystemMessage(Message<string> message)
        {
            Console.WriteLine("System message: {0}", message.Content);
        }

        private static void DisplayNotificationMessage(Message<NotificationMessage> message)
        {
            Console.WriteLine("Notification of type: {0}", message.Content.Type);
            switch (message.Content.Type)
            {
                case MessageNotificationType.BuildCompletedEvent:
                    var build = message.Content.ToNotificationType<BuildCompletedEventData>();
                    Console.WriteLine("Build number: {0}", build.BuildNumber);
                    break;

                case MessageNotificationType.CheckinEvent:
                    var checkin = message.Content.ToNotificationType<CheckinEventData>();
                    Console.WriteLine("Checkin comment: {0}", checkin.Comment);
                    break;

                case MessageNotificationType.CodeReviewChangedEvent:
                    var review = message.Content.ToNotificationType<CodeReviewChangedEventData>();
                    Console.WriteLine("Code review requestor: {0}", review.Requestor);
                    break;

                case MessageNotificationType.WorkItemChangedEvent:
                    var workItem = message.Content.ToNotificationType<WorkItemChangedEventData>();
                    Console.WriteLine("WorkItem title: {0}", workItem.Title);
                    break;
            }
        }

        private static void DisplayChatMessage(Message<string> message)
        {
            Console.WriteLine("Chat message: {0}", message.Content);
        }
    }
}
