namespace SimpleGraphicRedactor.Commands
{
    class OpenRhombPropertyDialog : BaseCommand
    {
        private MainWindow mainWindow;

        public OpenRhombPropertyDialog(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {            
            RhombPropertyDialog RhombDialog = new RhombPropertyDialog();
            RhombDialog.Owner = mainWindow;
            RhombDialog.ShowDialog();
        }
    }
}
