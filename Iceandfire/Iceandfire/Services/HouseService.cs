using Iceandfire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceandfire.Services
{
    public class HouseService:Service
    {

        //Get all the houses async
        public async Task<List<House>> GetHousesAsync()
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, "api/houses?pageSize=5"));
        }
        //Get all the houses async by uri parameter
        public async Task<List<House>> GetHousesAsync(string uri)
        {
            return await GetAsync<List<House>>(new Uri(uri));
        }
        //Get the next page Houses async. It can be used after the first page loaded.
        public async Task<List<House>> GetNextHousesAsync(string uri)
        {
            return await GetAsync<List<House>>(new Uri(uri));
        }
        //Get a single house by an URI
        public async Task<House> GetHouseAsync(string Uriid)
        {
            //get the house asynch and fill the properties with data
            House h = await GetAsync<House>(new Uri(Uriid));
            if (!h.swornMembers.Equals(""))
            {
                foreach(string s in h.swornMembers)
                {

                    Character c = await GetAsync<Character>(new Uri(s));
                    h.swornMemberList.Add(c);
                }
            }
            if (!h.cadetBranches.Equals(""))
            {
                foreach(string s in h.cadetBranches)
                {
                    Character c = await GetAsync<Character>(new Uri(s));
                    h.cadetBranchesList.Add(c);
                }
            }
            if (!h.overlord.Equals(""))
            {
                House oH = await GetAsync<House>(new Uri(h.overlord));
                h.overLordC = oH;

            }
            if (!h.founder.Equals(""))
            {
                Character oc = await GetAsync<Character>(new Uri(h.founder));
                h.founderC = oc;

            }

            return h;
        }
    }
}
