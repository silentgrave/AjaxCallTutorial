using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorialAjax.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string DataInserimento { get; set; }
        public string ColorHex { get; set; }
    }
}