using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarvis.Web.Models.Responses
{
    /// <summary>
    /// generic single item response class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ItemResponse<T> : SuccessResponse
    {
        public T Item { get; set; }
    }
}