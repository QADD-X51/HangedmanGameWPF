using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace HangmanGame.Service
{
    public class Faces : INotifyPropertyChanged
    {
        private string _imageDisplay;
        public string ImageDisplayed 
        {
            get
            {
                return _imageDisplay;
            }
            set
            {
                _imageDisplay = value;
                OnPropertyChanged("ImageDisplayed");
            }
        }

        DispatcherTimer idleTimer = new DispatcherTimer();
        DispatcherTimer sideTimer = new DispatcherTimer();
        DispatcherTimer playAnim = new DispatcherTimer();

        public Faces()
        {
            idleTimer.Interval = TimeSpan.FromSeconds(1);
            idleTimer.Tick += IdleSwap;

            sideTimer.Tick += TimerKill;

            playAnim.Interval = TimeSpan.FromMilliseconds(1250);
            playAnim.Tick += TimerKill;
            IdleStart();
        }

        public void IdleStart()
        {
            ImageDisplayed = System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Faces/" + (Game._mistakes / 2).ToString() + "C.png");

            idleTimer.Start();
        }

        private void IdleSwap(object sender, EventArgs e)
        {
            Random random = new Random();

            if(random.Next(0,2) == 0)
            {
                idleTimer.Stop();

                sideTimer.Interval = TimeSpan.FromMilliseconds(500 + random.Next(0,1001));

                if (random.Next(0,2) == 0)
                {
                    ImageDisplayed = System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Faces/" + (Game._mistakes / 2).ToString() + "L.png");
                }
                else
                {
                    ImageDisplayed = System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Faces/" + (Game._mistakes / 2).ToString() + "R.png");
                }
                sideTimer.Start();
            }
        }

        private void TimerKill(object sender, EventArgs e)
        {
            (sender as DispatcherTimer).Stop();
            IdleStart();
        }  

        public void HurtAnimation()
        {
            idleTimer.Stop();
            sideTimer.Stop();
            playAnim.Stop();

            ImageDisplayed = System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Faces/" + (Game._mistakes / 2).ToString() + "N.png");

            playAnim.Start();
        }

        public void YeahAnimation()
        {
            idleTimer.Stop();
            sideTimer.Stop();
            playAnim.Stop();

            ImageDisplayed = System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Faces/" + (Game._mistakes / 2).ToString() + "Y.png");

            playAnim.Start();
        }

        public void DeathAnimation()
        {
            idleTimer.Stop();
            sideTimer.Stop();
            playAnim.Stop();

            ImageDisplayed = System.IO.Path.Combine(Environment.CurrentDirectory, @"../../Resorces/Faces/5.png");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
