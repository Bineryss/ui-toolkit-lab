using Mono.Cecil;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIBuilder.UI
{

    [UxmlElement]
    public partial class ItemElement : VisualElement
    {
        public ItemData Data { set => container.dataSource = value; }

        private VisualElement container;
        public ItemElement()
        {
            Init();
        }
        public ItemElement(ItemData data)
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
