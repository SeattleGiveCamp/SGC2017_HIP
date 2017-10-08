﻿using System;
using System.Windows.Input;
// using FormsToolkit;
using HIP.Models;
using HIP.Services;
using Xamarin.Forms;

namespace HIP
{
	public class ProgramListItemViewModel
	{
		public ProgramListItemViewModel(Event model)
		{
			Event = model;
            Name = model.Name;
            Description = model.Description;
            Date = model.Start.ToString();
		}

        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

		public Event Event { get; set; }
	}
}
