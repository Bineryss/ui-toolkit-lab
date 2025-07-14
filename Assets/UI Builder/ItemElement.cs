using Inventory;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.UIBuilder
{

    [UxmlElement]
    public partial class ItemElement : VisualElement
    {
        public UIItemData Data { set => container.dataSource = value; }

        private VisualElement container;
        public ItemElement()
        {
            Init();
        }
        public ItemElement(UIItemData data)
        {
            VisualElement container = Init();
            container.dataSource = data;
        }

        private VisualElement Init()
        {
            VisualTreeAsset asset = Resources.Load<VisualTreeAsset>("item");
            container = asset.Instantiate();
            Add(container);
            return container;
        }
    }
}
