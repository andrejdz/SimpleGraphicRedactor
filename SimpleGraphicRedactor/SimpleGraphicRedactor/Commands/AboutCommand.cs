using System.Windows;

namespace SimpleGraphicRedactor.Commands
{
    public class AboutCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show("Hello, dear friend!\nIt's my new amazing app", "About");
        }
    }
}