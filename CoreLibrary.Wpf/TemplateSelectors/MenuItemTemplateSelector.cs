namespace CoreLibrary.Wpf.TemplateSelectors
{
    using MahApps.Metro.Controls;

    using System.Windows;
    using System.Windows.Controls;

    public class MenuItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GlyphDataTemplate { get; set; }

        public DataTemplate ImageDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return item is HamburgerMenuGlyphItem
                ? GlyphDataTemplate
                : item is HamburgerMenuImageItem
                ? ImageDataTemplate
                : base.SelectTemplate(item, container);
        }
    }
}