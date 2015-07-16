using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Infragistics.XF;
using Infragistics.XF.Controls;
using WorldData.ViewModels;
using Xamarin.Forms;

namespace WorldData.Views
{
    public partial class TestPage : ContentPage
    {
        protected XFPieChart PieChartView;
        protected XFDataChart DataChartView;
        protected TestViewModel ViewModel;

        public TestPage()
        {
            InitializeComponent();

            ViewModel = new TestViewModel();
            ViewModel.Data = TestDataList.Generate();
             
            BindingContext = ViewModel;
            PieChartView = (PieChart as XFPieChart);
            PieChartView.SliceClick += chartView_SliceClick;

            DataChartView = (DataChart as XFDataChart);
            // extension method for styling appearance of DataChart elements across all platforms
            // NOTE this will override brush/color property values set in XAML page but 
            // you can set custom appearance after this line:
            DataChartView.StyleElements();

            //TODO uncomment to set custom styling for DataChart elements, see ChartsEx or use this code:
            //var series = DataChartView.Series.OfType<LineSeries>().First();
            //series.Brush = new SolidColorBrush(Color.Red);
            //series.Thickness = 2;
            //series.MarkerBrush = new SolidColorBrush(Color.Green);
            //series.MarkerOutline = new SolidColorBrush(Color.Lime);
            
            //TODO try increasing Interval property to increase space for long labels
            xAxis.Interval = 3;

            // TODO try to specify custom formatting labels on x axes
            //xAxis.FormatLabel += OnXAxisFormatLabel;

            // specifies dynamic formatting labels on y axes
            yAxis.FormatLabel += OnYAxisFormatLabel;
        }
        protected string OnXAxisFormatLabel(object sender, object item)
        {
            var value = ((TestDataItem)item).Date;
            return value.ToString("MMM-dd");
        }

        protected string OnYAxisFormatLabel(object sender, object item)
        {
            var value = (double)item;
            // dynamically create format for values that are very small or very big, 
            // instead of specifying fixed format that might work for big numbers but not for small numbers
            // this is important when a chart is zoomed in a lot and small values start appearing
            return value.ToStringShort(".0#");
        }
         
        void chartView_SliceClick(object sender, SliceClickEventArgs e)
        {
            e.IsExploded = !e.IsExploded;
        }
    }

    public class TestViewModel : ObservableObject
    {
        
        private TestDataList _data;
        /// <summary> Gets or sets Data </summary>
        public TestDataList Data
        {
            get { return _data;}
            set { if (_data == value) return; _data = value; RaisePropertyChanged(); }
        }
         
    }

    public class TestDataList : List<TestDataItem>
    {
        internal static Random Random = new Random();
        public static TestDataList Generate(double valueMin = 1, double valueMax = 10000000)
        {
            var list = new TestDataList();

            var date = new DateTime(2015, 10, 1);
            for (var i = 0; i < 20; i++)
            {

                var value = (Random.NextDouble() * (valueMax - valueMin)) + valueMin;

                var newItem = new TestDataItem();
                newItem.Date = date;
                newItem.Value = value;
                list.Add(newItem);

                date = date.AddDays(1);
            }

            return list;
        }
    }


    public class TestDataItem
    {
        /// <summary> Gets or sets Date </summary>
        public DateTime Date { get; set; }

        /// <summary> Gets or sets Value </summary>
        public double Value { get; set; }


        /// <summary> Gets or sets DateFormatted </summary>
        public string DateFormatted { get { return Date.ToString("MMM-dd"); }}
    }
}
