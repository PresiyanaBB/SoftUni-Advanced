using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public SkiRental(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();

        }
        List<Ski> data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            foreach (var item in data)
            {
                if (item.Manufacturer == manufacturer && item.Model == model)
                {
                    data.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public Ski GetSki(string manufacturer, string model)
        {
            return data.Where(x => (x.Manufacturer == manufacturer) && (x.Model == model)).FirstOrDefault();
        }
        public int Count
        {
            get
            {
                return data.Count;
            }
        }
        public string GetStatistics()
        {
            StringBuilder sr = new StringBuilder();
            sr.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                sr.AppendLine(ski.ToString());
            }
            return sr.ToString();
        }

    }
}
