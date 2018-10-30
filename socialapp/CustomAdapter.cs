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
            view.FindViewById<TextView>(Resource.Id.msgLikes).Text = items[position].Likes + " Likes";
            //view.FindViewById<ImageView>(Resource.Id.userIcon);
            //view.FindViewById<ImageView>(Resource.Id.msgLikeIcon);

            return view;

        }
    }
}