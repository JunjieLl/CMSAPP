using System;
namespace CMSAPP.Models
{
    public class DeleteActivity
    {
        public DeleteActivity()
        {
        }

        public String recordId { get; set; }

        public String activityId { get; set; }

        public String userId { get; set; }


        public string modifyTime { get; set; }

        public String reason { get; set; }
    }
}

