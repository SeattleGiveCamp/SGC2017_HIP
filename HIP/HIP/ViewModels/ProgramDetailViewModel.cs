using System;
using System.Windows.Input;
using Xamarin.Forms;
using HIP.Models;

namespace HIP
{
    public class ProgramDetailViewModel : ViewModelBase
    {
        public Event Item { get; set; }

        public ProgramDetailViewModel(Event item = null)
        {
            Title = item?.Description;
            Item = item;
        }
    }
}
