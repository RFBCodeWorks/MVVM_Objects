﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFBCodeWorks.MVVMObjects.BaseControlDefinitions
{
    /// <typeparam name="V">The type of property represented by the <see cref="SelectedValue"/></typeparam>
    /// <inheritdoc cref="ItemSourceDefinition{T, E}"/>
    /// <typeparam name="E"/><typeparam name="T"/>
    public class SelectorDefinition<T,E, V> : ItemSourceDefinition<T,E> where E : IEnumerable<T>
    {

        #region < SelectionChangedEvent >

        /// <summary>
        /// Occurs after the <see cref="SelectedItem"/> has been updated
        /// </summary>
        public event PropertyOfTypeChangedEventHandler<T> SelectionChanged;

        /// <summary> Raises the SelectionChanged event </summary>
        protected virtual void OnSelectionChanged(PropertyOfTypeChangedEventArgs<T> e)
        {
            SelectionChanged?.Invoke(this, e);
            OnPropertyChanged(e);
        }

        #endregion

        #region < SelectionValueChanged >

        /// <summary>
        /// Occurs when the <see cref="SelectedValue"/> is updated ( after <see cref="SelectedItem"/> changes )
        /// </summary>
        public event PropertyOfTypeChangedEventHandler<V> SelectedValueChanged;

        /// <summary> Raises the SelectionChanged event </summary>
        protected virtual void OnSelectedValueChanged(PropertyOfTypeChangedEventArgs<V> e)
        {
            SelectedValueChanged?.Invoke(this, e);
            OnPropertyChanged(e);
        }

        #endregion

        #region < Properties >

        /// <summary>
        /// The Currently Selected item within the user control - May be null!
        /// </summary>
        /// <remarks>
        /// Binding for the 'SelectedItem' property of controls such as ComboBox or ListBox
        /// </remarks>
        public T SelectedItem
        {
            get { return SelectedItemField; }
            set { SetProperty(ref SelectedItemField, value, nameof(SelectedItem)); }
        }
        private T SelectedItemField;

        /// <summary>
        /// If bound to the control, the control will set this property according to the property defined by SelectedValuePath
        /// </summary>
        /// <remarks>
        /// Example: If the SelectedItem = Person(Joe, Schmoe), and SelectedValuePath = "FirstName", then SelectedValue = "Joe"
        /// </remarks>
        public V SelectedValue
        {
            get { return SelectedValueField; }
            set
            {
                if (value is null && SelectedValueField is null) return;
                if (value?.Equals(SelectedValueField) ?? false) return;
                var e = new PropertyOfTypeChangedEventArgs<V>(SelectedValueField, value, nameof(SelectedValue));
                OnPropertyChanging(e.PropertyName);
                SelectedValueField = value;
                OnSelectedValueChanged(e);
            }
        }
        private V SelectedValueField;


        /// <summary>
        /// Specify the property name/path to use as the <see cref="SelectedValue"/> of the <see cref="SelectedItem"/>
        /// </summary>
        /// <remarks>
        /// Example: If the <see cref="SelectedItem"/> is type Person, and this value is 'Name', then the <see cref="SelectedValue"/> = Person.Name
        /// </remarks>
        public string SelectedValuePath
        {
            get { return SelectedValuePathField; }
            set { SetProperty(ref SelectedValuePathField, value ?? "", nameof(SelectedValuePath)); }
        }
        private string SelectedValuePathField = "";

        #endregion

    }
}
