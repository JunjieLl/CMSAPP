using System;
namespace CMSAPP.Models
{
    public class Favorite
    {
        public string userId { get; set; }


        public string roomId { get; set; }

        public Favorite(string roomId,string userId)
        {
            this.roomId = roomId;
            this.userId = userId;
        }
    }
}

