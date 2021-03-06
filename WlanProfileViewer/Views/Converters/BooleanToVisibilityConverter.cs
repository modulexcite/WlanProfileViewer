﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WlanProfileViewer.Views.Converters
{
	/// <summary>
	/// Inverse Boolean if indicated and convert it to Visibility.
	/// </summary>
	[ValueConversion(typeof(bool), typeof(Visibility))]
	public class BooleanToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is bool))
				return DependencyProperty.UnsetValue;

			var sourceValue = (bool)value;

			if (ShouldBeInversed(parameter))
				sourceValue = !sourceValue;

			return sourceValue ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is Visibility))
				return DependencyProperty.UnsetValue;

			var convertedValue = ((Visibility)value == Visibility.Visible);

			if (ShouldBeInversed(parameter))
				convertedValue = !convertedValue;

			return convertedValue;
		}

		private static bool ShouldBeInversed(object parameter)
		{
			var indication = parameter?.ToString().Equals(bool.FalseString, StringComparison.OrdinalIgnoreCase);

			// If parameter is given and it is false string, the value will be inversed.
			return (indication == true);
		}
	}
}