using System;
namespace CMSAPP.Models
{
    public class RoomWithFavorite
    {
        public string roomId { get; set; } = "";
        public string roomName { get; set; } = "";
        public string building { get; set; } = "";
        public string floor { get; set; } = "";
        public string roomDescription { get; set; } = "";
        public int capacity { get; set; } = 1;
        public string image { get; set; } = "https://tjsegof.club/images/room/0000000001.png";
        public string state { get; set; } = "";
        public bool favorite { get; set; } = true;

        public RoomWithFavorite()
        {
        }
    }
}

