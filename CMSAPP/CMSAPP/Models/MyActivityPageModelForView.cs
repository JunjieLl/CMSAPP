using System;
namespace CMSAPP.Models
{
    public class MyActivityPageModelForView
    {
        public string activityDescription { get; set; } = "2233";
        public string activityId { get; set; } = "1000000008";
        public string activityName { get; set; } = "12";
        public string activityStatus { get; set; } = "已取消";
        public string building { get; set; } = "济事楼";
        public string commonUserId { get; set; } = "1953474";
        public string content { get; set; } = "default";
        public int duration { get; set; } = 60;
        public string evaluateTime { get; set; } = "default";
        public string floor { get; set; } = "4";
        public string image { get; set; } = "https://tjsegof.club/images/room/0000000001.png";
        public string managerUserId { get; set; } = "default";
        public string politicalReview { get; set; } = "default";
        public int politicallyRelevant { get; set; } = 0;
        public string reason { get; set; } = "冲突";
        public string roomId { get; set; } = "0000000001";
        public string roomName { get; set; } = "济事楼430";
        public string startTime { get; set; } = "2023-05-30 08:00:00";
        public string userName { get; set; } = "徐满心";

        public string showStartTime { get; set; }
        public string showStartDate { get; set; }

        public MyActivityPageModelForView(MyActivityPageModel myActivityPageModel)
        {
            activityDescription = myActivityPageModel.activityDescription;
            activityId = myActivityPageModel.activityId;
            activityName = myActivityPageModel.activityName;
            activityStatus = myActivityPageModel.activityStatus;
            building = myActivityPageModel.building;
            commonUserId = myActivityPageModel.commonUserId;
            content = myActivityPageModel.content;
            duration = myActivityPageModel.duration;
            evaluateTime = myActivityPageModel.evaluateTime;
            floor = myActivityPageModel.floor;
            image = myActivityPageModel.image;
            managerUserId = myActivityPageModel.managerUserId;
            politicalReview = myActivityPageModel.politicalReview;
            politicallyRelevant = myActivityPageModel.politicallyRelevant;
            reason = myActivityPageModel.reason;
            roomId = myActivityPageModel.roomId;
            roomName = myActivityPageModel.roomName;
            startTime = myActivityPageModel.startTime;
            userName = myActivityPageModel.userName;

            string[] arr = startTime.Split(' ');
            showStartDate = arr[0];
            showStartTime = arr[1];
        }

        public MyActivityPageModelForView()
        {
        }
    }
}

