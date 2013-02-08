using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L4D2Launcher.Model
{
    public class ArgModel
    {
        public string CommandAlias { get; set; }
        public object Value { get; set; }

        public ArgModel(string alias, object value)
        {
            this.CommandAlias = alias;
            this.Value = value;
        }

        public ArgModel(string alias)
            : this(alias, null)
        {

        }

        public override string ToString()
        {
            if (this.Value == null)
            {
                return this.CommandAlias;
            }
            else
            {
                return string.Format("{0} {1}", this.CommandAlias, this.Value);
            }
        }
    }
}
