using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public enum ItemID
    {
        Wire,
        Shard
    }

    public class Items
    {
        public static Dictionary<ItemID, string> ItemNames = new Dictionary<ItemID, string>
        {
            { ItemID.Wire, "Провод" },
            { ItemID.Shard, "Осколок зеркала" }
        };
    }
}
