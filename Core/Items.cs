using System.Collections.Generic;

namespace Core
{
    public enum ItemID
    {
        Wire,
        Shard,
        Crowbar,
        Flashlight,
        Solvent,
        Medkit,
        Sedative,
        GasMask,
        KeyA,
        KeyB,
        KeyC,
        Badge,
        LabCoat,
        DataDrive,
        Fuse
    }

    /// <summary>
    /// Класс предметов
    /// </summary>
    public static class Items
    {
        /// <summary>
        /// Словарь предметов
        /// </summary>
        public static readonly Dictionary<ItemID, string> ItemNames = new()
        {
            { ItemID.Wire, "Провод" },
            { ItemID.Shard, "Осколок зеркала" },
            { ItemID.Crowbar, "Ломик" },
            { ItemID.Flashlight, "Фонарь" },
            { ItemID.Solvent, "Растворитель" },
            { ItemID.Medkit, "Аптечка" },
            { ItemID.Sedative, "Седатив" },
            { ItemID.GasMask, "Респиратор" },

            { ItemID.KeyA, "Ключ-карта A" },
            { ItemID.KeyB, "Ключ-карта B" },
            { ItemID.KeyC, "Ключ-карта C" },

            { ItemID.Badge, "Бейдж сотрудника" },
            { ItemID.LabCoat, "Лабораторный халат" },

            { ItemID.DataDrive, "Накопитель с данными" },
            { ItemID.Fuse, "Предохранитель" }
        };

        /// <summary>
        /// Получение названия
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(ItemID id)
        {
            return ItemNames.TryGetValue(id, out var name) ? name : id.ToString();
        }
    }
}
