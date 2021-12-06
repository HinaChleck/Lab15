using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    internal class Program
    {
        /*Разработать интерфейс ISeries генерации ряда чисел. Интерфейс содержит следующие элементы:

        метод void setStart(int x) - устанавливает начальное значение
        метод int getNext() - возвращает следующее число ряда
        метод void reset() - выполняет сброс к начальному значению
        Разработать классы ArithProgression и GeomProgression, которые реализуют интерфейс ISeries.
        В классах реализовать методы интерфейса в соответствии с логикой арифметической и геометрической прогрессии соответственно.*/
        static void Main(string[] args)
        {
            try
            {
            Console.Write("Введите первый член арифметической прогрессии: ");
            int x=Convert.ToInt32(Console.ReadLine());;
            
            Console.Write("Введите шаг арифметической прогрессии: ");
            int d=Convert.ToInt32(Console.ReadLine());;

            ArithProgression ar=new ArithProgression();
            ar.setStart(x);

                ar.setStep(d);
                Console.Write("\nВведите количество выводимых членов арифметической прогрессии: ");
                int count=Convert.ToInt32(Console.ReadLine());
                Console.Write("{0} ",x);
                for (int i = 1; i < count; i++)
                {
            
                    Console.Write("{0} ", ar.getNext());
                }
                ar.reset();

                Console.Write("\nВведите другое количество выводимых членов арифметической прогрессии (для проверки метода reset): ");
                int count2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("{0} ", x);
                for (int i = 1; i < count2; i++)
                {

                    Console.Write("{0} ", ar.getNext());
                }

            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

            Console.WriteLine("\n\n");

            try
            {
                Console.Write("Введите первый член геометрической прогрессии: ");
                int x1 = Convert.ToInt32(Console.ReadLine()); ;

                Console.Write("Введите знаменатель геометрической прогрессии: ");
                int q = Convert.ToInt32(Console.ReadLine()); ;

                Console.WriteLine();
                GeomProgression geom = new GeomProgression();

                geom.setStart(x1);


                geom.setStep(q);
                Console.Write("Введите количество выводимых членов геометрической прогрессии: ");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.Write("{0} ", x1);
                for (int i = 1; i < count; i++)
                {

                    Console.Write("{0} ", geom.getNext());
                }
                geom.reset();

                Console.Write("\nВведите другое количество выводимых членов геометрической прогрессии (для проверки метода reset): ");
                int count2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("{0} ", x1);
                for (int i = 1; i < count2; i++)
                {

                    Console.Write("{0} ", geom.getNext());
                }

            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

            Console.ReadKey();
        }

        interface ISeries
        {
            void setStart(int x);
            void setStep(int d);
            int getNext();
            void reset();
        }
        class ArithProgression : ISeries
        {
            int x;
            int d;
            int sum;
            public void setStart(int x)
            {
                this.x = x;
                sum = x;

            }
            public void setStep(int d)
            {
                if (d==0)
                {
                    throw new Exception ("Шаг не может быть равен 0");
                }

                this.d = d;
               
            }

            public int getNext()
            {
                return sum+=d;
            }

            public void reset()
            {
                sum = x;
            }

            
        }
        class GeomProgression : ISeries
        {
            int x;
            int d;
            int product;
            public void setStart(int x)
            {
                if (x == 0)
                {
                    throw new Exception("Первый член не может быть равен 0");
                }

                this.x = x;
                product = x;

            }
            public void setStep(int d)
            {
                if (d == 0)
                {
                    throw new Exception("Знаменатель не может быть равен 0");
                }
                if (d==1)
                    Console.WriteLine("Ваша прогрессия стационарная");
                this.d = d;

            }

            public int getNext()
            {
                return product *= d;
            }

            public void reset()
            {
                product = x;
            }


        }
    }
}
