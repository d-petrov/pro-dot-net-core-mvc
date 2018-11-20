using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace SportsStore.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest http) => http.QueryString.HasValue ?
                string.Concat(http.Path, http.QueryString) : http.Path.ToString();
    }
}
