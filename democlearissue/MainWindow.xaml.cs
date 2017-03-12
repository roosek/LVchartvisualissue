using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using LiveCharts;
using LiveCharts.Wpf;

namespace democlearissue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Formatter = value => value + " Mill";
            buildgraph();
           // System.Threading.Thread.Sleep(1000);
         


        }

        private int countpos = 1;

        public void buildgraph()
        {
            SeriesCollection.Clear();
            VisualElements.Clear();

            SeriesCollection.Add(
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> {4, 5, 6, 8},
                    StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                    DataLabels = true
                }
            );
            SeriesCollection.Add(
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> {2, 5, 6, 7},
                    StackMode = StackMode.Values,
                    DataLabels = true
                }
            );
        

            //adding series updates and animates the chart
            SeriesCollection.Add(new StackedColumnSeries
            {
                Values = new ChartValues<double> { 6, 2, 7 },
                StackMode = StackMode.Values
            });

            //adding values also updates and animates
            SeriesCollection[2].Values.Add(4d);

            Labels = new[] { "Chrome", "Mozilla", "Opera", "IE" };
       
            VisualElementTest vstest = new VisualElementTest();
         
            countpos++;
            VisualElements.Add(vstest.visual);
            DataContext = this;

           

        }

        public void live()
        {
            foreach (var VARIABLE in SeriesCollection)
            {
                foreach (var value in VARIABLE.Values)
                {
                 
                }
            }
        }
        public VisualElementsCollection VisualElements { get; set; } = new VisualElementsCollection();
        public SeriesCollection SeriesCollection { get; set; } = new SeriesCollection();
        public string[] Labels { get; set; } = new string[] {};
        public Func<double, string> Formatter { get; set; }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
          buildgraph();
        }
    }
}
