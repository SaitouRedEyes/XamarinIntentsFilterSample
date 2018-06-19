using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;

namespace Intents_FilterSample
{
    [Activity(Label = "Intents_FilterSample", MainLauncher = true)]
    [IntentFilter(new[] { "Game" }, Categories = new[] { "Hangman", Intent.CategoryDefault })]
    public class MainActivity : Activity
    {
        private string letter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            letter = GetIntentMessage();

            Button buttonSecretWord = FindViewById<Button>(Resource.Id.wordButton);
            Button buttonArkanoid = FindViewById<Button>(Resource.Id.ArkanoidButton);

            buttonSecretWord.Click += OnButtonSecretWordClicked;
            buttonArkanoid.Click += OnButtonArkanoidClicked;
        }

        protected override void OnResume()
        {
            base.OnResume();

            letter = GetIntentMessage();
        }

        protected override void OnRestart()
        {
            base.OnRestart();

            letter = GetIntentMessage();
        }

        private string GetIntentMessage()
        {
            Intent i = Intent;
            letter = string.Empty;

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

        private void OnButtonSecretWordClicked(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Game));

            Bundle myParameters = new Bundle();
            myParameters.PutString("Letter", letter);

            i.PutExtras(myParameters);
            StartActivity(i);
        }

        private void OnButtonArkanoidClicked(object sender, EventArgs e)
        {
            Intent i = new Intent("Game");
            i.AddCategory("Arkanoid");

            i.AddFlags(ActivityFlags.ReorderToFront);
            StartActivity(i);
        }
    }
}

