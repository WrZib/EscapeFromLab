using Core;

namespace Tests
{
    public class TestsConditions
    {
        GameState _state;
        List<Effect> effects;
        List<Condition> conditions;

        [SetUp]
        public void Setup()
        {
            _state = new GameState();
            effects = new List<Effect>();
            conditions = new List<Condition>();
            _state.Inventory.Clear();
            _state.Visited.Clear();
        }

        [Test]
        public void TestConditionHasItem1()
        {
            _state.Inventory.Add(ItemID.KeyC);
            conditions.Add(new HasItem(ItemID.KeyC));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestConditionHasItem2()
        {
            conditions.Add(new HasItem(ItemID.KeyC));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestConditionMissingItem1()
        {
            conditions.Add(new MissingItem(ItemID.KeyC));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestConditionMissingItem2()
        {
            _state.Inventory.Add(ItemID.KeyC);
            conditions.Add(new MissingItem(ItemID.KeyC));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestConditionNotVisited1()
        {
            conditions.Add(new NotVisited("Test"));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestConditionNotVisited2()
        {
            _state.Visited.Add("Test");
            conditions.Add(new NotVisited("Test"));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestConditionVisited1()
        {
            _state.Visited.Add("Test");
            conditions.Add(new Visited("Test"));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestConditionVisited2()
        {
            conditions.Add(new Visited("Test"));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestConditionHasFlag1()
        {
            conditions.Add(new HasFlag(Flag.PowerOn));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestConditionHasFlag2()
        {
            conditions.Add(new HasFlag(Flag.LinaWithPlayer));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestConditionNotFlag1()
        {
            conditions.Add(new NotFlag(Flag.LinaWithPlayer));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestConditionNotFlag2()
        {
            conditions.Add(new NotFlag(Flag.PowerOn));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestConditionHasAnyItem1()
        {
            _state.Inventory.Add(ItemID.KeyC);
            conditions.Add(new HasAnyItem(ItemID.KeyA, ItemID.KeyB, ItemID.KeyC));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestConditionHasAnyItem2()
        {
            _state.Inventory.Add(ItemID.KeyA);
            conditions.Add(new HasAnyItem(ItemID.KeyB, ItemID.KeyC));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestConditionStatAtLeast1()
        {
            conditions.Add(new StatAtLeast(Stat.Health, 100));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestConditionStatAtLeast2()
        {
            conditions.Add(new StatAtLeast(Stat.OrionTrust, 30));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestConditionStatAtLeast3()
        {
            effects.Add(new AddInt(Stat.OrionTrust, 10));
            foreach (var effect in effects)
                effect.Apply(_state);

            conditions.Add(new StatAtLeast(Stat.OrionTrust, 30));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestConditionStatBelow1()
        {
            conditions.Add(new StatBelow(Stat.Alarm, 1));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestConditionStatBelow2()
        {
            conditions.Add(new StatBelow(Stat.Health, 100));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestConditionStatBelow3()
        {
            effects.Add(new AddInt(Stat.Alarm, 15));
            foreach (var effect in effects)
                effect.Apply(_state);

            conditions.Add(new StatBelow(Stat.Alarm, 10));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestConditionAnyCondition1()
        {
            _state.Inventory.Add(ItemID.KeyC);

            conditions.Add(new AnyCondition(
                new HasItem(ItemID.KeyA),
                new HasItem(ItemID.KeyB),
                new HasItem(ItemID.KeyC)
            ));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestConditionAnyCondition2()
        {
            conditions.Add(new AnyCondition(
                new HasItem(ItemID.KeyA),
                new HasItem(ItemID.KeyB)
            ));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestReqItem()
        {
            _state.Inventory.Add(ItemID.Medkit);
            conditions.Add(Req.Item(ItemID.Medkit));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestReqNoItem()
        {
            conditions.Add(Req.NoItem(ItemID.Medkit));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestReqAnyItem()
        {
            _state.Inventory.Add(ItemID.Crowbar);
            conditions.Add(Req.AnyItem(ItemID.KeyA, ItemID.Crowbar));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestReqFlag()
        {
            conditions.Add(Req.Flag(Flag.PowerOn));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestReqNoFlag()
        {
            conditions.Add(Req.NoFlag(Flag.LinaWithPlayer));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestReqOnce1()
        {
            conditions.Add(Req.Once("Scene1"));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestReqOnce2()
        {
            _state.Visited.Add("Scene1");
            conditions.Add(Req.Once("Scene1"));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestReqAgain1()
        {
            _state.Visited.Add("Scene1");
            conditions.Add(Req.Again("Scene1"));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestReqAgain2()
        {
            conditions.Add(Req.Again("Scene1"));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestReqTrustAtLeast1()
        {
            conditions.Add(Req.TrustAtLeast(20));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestReqTrustAtLeast2()
        {
            conditions.Add(Req.TrustAtLeast(25));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestReqAlarmBelow1()
        {
            conditions.Add(Req.AlarmBelow(10));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestReqAlarmBelow2()
        {
            effects.Add(new AddInt(Stat.Alarm, 15));
            foreach (var effect in effects)
                effect.Apply(_state);

            conditions.Add(Req.AlarmBelow(10));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }

        [Test]
        public void TestReqAny1()
        {
            _state.Inventory.Add(ItemID.KeyB);

            conditions.Add(Req.Any(
                Req.Item(ItemID.KeyA),
                Req.Item(ItemID.KeyB),
                Req.Flag(Flag.LinaFreed)
            ));

            Assert.That(conditions[0].Eval(_state), Is.True);
        }

        [Test]
        public void TestReqAny2()
        {
            conditions.Add(Req.Any(
                Req.Item(ItemID.KeyA),
                Req.Item(ItemID.KeyB),
                Req.Flag(Flag.LinaFreed)
            ));

            Assert.That(conditions[0].Eval(_state), Is.False);
        }
    }
}