using System;

namespace MovieEntities.Mapping
{
    public class AutomapAttribute : Attribute
    {
        public Type DestType { get; private set; }
        public string DestProperty { get; private set; }

        public AutomapAttribute(Type destType, string destProperty)
        {
            DestType = destType;
            DestProperty = destProperty;
        }
    }
}