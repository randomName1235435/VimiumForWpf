using System;
using System.Windows.Input;

namespace VimiumForWpf
{
    public class ShowVimiumPopupsCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (VimiumControlManager.LastLoadedVimiumControl == null) return;
            VimiumControlManager.LastLoadedVimiumControl.ShowVimiumPopups();
        }

        public event EventHandler CanExecuteChanged;
    }
}
