using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace Intents_FilterSample
{
    public class GameView : View
    {
        private Context c;
        private string letter;

        private Paint paint;
        private Paint paintText;

        public GameView(Context context, string letter) : base(context)
        {
            Initialize(context, letter);
        }

        public GameView(Context context, IAttributeSet attrs, string letter) :
            base(context, attrs)
        {
            Initialize(context, letter);
        }

        public GameView(Context context, IAttributeSet attrs, int defStyle, string letter) :
            base(context, attrs, defStyle)
        {
            Initialize(context, letter);
        }

        private void Initialize(Context context, string letter)
        {
            c = context;
            this.letter = letter;

            paint = new Paint();
            paint.TextSize = 70;
            paint.Color = Color.White;

            paintText = new Paint();
            paintText.TextSize = 60;
            paintText.Color = Color.White;

            SetBackgroundColor(Color.Black);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            canvas.DrawText("A palavra secreta eh:", 100, 350, paintText);
            canvas.DrawLine(100, 500, 200, 500, paint);
            canvas.DrawLine(240, 500, 340, 500, paint);
            canvas.DrawLine(380, 500, 480, 500, paint);
            canvas.DrawLine(520, 500, 620, 500, paint);

            if(letter.Equals("A"))
            {
                canvas.DrawText("A", 125, 480, paint);
            }
            else if (letter.Equals("M"))
            {
                canvas.DrawText("M", 265, 480, paint);
            }
            else if (letter.Equals("O"))
            {
                canvas.DrawText("O", 405, 480, paint);
            }
            else if (letter.Equals("R"))
            {
                canvas.DrawText("R", 545, 480, paint);
            }
        }
    }
}