using System.Reflection;

namespace Core
{
    // Эффекты
    public interface Effect { void Apply(GameState state); }

    public enum Stat
    {
        Health,
        Alarm
    }

    public class AddItem : Effect
    {
        public ItemID ItemId { get; }
        public AddItem(ItemID itemId) { ItemId = itemId; }
        public void Apply(GameState state) { state.Inventory.Add(ItemId); }
    }

    public  class SetVisited : Effect
    {
        public string Token { get; }
        public SetVisited(string token) => Token = token;
        public void Apply(GameState state) { state.Visited.Add(Token); }
    }

    public sealed class AddInt : Effect
    {
        public Stat Stat { get; }
        public int Delta { get; }
        public AddInt(Stat stat, int delta)
        {
            Stat = stat;
            Delta = delta;
        }
        public void Apply(GameState state)
        {
            switch (Stat)
            {
                case Stat.Health:
                    state.Health += Delta;
                    break;
                case Stat.Alarm:
                    state.Alarm += Delta;
                    break;
            }
        }
    }

    public class TickTurns : Effect
    {
        public int Turns { get; }
        public TickTurns(int turns) { Turns = turns; }
        public void Apply(GameState state) { state.Tick(Turns); }
    }
}
