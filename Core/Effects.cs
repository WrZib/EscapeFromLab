using System.Reflection;

namespace Core
{
    // Эффекты

    /// <summary>
    /// Интерфейс эффекта
    /// </summary>
    public interface Effect { void Apply(GameState state); }

    public enum Stat
    {
        Health,
        Alarm,
        OrionTrust
    }

    /// <summary>
    /// Добавление предмета
    /// </summary>
    public class AddItem : Effect
    {
        public ItemID ItemId { get; }
        public AddItem(ItemID itemId) { ItemId = itemId; }
        public void Apply(GameState state) { state.Inventory.Add(ItemId); }
    }

    /// <summary>
    /// Удаление предмета
    /// </summary>
    public class RemoveItem : Effect
    {
        public ItemID ItemId { get; }
        public RemoveItem(ItemID itemId) { ItemId = itemId; }
        public void Apply(GameState state) { state.Inventory.Remove(ItemId); }
    }

    /// <summary>
    /// Добавление просмотра
    /// </summary>
    public class SetVisited : Effect
    {
        public string Token { get; }
        public SetVisited(string token) { Token = token; }

        public void Apply(GameState state) { state.Visited.Add(Token); }
    }

    /// <summary>
    /// Добавление флага
    /// </summary>
    public class SetFlag : Effect
    {
        public string FlagName { get; }
        public SetFlag(string flagName) { FlagName = flagName; }

        public void Apply(GameState state) { state.SetFlag(FlagName); }
    }

    /// <summary>
    /// Удаление флага
    /// </summary>
    public class ClearFlag : Effect
    {
        public string FlagName { get; }
        public ClearFlag(string flagName) { FlagName = flagName; }
        public void Apply(GameState state) { state.ClearFlag(FlagName); }
    }

    /// <summary>
    /// Попытка
    /// </summary>
    public class Attempt : Effect
    {
        public ItemID[]? Items { get; }
        public int Chance { get; }

        public List<Effect> EffectsIfFailed { get; } = new();
        public List<Effect> EffectsIfSuccess { get; } = new();
        public Attempt(ItemID[] items, List<Effect> effectsIfSuccess, List<Effect> effectsIfFailed)
        {
            Items = items;
            EffectsIfFailed = effectsIfFailed;
            EffectsIfSuccess = effectsIfSuccess;
        }
        public Attempt(int chance, List<Effect> effectsIfSuccess, List<Effect> effectsIfFailed)
        {
            Items = null;
            Chance = chance;
            EffectsIfFailed = effectsIfFailed;
            EffectsIfSuccess = effectsIfSuccess;
        }
        public void Apply(GameState state) {
            if (Items == null)
            {
                if (Chance <= state.Roll(0, 100))
                {
                    foreach (var eff in EffectsIfSuccess)
                    {
                        eff.Apply(state);
                    }
                }
                else
                {
                    foreach (var eff in EffectsIfFailed)
                    {
                        eff.Apply(state);
                    }
                }
            }
            else if (Items.Length > 0)
            {
                if (Items.Any(state.HasItem))
                {
                    foreach (var eff in EffectsIfSuccess)
                    {
                        eff.Apply(state);
                    }
                }
                else
                {
                    foreach (var eff in EffectsIfFailed)
                    {
                        eff.Apply(state);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Добавление очков
    /// </summary>
    public class AddInt : Effect
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
                case Stat.OrionTrust:
                    state.OrionTrust += Delta;
                    break;
            }
        }
    }

    /// <summary>
    /// Добавление тика
    /// </summary>
    public class TickTurns : Effect
    {
        public int Turns { get; }
        public TickTurns(int turns) { Turns = turns; }
        public void Apply(GameState state) { state.Tick(Turns); }
    }

    /// <summary>
    /// Класс эффектов
    /// </summary>
    public static class Ef
    {
        public static AddInt AddHealth(int d) { return new AddInt(Stat.Health, d); }
        public static AddInt AddAlarm(int d) { return new AddInt(Stat.Alarm, d); }
        public static AddInt AddTrust(int d) { return new AddInt(Stat.OrionTrust, d); }

        public static TickTurns T(int t) { return new TickTurns(t); }

        public static AddItem Give(ItemID id) { return new AddItem(id); }
        public static RemoveItem Take(ItemID id) { return new RemoveItem(id); }

        public static SetFlag Flag(string f) { return new SetFlag(f); }
        public static ClearFlag Unflag(string f) { return new ClearFlag(f); }

        public static SetVisited Visit(string token) { return new SetVisited(token); }
    }
}
