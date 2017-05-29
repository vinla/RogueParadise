using System;
using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class UnityViewModel : MonoBehaviour, INotifyPropertyChanged
    {
        public String Name;

        public NoesisXaml Xaml;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
