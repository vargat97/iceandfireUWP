using Iceandfire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.Services
{
    class HouseService:Service
    {

        //Get all the houses async
        public async Task<List<House>> GetHousesAsync()
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, "api/houses?pageSize=5"));
        }
        //Get the next page Houses async. It can be used after the first page loaded.
        public async Task<List<House>> GetNextHousesAsync(string uri)
        {
            return await GetAsync<List<House>>(new Uri(uri));
        }
        //Get a single house by an URI
        public async Task<House> GetHouseAsync(string Uriid)
        {
            return await GetAsync<House>(new Uri(Uriid));
        }
    }
}
