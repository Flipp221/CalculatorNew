using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App5
{
    class ModelView : INotifyPropertyChanged
    {
        public ObservableCollection<ModelView> modelViews { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Plus { protected set; get; }
        public ICommand Minus { protected set; get; }
        public ICommand Deleniye { protected set; get; }
        public ICommand Umnoj { protected set; get; }
        public ICommand Delete { protected set; get; }

        ModelView modelView;

        public INavigation Navigation { get; set; }

    }

}
