namespace EscapeFromLab
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (var game = new Game())
            {
                game.ShowDialog();
            }

            this.Show();
        }
    }
}
