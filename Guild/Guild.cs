using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        readonly List<Player> roster;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return roster.Count;
            }
        }
        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity && !roster.Contains(player))
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            foreach (var item in roster)
            {
                if (item.Name == name)
                {
                    roster.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            foreach (var item in roster)
            {
                if (item.Name == name)
                {
                    if (item.Rank != "Member") item.Rank = "Member";
                    break;
                }
            }
        }
        public void DemotePlayer(string name)
        {
            foreach (var item in roster)
            {
                if (item.Name == name)
                {
                    if (item.Rank != "Trial") item.Rank = "Trial";
                    break;
                }
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> forReturn = roster.FindAll(x => x.Class == @class);
            roster.RemoveAll(x => x.Class == @class);
            return forReturn.ToArray();
        }
        public string Report()
        {
            StringBuilder sr = new StringBuilder();
            sr.AppendLine($"Players in the guild: {Name}");
            foreach (var item in roster)
            {
                sr.AppendLine(item.ToString());
            }
            return sr.ToString().TrimEnd();
        }

    }
}
