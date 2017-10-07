using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace HIP
{
    public class EventDetailViewModel : ViewModelBase
    {
        public Event Item { get; set; }
        public EventDetailViewModel(Event item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
