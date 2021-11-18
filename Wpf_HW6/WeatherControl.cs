using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_HW6
{
    /*Разработать в WPF приложении класс WeatherControl, моделирующий погодную сводку – температуру (целое число в диапазоне от -50 до +50), 
     * направление ветра (строка), скорость ветра (целое число), наличие осадков (возможные значения: 0 – солнечно, 1 – облачно, 2 – дождь, 
     * 3 – снег. Можно использовать целочисленное значение, либо создать перечисление enum). Свойство «температура» преобразовать в свойство зависимости.*/
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TempProperty;
        private int temperature;
        private int speed;
        public enum fallout
        {
            sunny = 1,
            cloudy,
            rain,
            snow,
        }
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value >= 0 && value <= 50)
                {
                    speed = value;
                }
                else
                {
                    Console.WriteLine("Введите адекватное значение скорости ветра");
                }
            }
        }
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                    new ValidateValueCallback(ValidateTemp));
        }

        private static bool ValidateTemp(object value)
        {
            int t = (int)value;
            if (t >= -50 && t < +50)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int t=(int)baseValue;
            if (t>=-50 && t<+50)
            {
                return t;
            }
            else
            {
                return 0;
            }
        }

        public WeatherControl(int temperature, int speed)
        {
            this.Speed = speed;
            this.temperature = Temp;
        }
    }
}
