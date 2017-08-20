using System.Collections.Generic;
using System.Windows.Media;

namespace SimpleGraphicRedactor.Repository
{
    public class ColorRepository
    {
        private readonly List<string> listOfColors;

        public List<string> ListOfColors
        {
            get { return listOfColors; }
        }

        public ColorRepository()
        {
            listOfColors = new List<string>()
            {
                nameof(Brushes.Black),
                nameof(Brushes.Green),
                nameof(Brushes.Blue),
                nameof(Brushes.Red),
                nameof(Brushes.LightBlue),
            };
        }
    }
}
