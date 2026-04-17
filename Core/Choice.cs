namespace Core
{
    public class Choice
   {
        public string Text { get; init; } = "";
        public int NextSceneId { get; init; }

        public List<Condition> Requirements { get; init; } = new();
        public List<Effect> Effects { get; init; } = new();

        public bool IsAvailable(GameState state)
        {
            return Requirements.All(req => req.Eval(state));
        }
    }
   
}
