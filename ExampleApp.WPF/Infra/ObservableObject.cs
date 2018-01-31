using System;
using System.ComponentModel;

namespace ExampleApp.WPF.Infra
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetAndRaisePropertyChangedEvent(string propertyName, Action set)
        {
            set();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
