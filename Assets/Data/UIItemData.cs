using Inventory;
using Unity.Properties;
using UnityEngine;

namespace UI
{

    public class UIItemData
    {
        [CreateProperty] public Color BackgroundColor { get => data.Rarity.Color; }
        [CreateProperty] public int Quantity { get => data.Quantity; }

        private readonly IItem data;

        public UIItemData(IItem data)
        {
            this.data = data;
        }
    }
}