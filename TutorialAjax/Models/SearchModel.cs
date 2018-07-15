using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorialAjax.Models
{
    public class SearchModel
    {
        public SearchModel()
        {
            Books = new List<BookModel>();
        }

        public string Titolo { get; set; }

        public List<BookModel> Books { get; set; }
        public bool ShowGrid { get; set; }
    }
}