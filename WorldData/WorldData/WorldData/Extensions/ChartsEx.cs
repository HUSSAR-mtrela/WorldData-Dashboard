// copyright Infragistics, Inc. 2015

using System;
using Xamarin.Forms;

namespace Infragistics.XF.Controls
{
    /// <summary>
    /// Represents a class that provides extension methods for <see cref="XFPieChart"/> controls
    /// </summary>
    public static class PieChartEx
    {
        /// <summary> Applies generic brushes to <see cref="XFPieChart"/>  </summary>
        public static void ApplyBrushes(this XFPieChart chart, double opacity = 0.6)
        {
            chart.Outlines = new BrushCollection();
            chart.Brushes = new BrushCollection();
            foreach (var item in Paints.Palettes.Charts)
            {
                chart.Brushes.Add(item.ToBrush(opacity));
                chart.Outlines.Add(item.ToBrush());
            }
        }

        /// <summary> Styles all elements of <see cref="XFPieChart"/> across all platforms </summary>
        public static void StyleElements(this XFPieChart chart, double opacity = 0.6)
        {
            chart.ApplyBrushes(opacity);
        } 

    }
     

    /// <summary>
    /// Represents a class that provides extension methods for <see cref="XFDataChart"/> controls
    /// </summary>
    public static class DataChartEx
    {

        /// <summary> Applies generic brushes to <see cref="XFDataChart"/>  </summary>
        public static void ApplyBrushes(this XFDataChart chart, double opacity = 0.6)
        {
            chart.PlotAreaBorderBrush = Paints.Transparent.ToColor().ToBrush();
            chart.MarkerOutlines = new BrushCollection();
            chart.MarkerBrushes = new BrushCollection();
            chart.Outlines = new BrushCollection();
            chart.Brushes = new BrushCollection();
            foreach (var item in Paints.Palettes.Charts)
            {
                chart.Brushes.Add(item.ToBrush(opacity));
                chart.Outlines.Add(item.ToBrush());
                chart.MarkerBrushes.Add(item.ToBrush(opacity));
                chart.MarkerOutlines.Add(item.ToBrush());
            }
        }
        
        /// <summary> Styles all elements of <see cref="XFDataChart"/> across all platforms </summary>
        public static void StyleElements(this XFDataChart chart, double opacity = 0.6)
        {
            chart.ApplyBrushes(opacity);

            chart.StyleAxes();

            chart.StyleSeries();
        }

        /// <summary> Styles all axis elements of the chart  </summary>
        public static void StyleAxes(this XFDataChart chart)
        {
            var stroke = Paints.Gray.ToBrush();
            foreach (var ax in chart.Axes)
            {
                ax.LabelTextColor = stroke;
                if (ax is NumericXAxis || ax is NumericYAxis) // && (ax.IsVertical() || ax.IsHorizontal()))
                {
                    ax.MajorStroke = stroke;
                    ax.MajorStrokeThickness = .5;
                    ax.Stroke = Paints.Transparent.ToBrush();
                    ax.TickStroke = Paints.Transparent.ToBrush();
                    ax.TickLength = 0;
                }
                else if (ax is CategoryXAxis || ax is CategoryYAxis)
                {
                    ax.MajorStroke = Paints.Transparent.ToBrush();
                    ax.MajorStrokeThickness = .5;
                    ax.Stroke = stroke;
                    ax.StrokeThickness = .5;
                    ax.TickStroke = stroke;
                    ax.TickStrokeThickness = .5;
                    ax.TickLength = 10;
                }
                else if (ax is CategoryAngleAxis ||
                         ax is NumericRadiusAxis ||
                         ax is NumericAngleAxis)
                {
                    ax.MajorStroke = stroke;
                    ax.MajorStrokeThickness = .5;
                    ax.Stroke = stroke;
                    ax.StrokeThickness = .5;
                }
            }
        }

        /// <summary>
        /// Styles all series elements of the chart 
        /// </summary>
        public static void StyleSeries(this XFDataChart chart)
        {
            foreach (var series in chart.Series)
            {
                series.AreaFillOpacity = 0.7;
                if (!(series is FinancialPriceSeries))
                    series.Thickness = 2;

                //var markerSeries = series as MarkerSeries;
                //if (markerSeries != null && 
                //    !(series is PolarScatterSeries) &&
                //    !(series is PointSeries))
                //    markerSeries.MarkerType = MarkerType.None;

                var categSeries = series as CategorySeries;
                if (categSeries != null)
                    categSeries.IsTransitionInEnabled = true;

                var financialSeries = series as FinancialSeries;
                if (financialSeries != null)
                    financialSeries.IsTransitionInEnabled = true;
            }
        }
    }


    /// <summary>
    /// Represents a class that provides extension methods for <see cref="Axis"/> elements
    /// </summary>
    public static class ChartAxisEx
    {
        public static bool IsVertical(this Axis axis)
        {
            return (axis is CategoryYAxis || axis is NumericYAxis);
        }
        public static bool IsHorizontal(this Axis axis)
        {
            return (axis is CategoryXAxis || axis is CategoryDateTimeXAxis || axis is NumericXAxis);
        }
    }
}