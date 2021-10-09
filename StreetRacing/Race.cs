using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Participants = new Dictionary<string, Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }
        Dictionary<string, Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count
        {
            get
            {
                return Participants.Count;
            }
        }
        public void Add(Car car)
        {
            if (!Participants.ContainsKey(car.LicensePlate) &&
                Participants.Count < Capacity &&
                car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car.LicensePlate, car);
            }
        }
        public bool Remove(string licensePlate)
        {
            if (Participants.ContainsKey(licensePlate))
            {
                Participants.Remove(licensePlate);
                return true;
            }
            else return false;
        }
        public Car FindParticipant(string licensePlate)
        {
            if (Participants.ContainsKey(licensePlate))
            {
                return Participants[licensePlate];
            }
            else return null;
        }
        public Car GetMostPowerfulCar()
        {
            if (Participants.Count > 0)
            {
                int maxHP = 0;
                string maxhplicense = string.Empty;
                foreach (var pp in Participants)
                {
                    if (pp.Value.HorsePower > maxHP)
                    {
                        maxHP = pp.Value.HorsePower;
                        maxhplicense = pp.Key;
                    }
                }
                return Participants[maxhplicense];
            }
            else return null;
        }
        public string Report()
        {
            StringBuilder sr = new StringBuilder();
            sr.Append($"Race: {Name} - Type: {Type} (Laps: {Laps})\r\n");
            foreach (var car in Participants)
            {
                sr.Append($"{string.Join("\r\n",car.Value)}");
            }
            return sr.ToString();
        }
    }
}
