using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiBookingSystem.Models.ViewModels
{

    public class PageViewModel<T> : IPageViewModel<T> where T : PageData
    {
        public PageViewModel(T currentPage)
        {
            this.CurrentPage = currentPage;

        }

        public T CurrentPage { get; private set; }


    }
    public static class PageViewModel
    {
        /// <summary>
        /// Returns a PageViewModel of type <typeparam name="T"/>.
        /// </summary>
        /// <remarks>
        /// Convenience method for creating PageViewModels without having to specify the type as methods can use type inference while constructors cannot.
        /// </remarks>
        public static PageViewModel<T> Create<T>(T page) where T : PageData
        {
            return new PageViewModel<T>(page);
        }
    }
}

