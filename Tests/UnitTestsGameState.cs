using Core;

namespace Tests
{
    public class TestsGameState
    {
        GameState _state;

        [SetUp]
        public void Setup()
        {
            _state = new GameState();
            _state.Inventory.Clear();
            _state.Visited.Clear();
            _state.Flags.Clear();
            _state.Flags.Add(Flag.PowerOn);
        }

        [Test]
        public void TestGameStateDefaultValues()
        {
            Assert.That(_state.CurrentSceneId, Is.EqualTo(0));
            Assert.That(_state.Turn, Is.EqualTo(0));
            Assert.That(_state.MaxTurn, Is.EqualTo(28));
            Assert.That(_state.Health, Is.EqualTo(100));
            Assert.That(_state.Alarm, Is.EqualTo(0));
            Assert.That(_state.OrionTrust, Is.EqualTo(20));
            Assert.That(_state.Flags.Contains(Flag.PowerOn), Is.True);
        }

        [Test]
        public void TestHasItem()
        {
            _state.Inventory.Add(ItemID.KeyC);

            Assert.That(_state.HasItem(ItemID.KeyC), Is.True);
            Assert.That(_state.HasItem(ItemID.KeyA), Is.False);
        }

        [Test]
        public void TestIsVisited()
        {
            _state.Visited.Add("Test");

            Assert.That(_state.IsVisited("Test"), Is.True);
            Assert.That(_state.IsVisited("Test2"), Is.False);
        }

        [Test]
        public void TestFlags()
        {
            Assert.That(_state.HasFlag(Flag.PowerOn), Is.True);

            _state.SetFlag(Flag.LinaFreed);
            Assert.That(_state.HasFlag(Flag.LinaFreed), Is.True);

            _state.ClearFlag(Flag.LinaFreed);
            Assert.That(_state.HasFlag(Flag.LinaFreed), Is.False);
        }

        [Test]
        public void TestGetSetStat()
        {
            _state.SetStat(Stat.Health, 80);
            _state.SetStat(Stat.Alarm, 10);
            _state.SetStat(Stat.OrionTrust, 30);

            Assert.That(_state.GetStat(Stat.Health), Is.EqualTo(80));
            Assert.That(_state.GetStat(Stat.Alarm), Is.EqualTo(10));
            Assert.That(_state.GetStat(Stat.OrionTrust), Is.EqualTo(30));
        }

        [Test]
        public void TestAddStat()
        {
            _state.AddStat(Stat.Health, -20);
            _state.AddStat(Stat.Alarm, 15);
            _state.AddStat(Stat.OrionTrust, 10);

            Assert.That(_state.Health, Is.EqualTo(80));
            Assert.That(_state.Alarm, Is.EqualTo(15));
            Assert.That(_state.OrionTrust, Is.EqualTo(30));
        }

        [Test]
        public void TestClamp()
        {
            _state.Health = 150;
            _state.Alarm = -10;
            _state.OrionTrust = 120;

            _state.Clamp();

            Assert.That(_state.Health, Is.EqualTo(100));
            Assert.That(_state.Alarm, Is.EqualTo(0));
            Assert.That(_state.OrionTrust, Is.EqualTo(100));
        }

        [Test]
        public void TestTick()
        {
            _state.Tick(10);

            Assert.That(_state.Turn, Is.EqualTo(10));
            Assert.That(_state.HasFlag(Flag.PurgeStarted), Is.False);
        }

        [Test]
        public void TestTickPurgeStarted()
        {
            _state.Tick(28);

            Assert.That(_state.Turn, Is.EqualTo(28));
            Assert.That(_state.HasFlag(Flag.PurgeStarted), Is.True);
        }

        [Test]
        public void TestTickWithPurgeAndGasMask()
        {
            _state.SetFlag(Flag.PurgeStarted);
            _state.Inventory.Add(ItemID.GasMask);

            _state.Tick(2);

            Assert.That(_state.Health, Is.EqualTo(96));
            Assert.That(_state.Alarm, Is.EqualTo(2));
        }

        [Test]
        public void TestGetForcedId1()
        {
            Assert.That(_state.GetForcedId(), Is.Null);
        }

        [Test]
        public void TestGetForcedId2()
        {
            _state.Alarm = 100;

            Assert.That(_state.GetForcedId(), Is.EqualTo(104));
        }

        [Test]
        public void TestGetForcedId3()
        {
            _state.SetFlag(Flag.PurgeStarted);

            Assert.That(_state.GetForcedId(), Is.EqualTo(105));
        }

        [Test]
        public void TestGetForcedId4()
        {
            _state.Health = 0;

            Assert.That(_state.GetForcedId(), Is.EqualTo(105));
        }
    }
}