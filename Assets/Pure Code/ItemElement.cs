using Unity.Properties;
using UnityEngine.UIElements;
using UnityEngine;

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
            dataSource = data;
            container = new();

            DataBinding colorBinding = new DataBinding()
            {
                dataSourcePath = new PropertyPath(nameof(UIItemData.BackgroundColor)),
                bindingMode = BindingMode.ToTarget
            };

            DataBinding backgroundColorBinding = new DataBinding()
            {
                dataSourcePath = new PropertyPath(nameof(UIItemData.BackgroundColor)),
                bindingMode = BindingMode.ToTarget
            };
            backgroundColorBinding.sourceToUiConverters.AddConverter((ref Color color) => new StyleColor(new Color(color.r, color.g, color.b, 0.4f)));

            container.SetBinding($"{nameof(VisualElement.style)}.{nameof(IStyle.backgroundColor)}", backgroundColorBinding);
            container.style.borderTopWidth = 20;
            container.SetBinding("style.borderTopColor", colorBinding);
            Add(container);

            label = new();
            label.SetBinding(nameof(label.text), new DataBinding()
            {
                dataSourcePath = new PropertyPath(nameof(UIItemData.Quantity)),
                bindingMode = BindingMode.ToTarget,
            });
            container.Add(label);
        }
    }
}

