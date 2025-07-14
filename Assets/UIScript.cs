using System.Collections.Generic;
using System.Linq;
using Inventory;
using UI;
using UI.UIBuilder;
using UnityEngine;
using UnityEngine.UIElements;


public class UIScript : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    [SerializeField] private UIDocument document;
    [SerializeField] private VisualTreeAsset itemA;
    [SerializeField] private Item itemData;


    void Start()
    {
        var root = document.rootVisualElement.Q("container");

        //loading tree asset directly
        VisualElement item = itemA.Instantiate();
        UIItemData data = new(itemData);
        item.dataSource = data;
        root.Add(item);

        //class wrapper for tree asset
        VisualElement item2 = new ItemElement(new UIItemData(itemData));
        root.Add(item2);

        
        List<UIItemData> mapped = items
        .Select(item => new UIItemData(item))
        .ToList();
        VisualElement itemList = new ItemList(mapped);
        root.Add(itemList);
    }
}
