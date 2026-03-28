using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    // Условия
    public interface Condition { bool Eval(GameState state); }

    public class HasItem : Condition
    {
        public string ItemId { get; }
        public HasItem(string itemId) { ItemId = itemId; }
        public bool Eval(GameState state) { return state.HasItem(ItemId); }
    }

    
}
