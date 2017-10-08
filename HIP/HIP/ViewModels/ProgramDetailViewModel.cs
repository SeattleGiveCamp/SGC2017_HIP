using System;
using System.Windows.Input;
using Xamarin.Forms;
using HIP.Models;
using HIP.ViewModels;

namespace HIP
{
    public class ProgramDetailViewModel : ViewModelBase
    {
        public Event Item { get; set; }

        public ProgramDetailViewModel(Event item = null)
        {
            Title = item?.Name;
            Item = item;
			Name = item.Name;
			Description = item.Description;
			Date = DateTime.Now.ToString();
        }

		public string Name { get; set; }
		public string Description { get; set; }
		public string Date { get; set; }
    }
}
