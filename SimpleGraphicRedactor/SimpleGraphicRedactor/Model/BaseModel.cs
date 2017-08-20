using System.ComponentModel;

namespace SimpleGraphicRedactor.Model
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }
    }
}
