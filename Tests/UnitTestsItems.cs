using Core;

namespace Tests
{
    public class TestsItems
    {
        [Test]
        public void TestItemNamesCount()
        {
            Assert.That(Items.ItemNames.Count, Is.EqualTo(15));
        }

        [Test]
        public void TestGetName1()
        {
            Assert.That(Items.GetName(ItemID.Medkit), Is.EqualTo("Аптечка"));
        }

        [Test]
        public void TestGetName2()
        {
            Assert.That(Items.GetName(ItemID.KeyA), Is.EqualTo("Ключ-карта A"));
        }

        [Test]
        public void TestGetName3()
        {
            Assert.That(Items.GetName(ItemID.DataDrive), Is.EqualTo("Накопитель с данными"));
        }

        [Test]
        public void TestItemNamesContainsAll()
        {
            foreach (ItemID id in Enum.GetValues(typeof(ItemID)))
            {
                Assert.That(Items.ItemNames.ContainsKey(id), Is.True);
            }
        }
    }
}