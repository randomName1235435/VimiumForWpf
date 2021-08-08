using System.Windows;
using System.Windows.Controls.Primitives;

namespace VimiumForWpf
{
    public partial class VimiumPopup : Popup
    {
        public VimiumPopup()
        {
            InitializeComponent();
        }

        public UIElement Target { get; set; }
    }
}
