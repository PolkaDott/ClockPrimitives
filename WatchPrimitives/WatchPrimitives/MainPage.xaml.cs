using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WatchPrimitives
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            UpdateTime();
            DrawLines();
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
            
        }

        private void UpdateTime()
        {
            var now = DateTime.Now;
            secondsHand.Rotation = now.Second * 6;
            minutesHand.Rotation = now.Minute * 6;
            hoursHand.Rotation = now.Hour * 15;
            timelable.Text = DateTime.Now.ToString();
        }

        private bool OnTimerTick()
        {
            UpdateTime();
            return true;
        }
        
        private void DrawLines()
        {
            for (int i = 0; i < 120; i++)
            {
                var line = new Xamarin.Forms.Shapes.Line();
                line.Y1 = i % 5 == 0 ? 25 : 12;
                line.Stroke = new SolidColorBrush(Color.FromHex("#3366cc"));
                line.HorizontalOptions = LayoutOptions.Center;
                line.VerticalOptions = LayoutOptions.Center;
                line.HeightRequest = 355;
                line.StrokeThickness = i % 5 == 0 ? 22 : 11;
                line.Rotation = i*6;

                mainGrid.Children.Insert(1, line);
            }
            
        }

    }
}
