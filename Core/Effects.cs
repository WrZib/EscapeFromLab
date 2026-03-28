using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    // Эффекты
    public interface Effect { void Apply(GameState state); }

    public class AddItem : Effect
    {
        public string ItemId { get; }
        public AddItem(string itemId) { ItemId = itemId; }
        public void Apply(GameState state) { state.Inventory.Add(ItemId); }
    }
}
