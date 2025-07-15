using Unity.Properties;
using UnityEngine;

namespace Inventory
{
    public interface IItem
    {
        int Quantity { get; set; }
        Rarity Rarity { get; set; }
    }

    [System.Serializable]
    public class Item : IItem
    {
        [field: SerializeField]
        public int Quantity { get; set; }
        [field: SerializeField]
        public Rarity Rarity { get; set; }
    }

    [System.Serializable]
    public class Rarity
    {
        [SerializeField] public string Label;
        [SerializeField] public Color Color;
        [SerializeField] public int Score;
    }
}