using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface IRestService
    {
        Task<MovieResponse> RefreshDataAsync();
    }
}
