namespace Core
{
    public class Scene
    {
        public int Id { get; init; }
        public string Title { get; init; } = "";
        public string Text { get; init; } = "";
        public string Image { get; init; } = "";

        public List<Choice> Choices { get; init; } = new();
    }
}
