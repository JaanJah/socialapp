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
        ImageView likeButton;

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
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);

            view.FindViewById<TextView>(Resource.Id.userName).Text = items[position].Owner;
            view.FindViewById<TextView>(Resource.Id.userMessage).Text = items[position].Message;
            view.FindViewById<TextView>(Resource.Id.msgComments).Text = items[position].Comments + " Comments";

            var likes = view.FindViewById<TextView>(Resource.Id.msgLikes);
            likes.Text = items[position].Likes.ToString() + " Likes";

            likeButton = view.FindViewById<ImageButton>(Resource.Id.msgLikeIcon);
            likeButton.Click += (sender, e) => LikeButton_Click(position, likes);

            var picture = view.FindViewById<ImageView>(Resource.Id.msgPicture);
            if (items[position].MessagePicture != "")
            {
                picture.SetImageResource(context.Resources.GetIdentifier(items[position].MessagePicture, "drawable", context.PackageName));
                picture.Visibility = ViewStates.Visible;
            }

            return view;
            
        }

        private void LikeButton_Click(int pos, TextView likes)
        {
            int curLikes = items[pos].Likes;

            if (items[pos].Liked)
            {
                curLikes--;
            }

            else
            {
                curLikes++;
            }

            items[pos].Liked = !items[pos].Liked;
            items[pos].Likes = curLikes;

            likes.Text = curLikes + " Likes";

        }
    }
}