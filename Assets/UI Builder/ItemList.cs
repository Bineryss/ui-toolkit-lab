using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.UIBuilder
{

    [UxmlElement]
    public partial class ItemList : VisualElement
    {
        public ItemList()
        {
            Init();
        }
        public ItemList(List<UIItemData> data)
        {
            ListView listView = Init().Q<ListView>();
            listView.makeItem = () => new ItemElement();
            listView.bindItem = (element, index) =>
            {
                ((ItemElement) element).Data = data[index];
            };
            listView.itemsSource = data;
            listView.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;
            listView.fixedItemHeight = 0;
        }

        private VisualElement Init()
        {
            VisualTreeAsset asset = Resources.Load<VisualTreeAsset>("item-list");
            VisualElement container = asset.Instantiate();
            Add(container);
            return container;
        }
    }
}
