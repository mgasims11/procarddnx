﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ProCardLib.DataModel
{
    public class Table : Dictionary<string,Deck>
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var deck in this)
            {
                sb.AppendLine(deck.ToString());
            }
            return sb.ToString();
        }
    }
}
