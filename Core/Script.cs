namespace Core
{
    public static class Script
    {
        private static Dictionary<int, Scene> _scenes = new Dictionary<int, Scene>();

        public static Dictionary<int, Scene> Build()
        {
            _scenes[0] = new Scene
            {
                Id = 0,
                Title = "Камера-изоляция",
                Text = "...",
                Choices =
            {
                new Choice { Text = "Осмотреться", NextSceneId = 1 }
            }
            };

            return _scenes;
        }
    }
}
