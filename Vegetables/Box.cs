using System;

namespace Vegetables
{
    class Box
    {
        double weight;
        double price;

        public double Weight
        {
            get => weight;
            private set
            {
                if (value >= 0)
                    weight = value;
                else
                    throw new ArgumentException("Bес не может быть отрицательным!");
            }
        }

        public double Price {
            get => price;
            set
            {
                if (value >= 0)
                    price = value;
                else
                    throw new ArgumentException("Цена не может быть отрицательной!");
            }
        }

        public Box(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }

        /// <summary>
        /// формирование строки с данными объета класса
        /// </summary>
        /// <returns>строка с данными объекта класса</returns>
        public override string ToString() => $"Price: {price}\tWeight: {weight}";
    }
}
