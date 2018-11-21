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
        public static List<Properties> posts;
        public static List<CommentProperties> comments;

        EditText inputText;
        Button addPostBtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //Define listView
            list = FindViewById<ListView>(Resource.Id.listView1);
            

            //Define fields
            inputText = FindViewById<EditText>(Resource.Id.mainInputText);
            addPostBtn = FindViewById<Button>(Resource.Id.mainSubmitBtn);

            //Add default posts
            var posts = new List<Properties>();
            var comments = new List<CommentProperties>();
            var post = new Properties
            {
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi vitae sem nibh. Aliquam in ornare tellus. Aenean vel luctus metus. Fusce turpis est, euismod at hendrerit at, mollis rhoncus sem. Morbi mauris odio, fermentum non massa et, semper consectetur enim. Nulla ornare a urna pellentesque aliquam. In accumsan arcu vitae turpis malesuada, vel molestie est venenatis.",
                Owner = "Jaan Markus",
                Likes = 5,
                Comments = comments,
                MessagePicture = "picture1"
            };
            posts.Add(post);
            var comment = new CommentProperties
            {
                Owner = "Jaan Markus",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi vitae sem nibh. Aliquam in ornare tellus. Aenean vel luctus metus. Fusce turpis est, euismod at hendrerit at, mollis rhoncus sem. Morbi mauris odio, fermentum non massa et, semper consectetur enim. Nulla ornare a urna pellentesque aliquam. In accumsan arcu vitae turpis malesuada, vel molestie est venenatis.",
                Likes = 4
            };
            comments.Add(comment);
            post = new Properties
            {
                Message = "Hello friends!",
                Owner = "Kert",
                Likes = 2,
                Comments = comments,
                MessagePicture = "picture2"
            };
            posts.Add(post);
            comments = new List<CommentProperties>();
            comment = new CommentProperties
            {
                Owner = "Markus",
                Message = "Lahe!",
                Likes = 51
            };
            comments.Add(comment);
            post = new Properties
            {
                Message = "I love fortnite OMGGGG",
                Owner = "Virko // MemeKing69",
                Likes = 1337,
                Comments = comments,
                MessagePicture = "fortnitedance"
            };
            posts.Add(post);
            comments = new List<CommentProperties>();
            comment = new CommentProperties
            {
                Owner = "Jaan",
                Message = "See on kommentaar",
                Likes = 2
            };
            comments.Add(comment);
            //Define lists adapter
            list.Adapter = new CustomAdapter(this, posts);
            addPostBtn.Click += AddPostBtn_Click;
        }

        private void AddPostBtn_Click(object sender, System.EventArgs e)
        {
            posts.Add(new Properties
            {
                Owner = "User",
                Message = inputText.Text,
                Likes = 0,
                Comments = new List<CommentProperties>(),
                MessagePicture = ""
            });
            inputText.Text = "";
            list.Adapter = new CustomAdapter(this, posts);
        }
    }
}