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
using Android.Util;

namespace Intents_FilterSample
{
    [Activity(Label = "Game")]
    public class Game : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(new GameView(this, GetIntentMessage()));
        }

        private string GetIntentMessage()
        {
            Intent i = Intent;
            string letter = "";

            if (i != null)
            {
                Bundle myParameters = i.Extras;

                if (myParameters != null)
                {
                    letter = myParameters.GetString("Letter");
                }
            }

            return letter;
        }
    }
}