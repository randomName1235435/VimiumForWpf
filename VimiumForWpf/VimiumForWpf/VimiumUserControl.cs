using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace VimiumForWpf
{
    public class VimiumUserControl : UserControl
    {
        public VimiumUserControl()
        {
            Loaded += (sender, args) => VimiumControlManager.LastLoadedVimiumControl = this;
        }

        private bool isShowing;

        public void ShowVimiumPopups()
        {
            isShowing = !isShowing;
            if (isShowing)
            {
                foreach (var popUp in Vimium.CurrentPopupList)
                {
                    popUp.Value.IsOpen = true;
                }
            }
            else
            {
                foreach (var popUp in Vimium.CurrentPopupList)
                {
                    popUp.Value.IsOpen = false;
                }
            }

            if (isShowing)
            {
                Focusable = true;
                Focus();
                KeyDown += Control_KeyDown;
            }
        }
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {

            foreach (var popUp in Vimium.CurrentPopupList)
            {
                popUp.Value.IsOpen = false;
            }
            isShowing = false;
            var keyChar = e.Key.ToString().ToLower();
            var keyIndex = Vimium.Alphabet.IndexOf(keyChar);
            if (Vimium.CurrentPopupList.ContainsKey(keyIndex))
            {
                var control = Vimium.CurrentPopupList[keyIndex].Target;

                if (control.Visibility == Visibility.Visible
                    && control.IsEnabled)
                {
                    var button = control as Button;
                    button?.Command?.Execute(button.CommandParameter);

                    var toggleButton = control as ToggleButton;
                    if (toggleButton != null)
                    {
                        if (toggleButton.Command != null)
                        {
                            toggleButton.Command.Execute(button.CommandParameter);
                        }
                        else
                        {
                            toggleButton.IsChecked = !toggleButton?.IsChecked;
                        }
                    }
                }
                e.Handled = true;
                KeyDown -= Control_KeyDown;
                Focusable = false;
            }
        }

    }
}
