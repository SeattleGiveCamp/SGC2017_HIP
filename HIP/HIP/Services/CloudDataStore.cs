﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;
using HIP.Models;
using HIP.MobileAppService.Models;

namespace HIP
{
    public class CloudDataStore : IDataStore<Event>
    {
        HttpClient client;
        IEnumerable<Event> items;

        public CloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            client.DefaultRequestHeaders.TryAddWithoutValidation("MagicCookie", "chocolate-chip");

            items = new List<Event>();
        }

        public async Task<IEnumerable<Event>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                string arg = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
                var json = await client.GetStringAsync($"api/Event/getByEndDate/" + arg);
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Event>>(json));
            }

            return items;
        }

        public async Task<Event> GetItemAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Event>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Event item)
        {
            if (item == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

		public async Task<bool> RegisterUserAsync(UserModel user)
		{
			if (user == null || !CrossConnectivity.Current.IsConnected)
				return false;

			var serializedItem = JsonConvert.SerializeObject(user);

			var response = await client.PostAsync($"api/User", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

			return response.IsSuccessStatusCode;
		}

        public async Task<bool> UpdateItemAsync(Event item)
        {
            if (item == null || item.Id == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/item/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CheckInUserOnEventAsync(EventCheckInModel user)
        {
			if (user == null || !CrossConnectivity.Current.IsConnected)
				return false;

			var serializedItem = JsonConvert.SerializeObject(user);

			var response = await client.PostAsync($"api/EventCheckIn", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

			return response.IsSuccessStatusCode;
        }
    }
}
