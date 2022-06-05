using System;

using Xamarin.Forms;

namespace CMSAPP.Viwes
{
    public class MyButton : Button
    {
        public MyButton()
        {

        }

        public string ActivityStatus
        {

            get
            {
                return (string)GetValue(ActivityStatusProperty);
            }
            set
            {
                SetValue(ActivityStatusProperty, value);
            }
        }

        public static readonly BindableProperty ActivityStatusProperty = BindableProperty.Create(
            propertyName: "ActivityStatus",
            returnType: typeof(string),
            declaringType: typeof(MyButton),
            defaultValue: "default"
            );

        public string RoomName
        {
            get
            {
                return (string)GetValue(RoomNameProperty);
            }
            set
            {
                SetValue(RoomNameProperty, value);
            }

        }

        public static readonly BindableProperty RoomNameProperty = BindableProperty.Create(
            propertyName: "RoomName",
            returnType: typeof(string),
            declaringType: typeof(MyButton),
            defaultValue: "default"
            );

        public string PassactivityId
        {
            get
            {
                return (string)GetValue(PassactivityIdProperty);
            }
            set
            {
                SetValue(PassactivityIdProperty, value);
            }
        }
        public static readonly BindableProperty PassactivityIdProperty = BindableProperty.Create(
            propertyName: "PassactivityId",
            returnType: typeof(string),
            declaringType: typeof(MyButton),
            defaultValue: "1000000008");



        public string PassactivityName
        {
            get
            {
                return (string)GetValue(PassactivityNameProperty);
            }
            set
            {
                SetValue(PassactivityNameProperty, value);
            }
        }
        public static readonly BindableProperty PassactivityNameProperty = BindableProperty.Create(
            propertyName: "PassactivityName",
            returnType: typeof(string),
            declaringType: typeof(MyButton),
            defaultValue: "12");


        public string PassstartTime
        {
            get
            {
                return (string)GetValue(PassstartTimeProperty);
            }
            set
            {
                SetValue(PassstartTimeProperty, value);
            }
        }


        public static readonly BindableProperty PassstartTimeProperty = BindableProperty.Create(
            propertyName: "PassstartTime",
            returnType: typeof(string),
            declaringType: typeof(MyButton),
            defaultValue: "2023-05-30 08:00:00");

        public int Passduration
        {
            get
            {
                return (int)GetValue(PassdurationProperty);
            }
            set
            {
                SetValue(PassdurationProperty, value);
            }
        }
        public static readonly BindableProperty PassdurationProperty = BindableProperty.Create(
            propertyName: "Passduration",
            returnType: typeof(int),
            declaringType: typeof(MyButton),
            defaultValue: 60);

        public string PassactivityDescription
        {
            get
            {
                return (string)GetValue(PassactivityDescriptionProperty);
            }
            set
            {
                SetValue(PassactivityDescriptionProperty, value);
            }
        }
        public static readonly BindableProperty PassactivityDescriptionProperty = BindableProperty.Create(
            propertyName: "PassactivityDescription",
            returnType: typeof(string),
            declaringType: typeof(MyButton),
            defaultValue: "2233");


        public string PassuserName
        {
            get
            {
                return (string)GetValue(PassuserNameProperty);
            }
            set
            {
                SetValue(PassuserNameProperty, value);
            }
        }

        public static readonly BindableProperty PassuserNameProperty = BindableProperty.Create(
            propertyName: "PassuserName",
            returnType: typeof(string),
            declaringType: typeof(MyButton),
            defaultValue: "徐满心");


        public string PasspoliticalReview
        {
            get
            {
                return (string)GetValue(PasspoliticalReviewProperty);
            }
            set
            {
                SetValue(PasspoliticalReviewProperty, value);
            }
        }
        public static readonly BindableProperty PasspoliticalReviewProperty = BindableProperty.Create(
            propertyName: "PasspoliticalReview",
            returnType: typeof(string),
            declaringType: typeof(MyButton),
            defaultValue: "default");

        public int PasspoliticallyRelevant
        {
            get
            {
                return (int)GetValue(PasspoliticallyRelevantProperty);
            }
            set
            {

                SetValue(PasspoliticallyRelevantProperty, value);
            }
        }
        public static readonly BindableProperty PasspoliticallyRelevantProperty = BindableProperty.Create(
            propertyName: "PasspoliticallyRelevant",
            returnType: typeof(int),
            declaringType: typeof(MyButton),
            defaultValue: 0);


        public string Passreason
        {
            get
            {
                return (string)GetValue(PassreasonProperty);
            }
            set
            {
                SetValue(PassreasonProperty, value);
            }
        }
        public static readonly BindableProperty PassreasonProperty = BindableProperty.Create(
            propertyName: "Passreason",
            returnType: typeof(string),
            declaringType: typeof(MyButton),
            defaultValue: "冲突");


        public string PassroomId
        {
            get
            {
                return (string)GetValue(PassroomIdProperty);
            }
            set
            {
                SetValue(PassroomIdProperty, value);
            }
        }
        public static readonly BindableProperty PassroomIdProperty = BindableProperty.Create(
            propertyName: "PassroomId",
            returnType: typeof(string),
            declaringType: typeof(MyButton),
            defaultValue: "0000000001");
    }
}


