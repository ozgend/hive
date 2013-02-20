using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Denolk.XchangeWrapper.Model
{
    public class Meeting
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public List<string> Invited { get; set; }
    }
}
