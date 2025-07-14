using System.Collections.Generic;
using System.Linq;
using UIBuilder.UI;
using UnityEngine;
using UnityEngine.UIElements;


[System.Serializable]
struct Item
{
    public int Quantity;
    public Color Color;
}
public class UIScript : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    [SerializeField] private UIDocument document;
    [SerializeField] private VisualTreeAsset itemA;
    [SerializeField] private Item itemData;


    private ItemData data;
    private List<ItemData> mapped;

    void Start()
    {
        var root = document.rootVisualElement.Q("container");
        VisualElement item = itemA.Instantiate();
        data = new ItemData()
        {
            Quantity = itemData.Quantity,
            BackgroundColor = itemData.Color
        };
        item.dataSource = data;
        root.Add(item);

        VisualElement item2 = new ItemElement(data);
        root.Add(item2);

        mapped = items
        .Select(item => new ItemData() { Quantity = item.Quantity, BackgroundColor = item.Color })
        .ToList();
        VisualElement itemList = new ItemList(mapped);
        root.Add(itemList);
    }

    void Update()
    {
        data.BackgroundColor = itemData.Color;
        data.Quantity = itemData.Quantity;

        for (int i = 0; i < items.Count; i++)
        {
            ItemData data = mapped[i];
            data.BackgroundColor = items[i].Color;
            data.Quantity = items[i].Quantity;
        }
    }
}
