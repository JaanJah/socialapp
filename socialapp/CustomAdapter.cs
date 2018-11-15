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
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);
            }
            //MainActivity stuff
            view.FindViewById<TextView>(Resource.Id.userName).Text = items[position].Owner;
            view.FindViewById<TextView>(Resource.Id.userMessage).Text = items[position].Message;
            view.FindViewById<TextView>(Resource.Id.msgComments).Text = items[position].Comments + " Comments";
            var likes = view.FindViewById<TextView>(Resource.Id.msgLikes);
            likes.Text = items[position].Likes.ToString() + " Likes";
            likeButton = view.FindViewById<ImageButton>(Resource.Id.msgLikeIcon);
            likeButton.Tag = position;
            likeButton.Click -= LikeButton_Click;
            likeButton.Click += LikeButton_Click;
            var picture = view.FindViewById<ImageView>(Resource.Id.msgPicture);
            picture.Visibility = ViewStates.Gone;
            if (items[position].MessagePicture != "")
            {
                picture.SetImageResource(context.Resources.GetIdentifier(items[position].MessagePicture, "drawable", context.PackageName));
                picture.Visibility = ViewStates.Visible;
            }
            //Comments
            


            return view;

        }

        private void LikeButton_Click(object sender, EventArgs e)
        {
            var likeBtn = (ImageButton)sender;
            //var pos = (int)likeButton.Tag;
            var pos = (int)likeBtn.Tag;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
            int curLikes = items[pos].Likes;
            if (items[pos].Liked)
            {
                curLikes--;
            }
            else
            {
                //items[pos].Likes++;
                curLikes++;
            }
            var likes = context.FindViewById<TextView>(Resource.Id.msgLikes);
            likes.Text = curLikes + " Likes";

        }
    }
}               