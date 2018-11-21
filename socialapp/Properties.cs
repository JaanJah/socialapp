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
    public class Properties
    {
        public string Message { get; set; } = " ";
        public string Owner { get; set; } = " ";
        public int Likes { get; set; }
        public bool IsLiked { get; set; } = false;
        public List<CommentProperties> Comments { get; set; }
        public string Date { get; set; } = " ";
        public string MessagePicture { get; set; } = " ";
    }
}