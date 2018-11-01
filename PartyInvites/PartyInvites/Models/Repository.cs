using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public static class Repository
    {
        internal static IList<GuestResponse> responses = new List<GuestResponse>();
        public static void Add(GuestResponse response)
        {
            responses.Add(response);
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
