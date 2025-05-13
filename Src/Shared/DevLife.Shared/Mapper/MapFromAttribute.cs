using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Shared.Mapper
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MapFromAttribute : Attribute
    {
        public string SourceProperty { get; }
        public MapFromAttribute(string sourceProperty)
        {
            SourceProperty = sourceProperty;
        }

    }
}
