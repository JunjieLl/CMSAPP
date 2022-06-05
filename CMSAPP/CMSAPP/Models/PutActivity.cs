using System;
namespace CMSAPP.Models
{
	public class PutActivity
	{
		public PutActivity()
		{
		}

        public string activityId { get; set; }

        public string activityName { get; set; }

        public string activityStatus { get; set; }

        public string startTime { get; set; }

        public int duration { get; set; }

        public string activityDescription { get; set; }

        public int politicallyRelevant { get; set; }

        public string roomId { get; set; }

        public string commonUserId { get; set; }

        public string reason { get; set; }
    }
}

