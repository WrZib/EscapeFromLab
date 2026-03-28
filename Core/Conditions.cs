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
}
