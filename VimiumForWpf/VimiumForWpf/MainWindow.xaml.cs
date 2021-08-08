using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Input;

namespace VimiumForWpf
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var keybinding = new KeyBinding
            {
                Key = Key.Q,
                Modifiers = ModifierKeys.Control,
                Command = new ShowVimiumPopupsCommand(),
            };
            this.InputBindings.Add(keybinding);
            InitializeComponent();
        }
    }
}
