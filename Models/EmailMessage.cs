using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class EmailMessage : Entity
    {
        public string To { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
