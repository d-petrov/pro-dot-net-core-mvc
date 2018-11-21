using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SportsStore.Infrastructure
{
    public static class SessionExtensions
    {        
        public static void SetJson(this ISession session, string key, object value)
        {
            if(value != null)
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }            
        }
        public static Type GetJson<Type>(this ISession session, string key)
        {
            string objData = session.GetString(key);

            return !string.IsNullOrEmpty(objData) ?
                JsonConvert.DeserializeObject<Type>(objData) : default(Type);                    
        }
    }
}
