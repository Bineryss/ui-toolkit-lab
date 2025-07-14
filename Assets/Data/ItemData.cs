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
        public int Quantity { get => quantity; set => quantity = value; }
        public Rarity Rarity { get => rarity; set => rarity = value; }
        
        // unity needs this for the editor...
        [SerializeField] private int quantity;
        [SerializeField] private Rarity rarity;
    }

    [System.Serializable]
    public class Rarity
    {
        [SerializeField] public string Label;
        [SerializeField] public Color Color;
        [SerializeField] public int Score;
    }
}