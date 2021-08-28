using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordGenerater
{
    public class NotifyingProperty
    {
        public NotifyingProperty(string name, Type type, object value)
        {
            Name = name;
            Type = type;
            Value = value;
        }

        public string Name { get; set; }

        public Type Type { get; set; }

        public object Value { get; set; }
    }
}
