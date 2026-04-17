using Core;
using EscapeFromLab.Properties;
using System.Drawing;


namespace EscapeFromLab
{
    public partial class Game : Form
    {
        private readonly Dictionary<int, Scene> _scenes = Script.Build();
        private readonly GameState _state = new();
        private readonly Button[] _choiceButtons;

        public Game()
        {
            InitializeComponent();

            _choiceButtons = new[] { btn1, btn2, btn3, btn4 };
            foreach (var btn in _choiceButtons)
                btn.Click += OnChoiceClick;

            Render();

        }

        private void Render()
        {
            if (!_scenes.TryGetValue(_state.CurrentSceneId, out var scene))
            {
                MessageBox.Show($"Сцена не найдена: {_state.CurrentSceneId}");
                return;
            }

            title.Text = scene.Title;
            textBox.Text = scene.Text;
            var imageObj = Resources.ResourceManager.GetObject(scene.Image);
            pictureBox.Image = imageObj as Image;

            //Инвентарь
            invBox.Items.Clear();
            foreach (var item in _state.Inventory.OrderBy(x => x))
                invBox.Items.Add(Items.ItemNames[item]);

            //Прогресс-бары
            hpbar.Value = Math.Max(0, Math.Min(100, _state.Health));
            alarmbar.Value = Math.Max(0, Math.Min(100, _state.Alarm));
            trustbar.Value = Math.Max(0, Math.Min(100, _state.OrionTrust));

            turns.Text = $"Ход: {_state.Turn}/{_state.MaxTurn}";

            //Доступные варианты
            var available = scene.Choices.Where(c => c.IsAvailable(_state)).ToList();

            for (int i = 0; i < _choiceButtons.Length; i++)
            {
                if (i < available.Count)
                {
                    _choiceButtons[i].Visible = true;
                    _choiceButtons[i].Enabled = true;
                    _choiceButtons[i].Text = available[i].Text;
                    _choiceButtons[i].Tag = available[i];
                }
                else
                {
                    _choiceButtons[i].Visible = false;
                    _choiceButtons[i].Tag = null;
                }
            }
        }
        private void OnChoiceClick(object? sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag is not Choice choice) return;

            foreach (var eff in choice.Effects)
                eff.Apply(_state);

            if (_state.GetForcedId() != null)
                _state.CurrentSceneId = (int)_state.GetForcedId();
            else
                _state.CurrentSceneId = choice.NextSceneId;

            //Глобальные проверки после перехода
            _state.Tick(0);

            Render();
        }

        private void Game_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
