﻿using RFBCodeWorks.MvvmControls;
using RFBCodeWorks.MvvmControls.Behaviors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExampleWPF
{
    class MainViewModel : ViewModelBase, IWindowClosingHandler, IWindowFocusHandler, IWindowLoadingHandler
    {
        public MainViewModel()
        {

        }

        public ListBoxDefinition<string> ListBoxDefinition { get; } = new ListBoxDefinition<string>()
        {
            ItemSource = new string[] { "Index0", "Index1", "Index2", "Index3" }
        };

        public ComboBoxDefinition<string> ComboBoxDefinition { get; } = new ComboBoxDefinition<string>()
        {
            ItemSource = new string[] { "Index0", "Index1", "Index2", "Index3" }
        };

        public CheckBoxDefinition EnableDisableListBox { get; } = new CheckBoxDefinition()
        {
            IsThreeState = true,
            DisplayText = "Enable/Disable Listbox"
        };

        public RadioButtonDefinition EnableComboBox { get; } = new RadioButtonDefinition() { DisplayText = "Enable ComboBox", GroupName = "EC" };
        public RadioButtonDefinition DisableComboBox { get; } = new RadioButtonDefinition() { DisplayText = "Disable ComboBox", GroupName = "EC" };


        /// <summary>
        /// 
        /// </summary>
        public bool WasContentRendered
        {
            get { return WasContentRenderedField; }
            set { SetProperty(ref WasContentRenderedField, value, nameof(WasContentRendered)); }
        }
        private bool WasContentRenderedField;


        /// <summary>
        /// 
        /// </summary>
        public bool WasLoaded
        {
            get { return WasLoadedField; }
            set { SetProperty(ref WasLoadedField, value, nameof(WasLoaded)); }
        }
        private bool WasLoadedField;


        public void OnUIElementGotFocus(object sender, EventArgs e)
        {
            
            if (sender is GroupBox box)
            {
                box.Background = new RadialGradientBrush(startColor: Colors.Transparent, endColor: Colors.Aquamarine)
                {
                    Opacity = 100,
                    Center = new Point(0.5, 0.5),
                    MappingMode = BrushMappingMode.RelativeToBoundingBox,
                    SpreadMethod = GradientSpreadMethod.Pad,
                };
                box.BorderBrush = new RadialGradientBrush(startColor: Colors.Black, endColor: Colors.Black)
                {
                    Opacity = 90,
                    //RadiusX = box.ActualWidth/2,
                    //RadiusY = box.ActualHeight/2,
                    //Center = new Point(0.5, 0.5),
                    //MappingMode = BrushMappingMode.RelativeToBoundingBox,
                    //SpreadMethod = GradientSpreadMethod.Reflect,
                };
                box.BorderThickness = new Thickness(2);
                //box.Padding = new Thickness(15);
                //box.FontSize = 15;
            }
        }

        public void OnUIElementLostFocus(object sender, EventArgs e)
        {
            if (sender is GroupBox box)
            {
                box.BorderBrush = default;
                box.Background = default;
                box.BorderThickness = default;
                box.Padding = default;
                box.ClearValue(GroupBox.FontSizeProperty);
            }
        }

        public void OnWindowClosed(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show("Window Closed", "Window Closed Event");
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = System.Windows.MessageBox.Show("This MessageBox was raised from the ViewModel.\n\nAllow window to close?", "Window Closing Event", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.No;
        }

        public void OnWindowLoaded(object sender, EventArgs e)
        {
            WasLoaded = true;
        }

        public void OnWindowContentRendered(object sender, EventArgs e)
        {
            WasContentRendered = true;
        }
    }
}
