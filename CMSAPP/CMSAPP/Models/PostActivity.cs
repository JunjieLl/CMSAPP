using System;
namespace CMSAPP.Models
{
    public class PostActivity
    {

        public string activityDescription { get; set; } = "test";
        public string activityName { get; set; } = "test";
        public string activityStatus { get; set; } = "待举办";
        public string commonUserId { get; set; } = "1953474";
        public int duration { get; set; } = 50;
        public int politicallyRelevant { get; set; } = 0;
        public string roomId { get; set; } = "0000000001";
        public string startTime { get; set; } = "2022-06-04 12:00:00";

        public PostActivity()
        {
        }
    }
}

