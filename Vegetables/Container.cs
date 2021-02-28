using System;
using System.Collections.Generic;

namespace Vegetables
{
    class Container
    {
        List<Box> boxes;
        Random rnd = new Random();
        double max_weight;
        int max_count;
        int cur_box;
        double cur_weight;

        public List<Box> GetBoxes => boxes;

        public double BoxesPrice
        {
            get
            {
                double sum = 0;
                foreach (var item in boxes)
                    sum += item.Price;
                return sum;
            }
        }

        /// <summary>
        /// добавляет коробку в лист коробок
        /// </summary>
        /// <param name="box">добавляемый объект</param>
        public void AddBox(Box box)
        {
            cur_weight += box.Weight;
            if (cur_box++ > max_count)
            {
                cur_box--;
                throw new InvalidOperationException("Контейнер уже заполнен");
            }
            else if (cur_weight++ > max_weight)
            {
                cur_weight -= box.Weight;
                throw new InvalidCastException("Невозможно добавить элемент в контейнер");
            }
            else
                boxes.Add(box);
        }

        public Container(int maxCount)
        {
            boxes = new List<Box>();
            max_weight = rnd.Next(50, 1001);
            max_count = maxCount;
            cur_box = 0;
            cur_weight = 0;
        }

        /// <summary>
        /// формирование строки с данными объета класса
        /// </summary>
        /// <returns>строка с данными объекта класса</returns>
        public override string ToString()
        {
            string res = string.Empty;
            foreach (var item in boxes)
                res += item.ToString() + "\n";
            return res;
        }
    }
}
