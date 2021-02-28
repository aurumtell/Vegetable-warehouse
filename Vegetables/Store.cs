using System;
using System.Collections.Generic;

namespace Vegetables
{
    class Store
    {
        Random rnd = new Random();
        List<Container> containers;
        int cur_container;
        int max_count;
        int price;

        public List<Container> Containers => containers;

        public Store(int maxCount, int _price)
        {
            max_count = maxCount;
            cur_container = 0;
            price = _price;
            containers = new List<Container>();
        }

        /// <summary>
        /// добавляет контейнер в склад
        /// </summary>
        /// <param name="container">добавлемый контейнер</param>
        public void AddContainer(Container container)
        {
            if (cur_container++ <= max_count)
                Add(container);
            else
            {
                cur_container--;
                DeleteContainer(containers[0]);
                Add(container);
            }
        }

        /// <summary>
        /// добавляет контейнер в склад
        /// </summary>
        /// <param name="container">добавлемый контейнер</param>
        private void Add(Container container)
        {
            double sum = 0;
            double def = rnd.Next(0, 5) * 0.1;
            foreach (var item in container.GetBoxes)
            {
                item.Price -= def * item.Price;
                sum += item.Price;
            }
            if (sum > price)
                containers.Add(container);
        }

        /// <summary>
        /// удаляет контейнер из склада
        /// </summary>
        /// <param name="container">удаляемый контейнер</param>
        public void DeleteContainer(Container container)
        {
            if (containers.Contains(container))
                containers.Remove(container);
        }

        /// <summary>
        /// формирование строки с данными объета класса
        /// </summary>
        /// <returns>строка с данными объекта класса</returns>
        public override string ToString()
        {
            string res = string.Empty;
            foreach (var item in containers)
                res += item.ToString();
            return res;
        }
    }
}
