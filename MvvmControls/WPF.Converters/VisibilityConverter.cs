﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RFBCodeWorks.WPF.Converters
{
    /// <summary>
    /// 
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public sealed class VisibilityConverterHidden :BaseConverter
    {
        /// <inheritdoc />
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => VisibilityConverter.Convert(value, Visibility.Hidden);
        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => VisibilityConverter.ConvertBack(value);
    }

    /// <summary>
    /// 
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public sealed class VisibilityConverterCollapsed : BaseConverter
    {
        /// <inheritdoc />
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => VisibilityConverter.Convert(value, Visibility.Collapsed);
        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => VisibilityConverter.ConvertBack(value);
    }

    /// <summary>
    /// 
    /// </summary>
    internal static class VisibilityConverter
    {

        public static Visibility Convert(object value, Visibility HiddenState )
        {

            switch (value)
            {
                case null:
                case false: return HiddenState;
                
                case true:
                default:
                 return Visibility.Visible;
            }
        }

        public static bool ConvertBack(object value)
        {
            return ((Visibility)value) == Visibility.Visible;
        }
    }
}
