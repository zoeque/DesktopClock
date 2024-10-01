using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopClock
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Load window with new time
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoadWindow(Object sender, RoutedEventArgs e)
		{
			UpdateClock();
			DispatcherTimer timer =	new DispatcherTimer(DispatcherPriority.Normal, this.Dispatcher);
			timer.Interval = new TimeSpan(0, 0, 1);
#pragma warning disable CS8622 // パラメーターの型における参照型の NULL 値の許容が、ターゲット デリゲートと一致しません。おそらく、NULL 値の許容の属性が原因です。
			timer.Tick += Tick;
#pragma warning restore CS8622 // パラメーターの型における参照型の NULL 値の許容が、ターゲット デリゲートと一致しません。おそらく、NULL 値の許容の属性が原因です。
			timer.Start();
		}

		/// <summary>
		/// Update clock interface
		/// </summary>
		private void UpdateClock()
		{
			DateTime dt = DateTime.Now;
			this.AngleSecond.Angle = dt.Second * 360.0 / 60.0;
			this.AngleMinute.Angle = (dt.Minute + dt.Second / 60.0) * 360.0 / 60.0;
			this.AngleHour.Angle = (dt.Hour + dt.Minute / 60.0) * 360.0 / 12;
		}

		private void Tick(object sender, EventArgs e)
		{
			UpdateClock();
		}
		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ButtonState == MouseButtonState.Pressed)
				this.DragMove();
		}
	}
}
