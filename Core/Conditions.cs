namespace Core
{
    // Условия
    public interface Condition { bool Eval(GameState state); }

    public class HasItem : Condition
    {
        public ItemID ItemId { get; }
        public HasItem(ItemID itemId) { ItemId = itemId; }
        public bool Eval(GameState state) { return state.HasItem(ItemId); }
    }

    public class NotVisited : Condition
    {
        public string Token { get; }
        public NotVisited(string token) { Token = token; }
        public bool Eval(GameState s) { return !s.IsVisited(Token); }
    }

    public class Visited : Condition
    {
        public string Token { get; }
        public Visited(string token) { Token = token; }
        public bool Eval(GameState s) { return s.IsVisited(Token); }
    }

    public class HasFlag : Condition
    {
        public string FlagName { get; }
        public HasFlag(string flagName) { FlagName = flagName; }
        public bool Eval(GameState state) { return state.HasFlag(FlagName); }
    }

    public class NotFlag : Condition
    {
        public string FlagName { get; }
        public NotFlag(string flagName) { FlagName = flagName; }
        public bool Eval(GameState state) { return !state.HasFlag(FlagName); }
    }

    public class MissingItem : Condition
    {
        public ItemID ItemId { get; }
        public MissingItem(ItemID itemId) { ItemId = itemId; }
        public bool Eval(GameState state) { return !state.HasItem(ItemId); }
    }

    public class HasAnyItem : Condition
    {
        public ItemID[] Items { get; }
        public HasAnyItem(params ItemID[] items) { Items = items; }
        public bool Eval(GameState state) { return Items.Any(state.HasItem); }
    }

    public class StatAtLeast : Condition
    {
        public Stat Stat { get; }
        public int Value { get; }
        public StatAtLeast(Stat stat, int value) { Stat = stat; Value = value; }
        public bool Eval(GameState state) { return state.GetStat(Stat) >= Value; }
    }

    public class StatBelow : Condition
    {
        public Stat Stat { get; }
        public int Value { get; }
        public StatBelow(Stat stat, int value) { Stat = stat; Value = value; }
        public bool Eval(GameState state) { return state.GetStat(Stat) < Value; }
    }

    public class AnyCondition : Condition
    {
        public Condition[] Conditions { get; }
        public AnyCondition(params Condition[] conditions) { Conditions = conditions; }
        public bool Eval(GameState state) { return Conditions.Any(c => c.Eval(state)); }
    }

    public static class Req
    {
        public static HasItem Item(ItemID id) { return new HasItem(id); }
        public static MissingItem NoItem(ItemID id) { return new MissingItem(id); }
        public static HasAnyItem AnyItem(params ItemID[] ids) { return new HasAnyItem(ids); }

        public static HasFlag Flag(string f) { return new HasFlag(f); }
        public static NotFlag NoFlag(string f) { return new NotFlag(f); }

        public static NotVisited Once(string token) { return new NotVisited(token); }
        public static Visited Again(string token) { return new Visited(token); }

        public static StatAtLeast TrustAtLeast(int v) { return new StatAtLeast(Stat.OrionTrust, v); }
        public static StatBelow AlarmBelow(int v) { return new StatBelow(Stat.Alarm, v); }

        public static AnyCondition Any(params Condition[] c) { return new AnyCondition(c); }
    }
}
