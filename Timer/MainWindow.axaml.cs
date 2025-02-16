using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using System;
using System.Threading;
using System.Timers;
using Tmds.DBus.Protocol;

namespace Timer
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = true;
        }


        System.Timers.Timer timer;
        private void StartTimer(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            timer = new System.Timers.Timer(1000);
            
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
            
            Start.IsEnabled = false;
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            Dispatcher.UIThread.Invoke(() => {
                
                int minute = int.Parse(Minute.Text);
                int seconds = int.Parse(Seconds.Text);

                if(seconds == 0)
                {
                    if (minute != 0) 
                    {
                        Minute.Text = $"{minute-1:D2}";
                        Seconds.Text = "59";
                    }
                    else
                    {
                        timer.Stop();
                    }
                }
                if (seconds > 0)
                {
                    Seconds.Text = $"{seconds - 1:D2}";
                }
            });
        }

        private void StopTimer(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            timer.Stop();
        }

       
        private void AddFiveMinutes(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            int minute = int.Parse(Minute.Text);
            Minute.Text = $"{minute + 5:D2}";
        }

        private void SubtractFiveMinutes(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            int minute = int.Parse(Minute.Text);
            Minute.Text = $"{minute - 5:D2}";
        }
    }
}