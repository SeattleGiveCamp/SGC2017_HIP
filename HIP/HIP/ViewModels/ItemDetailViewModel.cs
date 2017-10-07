using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace HIP
{
    public class ItemDetailViewModel : ViewModelBase
    {
        public Event Item { get; set; }
        public ItemDetailViewModel(Event item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
