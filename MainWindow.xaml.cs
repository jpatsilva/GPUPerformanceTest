using ScottPlot.Styles;
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

namespace QuickstartInteractiveDataDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random Rand = new Random(0);

        public ProcessData pd = new ProcessData();

        public MainWindow()
        {
            InitializeComponent();
            pd.ProcessDataObject();
            Scatter();
        }

        private void Scatter()
        {
            int objectCount = pd.dataObjects.Count;
            // Populate x-axis with start times.
            double[] xs1 = new double[objectCount];
            int i = 0;
            foreach(DataObject dObject in pd.dataObjects)
            {
                xs1[i] = Convert.ToDouble(dObject.startTimeValue);
                i++;
            }

            // Populate y-axis with process times.
            double[] ys1 = new double[objectCount];
            i = 0;
            foreach (DataObject dObject in pd.dataObjects)
            {
                ys1[i] = Convert.ToDouble(dObject.processTimeValue);
                i++;
            }

            ////double[] xs2 = RandomWalk(pointCount);
            //double[] xs2 = new double[10];
            //xs2[0] = 1;
            //xs2[1] = 2;
            //xs2[2] = 3;
            //xs2[3] = 4;
            //xs2[4] = 5;
            //xs2[5] = 6;
            //xs2[6] = 7;
            //xs2[7] = 8;
            //xs2[8] = 9;
            //xs2[9] = 10;

            ////double[] ys2 = RandomWalk(pointCount);
            //double[] ys2 = new double[10];
            //ys2[0] = Convert.ToDouble(pd.dataObjects.ElementAt(0).endTimeValue);
            //ys2[1] = Convert.ToDouble(pd.dataObjects.ElementAt(1).endTimeValue);
            //ys2[2] = Convert.ToDouble(pd.dataObjects.ElementAt(2).endTimeValue);
            //ys2[3] = Convert.ToDouble(pd.dataObjects.ElementAt(3).endTimeValue);
            //ys2[4] = Convert.ToDouble(pd.dataObjects.ElementAt(4).endTimeValue);
            //ys2[5] = Convert.ToDouble(pd.dataObjects.ElementAt(5).endTimeValue);
            //ys2[6] = Convert.ToDouble(pd.dataObjects.ElementAt(6).endTimeValue);
            //ys2[7] = Convert.ToDouble(pd.dataObjects.ElementAt(7).endTimeValue);
            //ys2[8] = Convert.ToDouble(pd.dataObjects.ElementAt(8).endTimeValue);
            //ys2[9] = Convert.ToDouble(pd.dataObjects.ElementAt(9).endTimeValue);

            int pointCount = objectCount;
            double[] sizes = Consecutive(pointCount, 10, 0);

            // create the lines and describe their styling 
            var line1 = new InteractiveDataDisplay.WPF.CircleMarkerGraph()
            //var line1 = new InteractiveDataDisplay.WPF.LineGraph()
            {
                Color = new SolidColorBrush(Colors.Blue),
                Description = "Process Time",
                StrokeThickness = 1
            };

            //var line2 = new InteractiveDataDisplay.WPF.CircleMarkerGraph()
            ////var line2 = new InteractiveDataDisplay.WPF.LineGraph()
            //{
            //    Color = new SolidColorBrush(Colors.Red),
            //    Description = "End Time",
            //    StrokeThickness = 1
            //};

            // load data into the lines
            line1.PlotSize(xs1, ys1, sizes);
            //line1.Plot(xs1, ys1);
            //line2.PlotSize(xs2, ys2, sizes);
            //line2.Plot(xs2, ys2);

            // add lines into the grid
            myGrid.Children.Clear();
            myGrid.Children.Add(line1);
            //myGrid.Children.Add(line2);

            // customize styling
            myChart.Title = $"Process Time Plot ({pointCount:n0} points)";
            myChart.BottomTitle = $"Time (milliseconds)";
            myChart.LeftTitle = $"Process Time(milliseconds)";
            myChart.IsAutoFitEnabled = true;
            myChart.LegendVisibility = Visibility.Hidden;
            //myChart.Background = Brushes.DodgerBlue ;
        }

        //private double[] RandomWalk(int points = 5, double start = 100, double mult = 50)
        //{
        //    // return an array of difting random numbers
        //    double[] values = new double[points];
        //    values[0] = start;
        //    for (int i = 1; i < points; i++)
        //        values[i] = values[i - 1] + (Rand.NextDouble() - .5) * mult;
        //    return values;
        //}

        private double[] Consecutive(int points, double offset = 0, double stepSize = 1)
        {
            // return an array of ascending numbers starting at 1
            double[] values = new double[points];
            for (int i = 0; i < points; i++)
                values[i] = i * stepSize + 1 + offset;
            return values;
        }
    }
}
