using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts.Wpf;

namespace democlearissue
{
    /// <summary>
    /// Interaction logic for VisualElementTest.xaml
    /// </summary>
    public partial class VisualElementTest : UserControl
    {
        public VisualElement visual;

        private Random r = new Random();

        public VisualElementTest()
        {
            InitializeComponent();
            visual = new VisualElement();
            visual.UIElement = this;
            visual.X = 1;

            new Thread(delegate () {
                while (true)
                {
                    System.Threading.Thread.Sleep(1000);
                    this.Dispatcher.Invoke(new Action(() => { visual.Y = r.Next(10); }));
                   
                }
            }).Start();

           

           



        }
    }
}
