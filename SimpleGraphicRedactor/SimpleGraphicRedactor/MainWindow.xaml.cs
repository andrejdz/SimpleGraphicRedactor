using System;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using SimpleGraphicRedactor.Repository;
using System.Windows;
using SimpleGraphicRedactor.DAL;
using SimpleGraphicRedactor.Commands;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Shapes;
using SimpleGraphicRedactor.Model;

namespace SimpleGraphicRedactor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ColorRepository listOfColors = new ColorRepository();

        private List<RhombModel> listOfRhombs = new List<RhombModel>();

        private ICommand _aboutCommand = null;
        public ICommand AboutCommand => _aboutCommand ?? (_aboutCommand = new AboutCommand());

        private ICommand _openRhombPropertyDialog = null;
        public ICommand OpenRhombPropertyDialog => _openRhombPropertyDialog ?? (_openRhombPropertyDialog = new OpenRhombPropertyDialog(this));

        public MainWindow()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
            this.MouseMove += MainWindow_MouseMove;

            cbColorMain.ItemsSource = listOfColors.ListOfColors;
            cbColorMain.SelectedItem = RhombProperties.Stroke;
            cbColorBackMain.ItemsSource = listOfColors.ListOfColors;
            cbColorBackMain.SelectedItem = RhombProperties.Fill;
            slThicknessMain.Value = RhombProperties.StrokeThickness;

            CommandBinding saveBinding = new CommandBinding(ApplicationCommands.Save);
            saveBinding.Executed += SaveBinding_Executed;
            saveBinding.CanExecute += SaveBinding_CanExecute;
            this.CommandBindings.Add(saveBinding);
        }

        private void SaveBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = canvasToRender.Children.Count != 0;
        }

        private void SaveBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Files .xml|*.xml|All files|*.*";
            var result = sfd.ShowDialog();
            if(result == true)
            {
                RhombDAL saveToFile = new RhombDAL();
                saveToFile.Save(sfd.FileName, listOfRhombs);
            }
        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            double x = e.GetPosition(canvasToRender).X;
            double y = e.GetPosition(canvasToRender).Y;

            Rectangle rect = new Rectangle()
            {
                Height = 50,
                Width = 50,
            };

            TransformGroup tg = new TransformGroup();
            tg.Children.Add(new SkewTransform(15, 15));
            tg.Children.Add(new RotateTransform(-45));

            rect.RenderTransform = tg;

            rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(RhombProperties.Fill);
            rect.Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString(RhombProperties.Stroke);
            rect.StrokeThickness = RhombProperties.StrokeThickness;

            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);

            canvasToRender.Children.Add(rect);

            RhombModel rhombToSave = new RhombModel
            {
                Stroke = RhombProperties.Stroke,
                Fill = RhombProperties.Fill,
                StrokeThickness = RhombProperties.StrokeThickness,
                X = x,
                Y = y
            };

            listOfRhombs.Add(rhombToSave);
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            double x = Math.Round(e.GetPosition(canvasToRender).X, 2);
            double y = Math.Round(e.GetPosition(canvasToRender).Y, 2);

            tbX.Text = x.ToString();
            tbY.Text = y.ToString();
        }
    }
}
