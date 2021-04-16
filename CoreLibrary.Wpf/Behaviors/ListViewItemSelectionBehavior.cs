﻿namespace CoreLibrary.Wpf.Behaviors
{
    using Microsoft.Xaml.Behaviors;

    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public class ListViewItemSelectionBehavior : Behavior<ListView>
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ListViewItemSelectionBehavior), new PropertyMetadata(null));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            ListView listView = AssociatedObject;
            listView.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonDown;
            listView.KeyDown += OnKeyDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            ListView listView = AssociatedObject;
            listView.PreviewMouseLeftButtonDown -= OnPreviewMouseLeftButtonDown;
            listView.KeyDown -= OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SelectItem(e);
                e.Handled = true;
            }
        }

        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectItem(e);
        }

        private void SelectItem(RoutedEventArgs args)
        {
            if (Command != null
                && args.OriginalSource is FrameworkElement selectedItem
                && Command.CanExecute(selectedItem.DataContext))
            {
                Command.Execute(selectedItem.DataContext);
            }
        }
    }
}