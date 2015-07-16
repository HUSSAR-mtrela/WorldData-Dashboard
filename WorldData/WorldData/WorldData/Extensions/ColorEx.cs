// copyright Infragistics, Inc. 2015

using System;
using System.Collections.Generic;
using Infragistics.XF;

namespace Xamarin.Forms
{
    public static class ColorEx
    {
        public static Color ToColor(this Paint paint)
        {
            var a = paint.A / 255.0;
            var b = paint.B / 255.0;
            var r = paint.R / 255.0;
            var g = paint.G / 255.0;
            var color = Color.FromRgba(r, g, b, a);
            return color;
        }
        public static SolidColorBrush ToBrush(this Paint paint, double opacity = double.NaN)
        {
            return paint.ToColor().ToBrush(opacity);
        }
        public static SolidColorBrush ToBrush(this Color color, double opacity = double.NaN)
        {
            if (double.IsNaN(opacity) || double.IsInfinity(opacity))
                opacity = color.A;

            var brushColor = color.Opacity(opacity);
            return new SolidColorBrush(brushColor);
        }
        public static Color Opacity(this Color color, double opacity)
        {
            var result = Color.FromRgba(color.R, color.G, color.B, opacity);
            return result;
        }
    }
}