using System.Windows;

namespace VimiumForWpf
{
    partial class Vimium
    {
        class PopupControlPair
        {
            public PopupControlPair(FrameworkElement control, VimiumPopup popup)
            {
                Control = control;
                Popup = popup;
            }

            public FrameworkElement Control { get; set; }
            public VimiumPopup Popup { get; set; }
        }
    }
}
