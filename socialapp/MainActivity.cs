using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;

namespace socialapp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView list;
        List<Properties> properties;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            list = FindViewById<ListView>(Resource.Id.listView1);
            properties = new List<Properties>
            {
                //New post.
                new Properties
                {
                    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi vitae sem nibh. Aliquam in ornare tellus. Aenean vel luctus metus. Fusce turpis est, euismod at hendrerit at, mollis rhoncus sem. Morbi mauris odio, fermentum non massa et, semper consectetur enim. Nulla ornare a urna pellentesque aliquam. In accumsan arcu vitae turpis malesuada, vel molestie est venenatis.",
                    Owner = "Jaan Markus",
                    Likes = 5,
                    Comments = 5,
                    MessagePicture = "picture1"
                },
                new Properties
                {
                    Message = "Message2",
                    Owner = "Kert",
                    Likes = 2,
                    Comments = 1,
                    MessagePicture = "picture2"
                },
                new Properties
                {
                    Message = "I love fortnite OMGGGG",
                    Owner = "Virko // MemeKing69",
                    Likes = 1337,
                    Comments = 420,
                    MessagePicture = "fortnitedance"
                },
            };
            List<int> images = new List<int>();
            list.Adapter = new CustomAdapter(this, properties);
        }

    }
}