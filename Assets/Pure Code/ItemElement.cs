using UnityEngine;
using UnityEngine.UIElements;

namespace UI.PureCode
{
    [UxmlElement]
    public partial class ItemElement : BindableElement
    {
        private readonly VisualElement container;
        private readonly Label label;

        public ItemElement()
        {

        }

        public ItemElement(UIItemData data)
        {
            container = new();
            container.SetBinding("style.backgroundColor", new DataBinding()
            {
                dataSource = data.BackgroundColor,
                bindingMode = BindingMode.ToTarget
            });
            Add(container);

            label = new()
            {
                text = "#000"
            };
            container.Add(label);
        }
    }
}