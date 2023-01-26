﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RFBCodeWorks.WPF.Behaviors.Helpers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Helper class to set <see cref="Behaviors.ReactiveStyles.IsDirtyProperty"/> when the Default and Current values don't match
    /// </summary>
    public static class IsDirtyInt
    {


        public static bool GetEnableComparer(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableComparerProperty);
        }

        public static void SetEnableComparer(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableComparerProperty, value);
        }

        // Using a DependencyProperty as the backing store for EnableComparer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnableComparerProperty =
            DependencyProperty.RegisterAttached("EnableComparer", typeof(bool), typeof(IsDirtyInt), new PropertyMetadata(false, IsEnabledChanged));



        public static int GetOriginalValue(DependencyObject obj)
        {
            return (int)obj.GetValue(OriginalValueProperty);
        }

        public static void SetOriginalValue(DependencyObject obj, int value)
        {
            obj.SetValue(OriginalValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for OriginalValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OriginalValueProperty =
            DependencyProperty.RegisterAttached("OriginalValue", typeof(int), typeof(IsDirtyInt), new PropertyMetadata(0, CompareValues));


        public static int GetCurrentValue(DependencyObject obj)
        {
            return (int)obj.GetValue(CurrentValueProperty);
        }

        public static void SetCurrentValue(DependencyObject obj, int value)
        {
            obj.SetValue(CurrentValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for CurrentValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentValueProperty =
            DependencyProperty.RegisterAttached("CurrentValue", typeof(int), typeof(IsDirtyInt), new PropertyMetadata(0, CompareValues));


        private static readonly DependencyProperty IsDirtyComparerActiveProperty =
        DependencyProperty.RegisterAttached("IsDirtyComparerActive", typeof(bool), typeof(ReactiveStyles), new PropertyMetadata(false));
        private static bool IsDirtyComparerActive(DependencyObject obj) => (bool)obj.GetValue(IsDirtyComparerActiveProperty);


        /// <summary>
        /// Compare the two values
        /// </summary>
        private static void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (IsDirtyComparerActive(d))
            {

            }
            else
            {

            }
            d.SetValue(IsDirtyComparerActiveProperty, e.NewValue);
        }

        /// <summary>
        /// Compare the two values, and set IsDirty
        /// </summary>
        private static void CompareValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!IsDirtyComparerActive(d)) return;
            bool isDirty = !GetOriginalValue(d).Equals(GetCurrentValue(d));
            d.SetValue(ReactiveStyles.IsDirtyProperty, isDirty);
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
