using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_лаба
{
    public class gadget//родительский класс
    {
        public static Random rnd = new Random();//чтобы рандомные параметры гаджетов каждый раз не повторялись
        public virtual string GetInfo()//virtual нужен для того, чтобы можно было переопределить функцию
        {                              //в классах наследниках
            return "Гаджет";
        }
        public int volume = 0;//объем памяти
    }
    
    public enum laptopType {one, two, four, six, eight}//перебор кол-ва ядер
    public class laptop : gadget
    {
        public laptopType kernels = laptopType.one;//кол-во ядер
        public bool keyboard = false;//подстветка

        public override string GetInfo()
        {
            var str = "Ноутбук";
            str += String.Format("\n Объем памяти:{0}", this.volume);
            str += String.Format("\n Кол-во ядер:{0}", this.kernels);
            str += String.Format("\n Подсветка клавиатуры:{0}", this.keyboard);
            return str;

        }

        public static laptop Generate()///создание экземпляра класса
        {
            return new laptop
            {
                volume = rnd.Next() % 1001,
                keyboard = rnd.Next() % 2 == 0,
                kernels = (laptopType)rnd.Next(5)
            };
        }
    }
    public class tablet : gadget
    {
        public bool camera = false;//наличие камеры
        public int dpi = 0;//дпи экрана

        public override string GetInfo()
        {
            var str = "Планшет";
            str += String.Format("\n Объем памяти:{0}", this.volume);
            str += String.Format("\n dpi экрана:{0}", this.dpi);
            str += String.Format("\n Наличие камеры:{0}", this.camera);
            return str;
        }

        public static tablet Generate()
        {
            return new tablet
            {
                volume = rnd.Next() % 1001,
                dpi = rnd.Next() % 1001,
                camera = rnd.Next() % 2 == 0,
            };
        }
    }

    public enum smartphoneType {one, two}//перебор кол-ва слотов под симку
    public class smartphone :gadget
    {
        public smartphoneType sim = smartphoneType.one;//кол-во слотов под симку
        public int mp = 0;//мгп камеры
        public int battery = 0;//мощность батареи

        public override string GetInfo()
        {
            var str = "Смартфон";
            str += String.Format("\n Объем памяти:{0}", this.volume);
            str += String.Format("\n Кол-во мгп у камеры:{0}", this.mp);
            str += String.Format("\n Кол-во слотов под сим-карту:{0}", this.sim);
            str += String.Format("\n Мощность батареи:{0}", this.battery);
            return str;
        }

        public static smartphone Generate()
        {
            return new smartphone
            {
                volume = rnd.Next() % 1001,
                mp = rnd.Next() % 101,
                battery = rnd.Next() % 1001,
                sim = (smartphoneType)rnd.Next(2)
            };
        }
    }
}