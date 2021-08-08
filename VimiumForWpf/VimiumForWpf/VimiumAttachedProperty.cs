using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace VimiumForWpf
{
    partial class Vimium
    {
        static Vimium()
        {
            VimiumProperty = DependencyProperty.RegisterAttached("Vimium", typeof(object), typeof(Vimium), new FrameworkPropertyMetadata(PropertyChanged));
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            Application.Current.MainWindow.Loaded += Vimium_ContentChanged;
        }

        private static void Vimium_ContentChanged(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }
            CurrentPopupList.Clear();

            foreach (var pair in _allVimiumControls)
            {
                pair.Popup.Label.Content = Alphabet[CurrentPopupList.Count].ToUpper();
                CurrentPopupList.Add(CurrentPopupList.Count, pair.Popup);
            }
        }

       public static readonly DependencyProperty VimiumProperty;
        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RegisterVimiumControl(d as FrameworkElement);
        }

        public static void RegisterVimiumControl(FrameworkElement element)
        {
            if (element == null) return;

            VimiumPopup popUp = new VimiumPopup();
            popUp.PlacementTarget = element;
            popUp.StaysOpen = true;
            popUp.Placement = PlacementMode.Left;
            popUp.Visibility = Visibility.Visible;
            popUp.Target = element;

            _allVimiumControls?.Add(new PopupControlPair(element, popUp));
        }

        public static Dictionary<int, VimiumPopup> CurrentPopupList { get; } = new Dictionary<int, VimiumPopup>();
        public static List<string> Alphabet { get; } = new List<string>()
        {"a","b","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z", };

        private static List<PopupControlPair> _allVimiumControls = new List<PopupControlPair>();

        public static T FindVisualParent<T>(FrameworkElement child) where T : class
        {
            if (child == null) return null;
            object parentObject = child.Parent;
            if (parentObject == null) return default;
            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            return FindVisualParent<T>(parentObject as FrameworkElement);
        }

        public static void SetVimium(UIElement element, object value)
        {
            element?.SetValue(VimiumProperty, value);
        }

        public static double GetVimiun(UIElement element, object value)
        {
            if (element == null) return 0;
            return (double)element.GetValue(VimiumProperty);
        }
    }
}
