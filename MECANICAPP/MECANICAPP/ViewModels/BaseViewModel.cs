



namespace MECANICAPP.ViewModels
{

    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;


    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged ([CallerMemberName]string propertyName = null)
        {
            PropertyChanged.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
        public void SetValue<T>(ref T backingFiled,T value ,[CallerMemberName]string propertyName = null)
        {
            if(EqualityComparer<T>.Default.Equals(backingFiled,value))
            {
                return;
            }
            backingFiled = value;
            OnPropertyChanged(propertyName); 
        }
    }
}
