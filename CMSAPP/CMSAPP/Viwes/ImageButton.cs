using System;

using Xamarin.Forms;

namespace CMSAPP.Viwes
{
    public class MyImageButton : ImageButton
    {
        public static readonly BindableProperty RoomIdProperty = BindableProperty.Create(
            propertyName: "RoomId",
            returnType: typeof(string),
            declaringType: typeof(MyImageButton),
            defaultValue: "0000000001");

        public string RoomId
        {
            get
            {
                return (string)GetValue(RoomIdProperty);
            }
            set
            {
                SetValue(RoomIdProperty, value);
            }
        }

        public bool IsFavo
        {
            get
            {
                return (bool)GetValue(IsFavoProperty);
            }
            set
            {
                SetValue(IsFavoProperty, value);
            }
        }

        public static readonly BindableProperty IsFavoProperty = BindableProperty.Create(
            propertyName: "IsFavo",
            returnType: typeof(bool),
            declaringType: typeof(MyImageButton),
            defaultValue: true);


        public MyImageButton()
        {

        }
    }
}


