using UnityEngine;
using UnityEngine.UIElements;

namespace UI.UIBuilder
{
    public class ItemElement : VisualElement
    {
        private static readonly VisualTreeAsset uxml = Resources.Load<VisualTreeAsset>("item");
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
            if (uxml == null)
            {
                Debug.Log("⛔ Failed to load uxml file for ItemElement!");
                return new VisualElement();
            }

            container = uxml.Instantiate();
            Add(container);
            return container;
        }
    }
}
