using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace socialapp
{
    [Activity(Label = "CommentsActivity")]
    public class CommentsActivity : Activity
    {
        Button cmtSubmitBtn;
        ListView cmtList;
        EditText cmtInputText;
        List<CommentProperties> comments;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CommentsActivity);
            //Define Widgets
            cmtSubmitBtn = FindViewById<Button>(Resource.Id.cmtSubmitBtn);
            cmtList = FindViewById<ListView>(Resource.Id.cmtListView);
            cmtInputText = FindViewById<EditText>(Resource.Id.cmtInputText);
            //Get intents from CustomRow
            comments = JsonConvert.DeserializeObject<List<CommentProperties>>(Intent.GetStringExtra("Comments"));
            int position = Intent.GetIntExtra("MessagePosition", -1);

            //Add new comment button
            cmtSubmitBtn.Click += CmtSubmitBtn_Click;
            cmtSubmitBtn.Tag = position;
            cmtList.Adapter = new CommentsAdapter(this, comments, position);
        }

        private void CmtSubmitBtn_Click(object sender, EventArgs e)
        {
            var commentBtn = (Button)sender;
            int position = (int)commentBtn.Tag;

            MainActivity.posts[position].Comments.Add(new CommentProperties
            {
                Owner = "User",
                Message = cmtInputText.Text,
                Likes = 0
            });
            cmtInputText.Text = "";
            cmtList.Adapter = new CommentsAdapter(this, MainActivity.posts[position].Comments, position);
        }
    }
}