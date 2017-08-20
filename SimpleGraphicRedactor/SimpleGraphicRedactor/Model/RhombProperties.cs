using System.Windows.Media;

namespace SimpleGraphicRedactor.Model
{
    public static class RhombProperties
    {
        public static string Stroke { get; set; } = nameof(Brushes.Black);

        public static string Fill { get; set; } = nameof(Brushes.LightBlue);

        public static double StrokeThickness { get; set; } = 1.0;
    }
}