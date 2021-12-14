using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
/*Разработать в WPF приложении класс WeatherControl, 
 * моделирующий погодную сводку – температуру (целое число в диапазоне от -50 до +50), 
 * направление ветра (строка), скорость ветра (целое число), 
 * наличие осадков (возможные значения: 0 – солнечно, 1 – облачно, 2 – дождь, 3 – снег.
 * Можно использовать целочисленное значение, либо создать перечисление enum).
 * Свойство «температура» преобразовать в свойство зависимости.*/
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        private static object CTemperature(DependencyObject d, object baseValue)
        {
            int tempreture = (int)baseValue;
            if (tempreture >= -50 && tempreture <= 50)
            {
                return tempreture;
            }
            else
            {
                return 0;
            }
        }
        public enum Rainfalls
        {
            Sunny = 0,
            Cloudly = 1,
            Rainly = 2,
            Snowly = 3
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.Journal,
                    null,
                    new CoerceValueCallback(CTemperature)));
        }
    
    }
}
