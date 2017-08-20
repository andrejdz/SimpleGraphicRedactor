using System;
using System.Xml.Serialization;

namespace SimpleGraphicRedactor.Model
{
    [Serializable]
    public class RhombModel : BaseModel
    {
        private string _stroke;

        [XmlAttribute]
        public string Stroke
        {
            get { return _stroke; }
            set
            {
                _stroke = value;
                RhombProperties.Stroke = _stroke;
                OnPropertyChanged(nameof(Stroke));
            }
        }

        private string _fill;

        [XmlAttribute]
        public string Fill
        {
            get { return _fill; }
            set
            {
                _fill = value;
                RhombProperties.Fill = _fill;
                OnPropertyChanged(nameof(Fill));
            }
        }

        private double _strokeThickness;

        [XmlAttribute]
        public double StrokeThickness
        {
            get { return _strokeThickness; }
            set
            {
                _strokeThickness = value;
                RhombProperties.StrokeThickness = _strokeThickness;
                OnPropertyChanged(nameof(StrokeThickness));
            }
        }

        [XmlAttribute]
        public double X { get; set; }

        [XmlAttribute]
        public double Y { get; set; }
    }
}
