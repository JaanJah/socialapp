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
using Java.Lang;

namespace socialapp
{
    class CustomAdapter : BaseAdapter<Properties>
    {
        List<Properties> items;
        Activity context;
        ImageButton likeBtn;

        public CustomAdapter(Activity context, List<Properties> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override Properties this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);
            }
            //Username
            view.FindViewById<TextView>(Resource.Id.userName).Text = items[position].Owner;
            //User's Message
            view.FindViewById<TextView>(Resource.Id.userMessage).Text = items[position].Message;
            //Post's comment amount
            view.FindViewById<TextView>(Resource.Id.msgComments).Text = items[position].Comments + " Comments";
            //Post's picture
            var picture = view.FindViewById<ImageView>(Resource.Id.msgPicture);
            if (items[position].MessagePicture != "")
            {
                picture.SetImageResource(context.Resources.GetIdentifier(items[position].MessagePicture, "drawable", context.PackageName));
                picture.Visibility = ViewStates.Visible;
            }
            //Post's likes amount
            view.FindViewById<TextView>(Resource.Id.msgLikes).Text = items[position].Likes + " Likes";
            //Like button
            likeBtn = view.FindViewById<ImageButton>(Resource.Id.msgLikeIcon);
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

            MainActivity.properties[position].Likes = items[position].Likes;
            items[position].IsLiked = !items[position].IsLiked;

            MainActivity.properties[position].IsLiked = items[position].IsLiked;
            NotifyDataSetChanged();
        }
    }
}               