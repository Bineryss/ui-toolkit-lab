using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.UIBuilder
{

    [UxmlElement]
    public partial class ItemList : VisualElement
    {
        public List<UIItemData> Data
        {
            set
            {
                if (value == null) return;
                internalDataSource = value;
                listView.itemsSource = value;
                listView.RefreshItems();
            }
        }

        private ListView listView;
        private List<UIItemData> internalDataSource = new();
        public ItemList()
        {
            Init();
        }
        public ItemList(List<UIItemData> data)
        {
            internalDataSource = data;
            listView = Init().Q<ListView>();
            listView.makeItem = () => new ItemElement();
            listView.bindItem = (element, index) =>
            {
                ((ItemElement)element).Data = internalDataSource[index];
            };
            listView.itemsSource = internalDataSource;
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
