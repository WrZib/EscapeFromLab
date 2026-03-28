namespace Core
{
    public class GameState
    {
        public int CurrentSceneId { get; set; } = 0;

        public int Turn { get; set; } = 0;
        public int MaxTurn { get; set; } = 28;

        public int Health { get; set; } = 100;
        public int Alarm { get; set; } = 0;

        public HashSet<string> Inventory { get; set; } = new();
        public bool HasItem(string itemId) { return Inventory.Contains(itemId); }

        public HashSet<string> Visited { get; set; } = new();
        public bool IsVisited(string token) { return Visited.Contains(token); }

        public void Tick(int turns = 1)
        {
            Turn += turns;
        }
       }
}
