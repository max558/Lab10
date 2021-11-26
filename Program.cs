using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    /*
     * Угол задан с помощью целочисленных значений gradus - градусов, min - угловых минут, sec - угловых секунд. 
     * Реализовать класс, в котором указанные значения представлены в виде свойств. 
     * Для свойств предусмотреть проверку корректности данных. 
     * Класс должен содержать конструктор для установки начальных значений, а также метод ToRadians для перевода угла в радианы. 
     * Создать объект на основе разработанного класса. 
     * Осуществить использование объекта в программе.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Angl TestAngl = new Angl();

            TestAngl.Gradus = 50;
            TestAngl.Sec = 58;

            Console.WriteLine("Тестовый угол: {0} град, {1} минут, {2} сек.", TestAngl.Gradus, TestAngl.Min, TestAngl.Sec);
            Console.WriteLine("Тестовый угол: {0} рад", TestAngl.ToRadians());

            Console.ReadKey();
        }
    }

    class Angl
    {
        int gradus;
        int min;
        int sec;

        public Angl(int gradus = 0, int min = 0, int sec = 0)
        {
            Gradus = gradus;
            Min = min;
            Sec = sec;
        }

        public int Gradus
        {
            set
            {
                int temp = 0;
                if (value < 0)
                {
                    int i = 0;
                    do
                    {
                        i++;
                        temp = value + 360 * i;
                    }
                    while (temp < 0);
                }
                else
                {
                    if (value > 360)
                    {
                        temp = value % 360;
                    }
                    else
                    {
                        if (value == 360)
                        {
                            temp = 0;
                        }
                        else
                        {
                            temp = value;
                        }
                    }
                }
                gradus = temp;
            }
            get
            {
                return gradus;
            }
        }

        public int Min
        {
            set
            {
                if ((value > -1) && (value < 60))
                {
                    min = value;
                }
                else
                {
                    Console.WriteLine("Минуты должны быть больше 0, но меньше 60.");
                    if (value > 59.9)
                    {
                        gradus += (int)value / 60;
                        min = value % 60;
                    }
                }
            }
            get
            {
                return min;
            }
        }

        public int Sec
        {
            set
            {

                if ((value > -1) && (value < 60))
                {
                    sec = value;
                }
                else
                {
                    Console.WriteLine("Секунды должны быть больше 0, но меньше 60.");
                    if (value > 59.9)
                    {
                        min += (int)value / 60;
                        sec = value % 60;
                    }
                }
            }
            get
            {
                return sec;
            }
        }

        public double ToRadians()
        {
            double res = 0;
            res = gradus * 2 * Math.PI / 360;
            res += min * 2 * Math.PI / (360 * 60);
            res += sec * 2 * Math.PI / (360 * 60 * 60);
            return res;
        }

    }
}
