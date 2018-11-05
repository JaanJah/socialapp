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
        Button submitBtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CommentsActivity);
            submitBtn = FindViewById<Button>(Resource.Id.submitBtn);
            // Create your application here
        }
    }
}