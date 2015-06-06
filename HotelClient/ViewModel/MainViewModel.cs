using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.MVVM;
using System.Collections.ObjectModel;

namespace HotelClient.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        ObservableCollection<object> childViews;

        public ObservableCollection<object> Children { get { return childViews; } }
        public MainViewModel()
        {
            childViews = new ObservableCollection<object>();
            childViews.Add(new GuestsViewModel());

        }

        
    }
}
