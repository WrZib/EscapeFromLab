namespace Core
{
    public static class Flag
    {
        public const string PowerOn = "PowerOn";
        public const string CamerasDisabled = "CamerasDisabled";
        public const string VentOpened = "VentOpened";
        public const string DoorBypass = "DoorBypass";

        public const string KnowPassword = "KnowPassword";
        public const string LinaFreed = "LinaFreed";
        public const string LinaWithPlayer = "LinaWithPlayer";

        public const string OrionHelps = "OrionHelps";
        public const string OrionDown = "OrionDown";

        public const string PurgeStarted = "PurgeStarted";
        public const string EvacPlanFound = "EvacPlanFound";
    }

    public class GameState
    {
        public int CurrentSceneId { get; set; } = 0;

        public int Turn { get; set; } = 0;
        public int MaxTurn { get; set; } = 28;

        public int Health { get; set; } = 100;
        public int Alarm { get; set; } = 0;
        public int OrionTrust { get; set; } = 20;

        public HashSet<ItemID> Inventory { get; set; } = new();
        public bool HasItem(ItemID itemId) { return Inventory.Contains(itemId); }

        public HashSet<string> Visited { get; set; } = new();
        public bool IsVisited(string token) { return Visited.Contains(token); }

        public HashSet<string> Flags { get; set; } = new() { Flag.PowerOn };
        public bool HasFlag(string flag) { return Flags.Contains(flag); }
        public void SetFlag(string flag) { Flags.Add(flag); }
        public void ClearFlag(string flag) { Flags.Remove(flag); }

        public int GetStat(Stat stat)
        {
            switch (stat)
            {
                case Stat.Health: return Health;
                case Stat.Alarm: return Alarm;
                case Stat.OrionTrust: return OrionTrust;
                default: return 0;
            }
        }

        public void SetStat(Stat stat, int value)
        {
            switch (stat)
            {
                case Stat.Health: Health = value; break;
                case Stat.Alarm: Alarm = value; break;
                case Stat.OrionTrust: OrionTrust = value; break;
            }
        }

        public void AddStat(Stat stat, int delta)
        {
            SetStat(stat, GetStat(stat) + delta);
        }

        public int Roll(int min, int max) { return Random.Shared.Next(min, max + 1); }

        public void Clamp()
        {
            if (Health < 0) Health = 0;
            if (Health > 100) Health = 100;

            if (Alarm < 0) Alarm = 0;
            if (Alarm > 100) Alarm = 100;

            if (OrionTrust < 0) OrionTrust = 0;
            if (OrionTrust > 100) OrionTrust = 100;
        }

        public void Tick(int turns = 1)
        {
            Turn += turns;

            if (Turn >= MaxTurn)
                SetFlag(Flag.PurgeStarted);

            if (HasFlag(Flag.PurgeStarted))
            {
                if (!HasItem(ItemID.GasMask))
                {
                    //...
                }
                else
                {
                    Health -= 2 * turns;
                    Alarm += 1 * turns;
                }
            }

            Clamp();
        }

        public int? GetForcedId()
        {
            //Концовка 104
            if (Alarm >= 100) return 104;

            //Концовка 105
            if (HasFlag(Flag.PurgeStarted) && !HasItem(ItemID.GasMask))
                return 105;

            //Концовка 105
            if (Health <= 0) return 105;

            return null;
        }
    }
}
