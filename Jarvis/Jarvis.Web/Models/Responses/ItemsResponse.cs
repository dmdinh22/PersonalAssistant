using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarvis.Web.Models.Responses
{
    /// <summary>
    /// Generic response class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ItemsResponse<T> : SuccessResponse
    {
        public List<T> Items { get; set; }
    }
}