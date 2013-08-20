using System.Threading.Tasks;

namespace TeamRoomPortable
{
    public class TeamRoomClientFactory
    {
        public static async Task<ITeamRoomClient> Create(string account, string userName, string password)
        {
            var client = new TeamRoomClient(account, userName, password);
            await client.Initialize();

            return client;
        }
    }
}