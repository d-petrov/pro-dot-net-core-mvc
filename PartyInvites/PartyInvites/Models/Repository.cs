using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public static class Repository
    {
        internal static IList<GuestResponse> responses = new List<GuestResponse>();
        public static bool Add(GuestResponse response)
        {
            try
            {
                if (responses.First<GuestResponse>(resp => resp.Name == response.Name) != null)
                {
                    return false;
                }
            }
            catch 
            {                
            }
            responses.Add(response);
            return true;
        }
        public static IEnumerable<GuestResponse> Responses
        {
            get
            {
                return responses;
            }
        }
    }
}
