using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using HIP.Models;
namespace HIP
{
    public class ViewModelBase : BaseViewModel
    {
        public IDataStore<Event> DataStore => DependencyService.Get<IDataStore<Event>>() ?? new MockDataStore();
        
    }
}
