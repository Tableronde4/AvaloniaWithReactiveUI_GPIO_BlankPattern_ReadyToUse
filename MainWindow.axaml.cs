using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;

namespace TestAvaloniaBinding
{
    public class MainWindow : Window
    {
        readonly DispatcherTimer LiveValuesTimer;
        
        //MainWindow is like a "int main void"
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
            //auto update of UI
            #region 
            var viewModel = new ViewModel();
            DataContext = viewModel;
            LiveValuesTimer = new DispatcherTimer(TimeSpan.FromTicks((long)(1.0 / 10.0 * TimeSpan.TicksPerSecond)), DispatcherPriority.SystemIdle,
                (s, e) => ((ViewModel)DataContext).UpdateLiveValues());
            LiveValuesTimer.Start();
            #endregion

            //start logic
            viewModel.Start();
        }
        //do not modify, this come with avalonia
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
