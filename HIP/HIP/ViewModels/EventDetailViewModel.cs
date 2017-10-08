using System;
using System.Windows.Input;
using Xamarin.Forms;
using HIP.Models;
using HIP.ViewModels;

namespace HIP
{
    public class EventDetailViewModel : ViewModelBase
    {
        public EventViewModel Item { get; set; }
        public EventDetailViewModel(EventViewModel item = null)
        {
            Title = item?.Description;
            Item = item;
        }
    }
}
