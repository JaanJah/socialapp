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
    class CommentsAdapter : BaseAdapter<CommentProperties>
    {
        List<CommentProperties> items;
        Activity context;
        ImageView likeButton;

        public CommentsAdapter(Activity context, List<CommentProperties> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override CommentProperties this[int position]
        {
            get { return items[position]; }
        }

        public override int Count { get { return items.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.CommentsRow, null);
            }

            view.FindViewById<ImageView>(Resource.Id.userIcon);
            view.FindViewById<TextView>(Resource.Id.userName);
            view.FindViewById<TextView>(Resource.Id.userCommentMsg);
            view.FindViewById<ImageView>(Resource.Id.msgLikeIcon);
            view.FindViewById<TextView>(Resource.Id.msgComments);
            return view;

        }
    }
}