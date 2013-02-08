using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L4D2Launcher
{
    public class CommandAliasAttribute : Attribute
    {
        public string Alias { get; set; }
        public bool HasValue { get; set; }

        public CommandAliasAttribute(string alias, bool hasValue)
        {
            this.Alias = alias;
            this.HasValue = hasValue;
        }

    }
}
