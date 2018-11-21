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
        ImageButton likeBtn;
        //postPosition = messagePosition
        int postPosition;
        public CommentsAdapter(Activity context, List<CommentProperties> items, int postPosition) : base()
        {
            this.context = context;
            this.items = items;
            this.postPosition = postPosition;
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

            view.FindViewById<ImageView>(Resource.Id.cUserIcon);
            view.FindViewById<TextView>(Resource.Id.cUserName).Text = items[position].Owner;
            view.FindViewById<TextView>(Resource.Id.cUserCommentMsg).Text = items[position].Message;
            view.FindViewById<TextView>(Resource.Id.cMsgLikes);

            likeBtn = view.FindViewById<ImageButton>(Resource.Id.cMsgLikeIcon);
            likeBtn.Tag = position;
            likeBtn.Click -= LikeBtn_Click;
            likeBtn.Click += LikeBtn_Click;
            return view;

        }

        private void LikeBtn_Click(object sender, EventArgs e)
        {
            var likeBtnClicked = (ImageButton)sender;
            int position = (int)likeBtnClicked.Tag;

            if (!items[position].IsLiked)
            {
                items[position].Likes++;
            }
            else
            {
                items[position].Likes--;
            }

            MainActivity.posts[postPosition].Likes = items[position].Likes;
            items[position].IsLiked = !items[position].IsLiked;

            MainActivity.posts[postPosition].IsLiked = items[position].IsLiked;
            NotifyDataSetChanged();
        }
    }
}