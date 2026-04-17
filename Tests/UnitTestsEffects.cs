using Core;

namespace Tests
{
    public class TestsEffects
    {
        GameState _state;
        List<Effect> effects;

        [SetUp]
        public void Setup()
        {
            _state = new GameState();
            effects = new List<Effect>();
            _state.Inventory.Clear();
        }

        [Test]
        public void TestEffectAddItem1()
        {
            effects.Add(new AddItem(ItemID.Medkit));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Inventory.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestEffectAddItem2() 
        {
            effects.Add(new AddItem(ItemID.Medkit));
            foreach (var effect in effects)
                effect.Apply(_state);

            var item = _state.Inventory.FirstOrDefault();

            Assert.NotNull(item);
            Assert.That(item, Is.EqualTo(ItemID.Medkit));

        }

        [Test]
        public void TestEffectRemoveItem()
        {
            effects.Add(new AddItem(ItemID.Medkit));
            effects.Add(new AddItem(ItemID.Crowbar));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Inventory.Count, Is.EqualTo(2));

            effects.Clear();

            effects.Add(new RemoveItem(ItemID.Crowbar));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Inventory.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestEffectSetFlag1()
        {
            Assert.That(_state.Flags.Count, Is.EqualTo(1));
            Assert.That(_state.Flags.Contains(Flag.LinaWithPlayer), Is.False);
            Assert.That(_state.Flags.Contains(Flag.PowerOn), Is.True);
        }

        [Test]
        public void TestEffectSetFlag2()
        {
            effects.Add(new SetFlag(Flag.LinaWithPlayer));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Flags.Count, Is.EqualTo(2));
            Assert.That(_state.Flags.Contains(Flag.LinaWithPlayer), Is.True);
        }

        [Test]
        public void TestEffectSetVisited1()
        {
            effects.Add(new SetVisited("Test"));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Visited.Count, Is.EqualTo(1));
            Assert.That(_state.Visited.Contains("Test"), Is.True);
        }

