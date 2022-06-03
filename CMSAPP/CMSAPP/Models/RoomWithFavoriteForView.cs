using System;
namespace CMSAPP.Models
{
	public class RoomWithFavoriteForView
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
        public string favoriteImage { get; set; } = "favorite.png";

        public RoomWithFavoriteForView(RoomWithFavorite roomWithFavorite)
		{
            roomId = roomWithFavorite.roomId;
            roomName = roomWithFavorite.roomName;
            building = roomWithFavorite.building;
            floor = roomWithFavorite.floor;
            roomDescription = roomWithFavorite.roomDescription;
            capacity = roomWithFavorite.capacity;
            image = roomWithFavorite.image;
            state = roomWithFavorite.state;
            favorite = roomWithFavorite.favorite;
            favoriteImage = favorite ? "favorite.png" : "favorite-2.png";
        }
	}
}
