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

namespace socialapp
{
    [Activity(Label = "CommentsActivity")]
    public class CommentsActivity : Activity
    {
        Button cmtSubmitBtn;
        ListView cmtList;
        EditText cmtInputText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CommentsActivity);
            cmtSubmitBtn = FindViewById<Button>(Resource.Id.commentSubmitBtn);
            // Create your application here
        }
    }
}