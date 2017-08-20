using System.Windows;
using SimpleGraphicRedactor.Repository;
using SimpleGraphicRedactor.Model;

namespace SimpleGraphicRedactor
{
    /// <summary>
    /// Interaction logic for RhombPropertyDialog.xaml
    /// </summary>
    public partial class RhombPropertyDialog : Window
    {
        public RhombPropertyDialog()
        {
            InitializeComponent();

            ColorRepository listOfColors = new ColorRepository();

            cbColor.ItemsSource = listOfColors.ListOfColors;
            cbColor.SelectedItem = RhombProperties.Stroke;

            cbColorBack.ItemsSource = listOfColors.ListOfColors;
            cbColorBack.SelectedItem = RhombProperties.Fill;

            slThickness.Value = RhombProperties.StrokeThickness;
        }
    }
}
