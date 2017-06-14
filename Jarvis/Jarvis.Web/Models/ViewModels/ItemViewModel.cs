using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarvis.Web.Models.ViewModels
{
    public class ItemViewModel<T>
    {
        public T Item { get; set; }

    }
}