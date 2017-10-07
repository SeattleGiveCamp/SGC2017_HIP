using System;
using System.Windows.Input;
using Xamarin.Forms;
using HIP.Models;

namespace HIP
{
    public class EventDetailViewModel : ViewModelBase
    {
        public Event Item { get; set; }
        public EventDetailViewModel(Event item = null)
        {
            Title = item?.Description;
            Item = item;
        }
    }
}