        [Test]
        public void TestEffectSetVisited2()
        {
            effects.Add(new SetVisited("Test"));
            effects.Add(new SetVisited("Test2"));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Visited.Count, Is.EqualTo(2));
            Assert.That(_state.Visited.Contains("Test"), Is.True);
            Assert.That(_state.Visited.Contains("Test2"), Is.True);
        }

        [Test]
        public void TestEffectClearFlag()
        {
            effects.Add(new SetFlag(Flag.LinaWithPlayer));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Flags.Count, Is.EqualTo(2));
            Assert.That(_state.Flags.Contains(Flag.LinaWithPlayer), Is.True);

            effects.Clear();
            effects.Add(new ClearFlag(Flag.LinaWithPlayer));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Flags.Count, Is.EqualTo(1));
            Assert.That(_state.Flags.Contains(Flag.LinaWithPlayer), Is.False);
        }

        [Test]
        public void TestEffectAttempt1()
        {
            effects.Add(new Attempt(chance: 0, effectsIfSuccess: [new AddItem(ItemID.Medkit)], effectsIfFailed: [new AddItem(ItemID.Crowbar)]));
            foreach (var effect in effects)
                effect.Apply(_state);

            Assert.That(_state.Inventory.Count, Is.EqualTo(1));
            
            Assert.That(_state.Inventory.FirstOrDefault, Is.EqualTo(ItemID.Medkit));
        }

        [Test]
        public void TestEffectAttempt2()
        {
            effects.Add(new Attempt(chance: 100, effectsIfSuccess: [new AddItem(ItemID.Medkit)], effectsIfFailed: [new AddItem(ItemID.Crowbar)]));
            foreach (var effect in effects)
                effect.Apply(_state);

            Assert.That(_state.Inventory.Count, Is.EqualTo(1));

            Assert.That(_state.Inventory.FirstOrDefault, Is.EqualTo(ItemID.Crowbar));
        }

        [Test]
        public void TestEffectAttempt3()
        {
            effects.Add(new Attempt(items: [ItemID.KeyA], effectsIfSuccess: [new AddItem(ItemID.Medkit)], effectsIfFailed: [new AddItem(ItemID.Crowbar)]));
            foreach (var effect in effects)
                effect.Apply(_state);

            var item = _state.Inventory.FirstOrDefault();

            Assert.That(_state.Inventory.Count, Is.EqualTo(1));
            Assert.NotNull(item);
            Assert.That(item, Is.EqualTo(ItemID.Crowbar));
        }

        [Test]
        public void TestEffectAttempt4()
        {
            effects.Add(new AddItem(ItemID.LabCoat));
            foreach (var effect in effects)
                effect.Apply(_state);

            effects.Clear();

            effects.Add(new Attempt([ItemID.LabCoat], effectsIfSuccess: [new AddItem(ItemID.Medkit)], effectsIfFailed: [new AddItem(ItemID.Crowbar)]));
            foreach (var effect in effects)
                effect.Apply(_state);


            Assert.That(_state.Inventory.Count, Is.EqualTo(2));
            Assert.That(_state.Inventory.Contains(ItemID.Medkit), Is.True);
        }

        [Test]
        public void TestEffectAddInt1()
        {
            Assert.That(_state.Health, Is.EqualTo(100));

            effects.Add(new AddInt(Stat.Health, -20));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Health, Is.EqualTo(80));
        }

        [Test]
        public void TestEffectAddInt2()
        {
            Assert.That(_state.Health, Is.EqualTo(100));
            Assert.That(_state.OrionTrust, Is.EqualTo(20));

            effects.Add(new AddInt(Stat.Health, -20));
            effects.Add(new AddInt(Stat.OrionTrust, 10));
            foreach (var effect in effects)
                effect.Apply(_state);

            Assert.That(_state.Health, Is.EqualTo(80));
            Assert.That(_state.OrionTrust, Is.EqualTo(30));
        }

        [Test]
        public void TestEffectTickTurns()
        {
            effects.Add(new TickTurns(10));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Turn, Is.EqualTo(10));
        }

        [Test]
        public void TestEfAddHealth()
        {
            effects.Add(Ef.AddHealth(-10));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Health, Is.EqualTo(90));
        }

        [Test]
        public void TestEfAddAlarm()
        {
            effects.Add(Ef.AddAlarm(15));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Alarm, Is.EqualTo(15));
        }

        [Test]
        public void TestEfAddTrust()
        {
            effects.Add(Ef.AddTrust(10));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.OrionTrust, Is.EqualTo(30));
        }

        [Test]
        public void TestEfT()
        {
            effects.Add(Ef.T(10));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Turn, Is.EqualTo(10));
        }

        [Test]
        public void TestEfGive()
        {
            effects.Add(Ef.Give(ItemID.KeyC));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Inventory.Count, Is.EqualTo(1));
            Assert.That(_state.Inventory.Contains(ItemID.KeyC), Is.True);
        }

        [Test]
        public void TestEfTake()
        {
            _state.Inventory.Add(ItemID.KeyC);

            Assert.That(_state.Inventory.Count, Is.EqualTo(1));

            effects.Add(Ef.Take(ItemID.KeyC));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Inventory.Count, Is.EqualTo(0));
            Assert.That(_state.Inventory.Contains(ItemID.KeyC), Is.False);
        }

        [Test]
        public void TestEfFlag()
        {
            effects.Add(Ef.Flag(Flag.LinaFreed));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Flags.Count, Is.EqualTo(2));
            Assert.That(_state.Flags.Contains(Flag.LinaFreed), Is.True);
        }

        [Test]
        public void TestEfUnflag()
        {
            effects.Add(Ef.Unflag(Flag.PowerOn));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Flags.Count, Is.EqualTo(0));
            Assert.That(_state.Flags.Contains(Flag.PowerOn), Is.False);
        }

        [Test]
        public void TestEfVisit()
        {
            effects.Add(Ef.Visit("Test"));
            foreach (var effect in effects)
                effect.Apply(_state);
            
            Assert.That(_state.Visited.Count, Is.EqualTo(1));
            Assert.That(_state.Visited.Contains("Test"), Is.True);
        }
    }
}