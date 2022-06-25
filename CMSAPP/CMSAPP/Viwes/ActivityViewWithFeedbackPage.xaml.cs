using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CMSAPP.Viwes
{
    [QueryProperty(nameof(PassActivityId), "PassactivityId")]
    [QueryProperty(nameof(PassActivityName), "PassactivityName")]
    [QueryProperty(nameof(PassStartTime), "PassstartTime")]
    [QueryProperty(nameof(PassDuration), "Passduration")]
    [QueryProperty(nameof(PassActivityDescription), "PassactivityDescription")]
    [QueryProperty(nameof(PassUserName), "PassuserName")]
    [QueryProperty(nameof(PassPoliticalReview), "PasspoliticalReview")]
    [QueryProperty(nameof(PassPoliticallyRelevant), "PasspoliticallyRelevant")]
    [QueryProperty(nameof(PassReason), "Passreason")]
    [QueryProperty(nameof(PassRoomId), "PassroomId")]//不需要
    [QueryProperty(nameof(PassRoomName), "PassroomName")]
    [QueryProperty(nameof(PassActivityStatus), "PassactivityStatus")]
    [QueryProperty(nameof(PassFeeedBack), "Passfeedback")]
    public partial class ActivityViewWithFeedbackPage : ContentPage
    {
        
        public ActivityViewWithFeedbackPage()
        {
            InitializeComponent();
        }

        //pass data begin
        public string Passfeedback = "default";
        public string PassactivityStatus = "default";
        public string PassroomName = "default";
        public string PassactivityId = "1000000008";
        public string PassactivityName = "12";
        public string PassstartTime = "2023-05-30 08:00:00";
        public int Passduration = 60;
        public string PassactivityDescription = "2233";
        public string PassuserName = "徐满心";
        public string PasspoliticalReview = "default";
        public int PasspoliticallyRelevant = 0;
        public string Passreason = "冲突";
        public string PassroomId = "0000000001";

        public string PassFeeedBack
        {
            get
            {
                return Passfeedback;
            }
            set
            {
                Passfeedback = value;
                VFeedback.Text = value;
                if (PassactivityStatus.Equals("已反馈")) {
                    feedBackLabel.Text = "反馈";
                }
                else if (PassactivityStatus.Equals("被驳回")){
                    feedBackLabel.Text = "驳回原因";
                }
            }
        }

        public string PassActivityStatus
        {
            get
            {
                return PassactivityStatus;
            }
            set
            {
                PassactivityStatus = value;
                if (value.Equals("待反馈")||value.Equals("已反馈"))
                {
                    reasonOrcancelLabel.Text = "修改原因";
                }
                else if (value.Equals("已取消"))
                {
                    reasonOrcancelLabel.Text = "取消原因";
                }
            }
        }


        public string PassRoomName
        {
            get
            {
                return PassroomName;
            }
            set
            {
                PassroomName = value;
                spacePicker.Items.Add(value);
                spacePicker.SelectedIndex = 0;
            }
        }

        public string PassRoomId
        {
            get
            {
                return PassroomId;
            }
            set
            {
                PassroomId = value;
            }
        }
        public string PassActivityId
        {
            get
            {
                return PassactivityId;
            }
            set
            {
                PassactivityId = value;
            }
        }
        public string PassActivityName
        {
            get
            {
                return PassactivityName;
            }
            set
            {
                PassactivityName = value;
                VActNam.Text = PassactivityName;
            }
        }
        public string PassStartTime
        {
            get
            {
                return PassstartTime;
            }
            set
            {
                PassstartTime = value;
                datePicker.Date = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            }
        }

        public DateTime originStartTime { get; set; }
        public DateTime originEndTime { get; set; }

        public int PassDuration
        {
            get
            {
                return Passduration;
            }
            set
            {
                Passduration = value;
                DateTime t = DateTime.ParseExact(PassstartTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                DateTime t0 = DateTime.ParseExact(t.ToString("yyyy-MM-dd"), "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                VStTime.Time = t - t0;
                VEndTime.Time = (t - t0) + TimeSpan.FromMinutes(Passduration);

            }
        }
        public string PassActivityDescription
        {
            get
            {
                return PassactivityDescription;
            }
            set
            {
                PassactivityDescription = value;
                VDesc.Text = value;

            }
        }
        public string PassUserName
        {
            get
            {
                return PassuserName;
            }
            set
            {
                PassuserName = value;
                chargerEntry.Text = value;
            }
        }
        public string PassPoliticalReview
        {
            get
            {
                return PasspoliticalReview;
            }
            set
            {
                PasspoliticalReview = value;
            }
        }
        public int PassPoliticallyRelevant
        {
            get
            {
                return PasspoliticallyRelevant;
            }
            set
            {
                PasspoliticallyRelevant = value;
                if (value == 1)
                {
                    VIsPoli.IsChecked = true;
                    VIsNotPoli.IsChecked = false;
                }
                else
                {
                    VIsPoli.IsChecked = false;
                    VIsNotPoli.IsChecked = true;
                }
            }
        }
        public string PassReason
        {
            get
            {
                return Passreason;
            }
            set
            {
                Passreason = value;
                VReason.Text = value;
            }
        }
        //pass end

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

    }
}

