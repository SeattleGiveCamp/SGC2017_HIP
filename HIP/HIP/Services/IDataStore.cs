using System.Collections.Generic;
using System.Threading.Tasks;
using HIP.MobileAppService.Models;
using HIP.Models;

namespace HIP
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<bool> RegisterUserAsync(UserModel item);
        Task<bool> CheckInUserOnEventAsync(EventCheckInModel item);
    }
}
