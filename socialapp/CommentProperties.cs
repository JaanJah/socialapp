﻿using System;
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
    public class CommentProperties
    {
        public string Message { get; set; } = " ";
        public string Owner { get; set; } = " ";
        public int Likes { get; set; }
        public bool IsLiked { get; set; } = false;
        public string Date { get; set; } = " ";
    }
}