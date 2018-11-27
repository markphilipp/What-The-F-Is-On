using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace MovieEntities.Mapping
{
    public interface IAutomapAttributeMapper
    {
        /// <summary>
        /// Create all of the maps needed for the source/dest types based on custom attributes
        /// </summary>
        void CreateCustomPropertyMaps();
    }

    public class AutomapAttributeMapper : IAutomapAttributeMapper
    {
        public AutomapAttributeMapper(IMappingExpression mappingExpression, Type sourceType, Type destinationType)
        {
            MappingExpression = mappingExpression;
            SourceType = sourceType;
            DestinationType = destinationType;
        }

        public IMappingExpression MappingExpression { get; private set; }
        public Type SourceType { get; private set; }
        public Type DestinationType { get; private set; }

        /// <summary>
        /// Create all of the maps needed for the source/dest types based on custom attributes
        /// </summary>
        public void CreateCustomPropertyMaps()
        {
            foreach (var customPropertyMapAttr in GetCustomPropertyMaps())
                CreateCustomPropertyMap(customPropertyMapAttr);
        }

        /// <summary>
        /// Get properties that have a <see cref="AutomapAttribute" /> to direct custom mappings
        /// </summary>
        /// <returns>List of properties that match the criteria </returns>
        private IEnumerable<PropertyInfo> GetCustomPropertyMaps()
        {
            return this.SourceType.GetProperties()
                .Where(p => GetCustomMapAttribute(p) != null);
        }

        /// <summary>
        /// Creates a custom property mapping for the property
        /// </summary>
        /// <param name="newMap">The newly created mapping expression</param>
        /// <param name="customMappedProp">The property that has the custom attribute</param>
        /// <param name="modelClass">The destination model class</param>
        private void CreateCustomPropertyMap(PropertyInfo customMappedProp)
        {
            var attribute = GetCustomMapAttribute(customMappedProp);
            this.MappingExpression.ForMember(customMappedProp.Name, conf => conf.MapFrom(attribute.DestProperty));
        }

        /// <summary>
        /// Gets the custom attribute for a property
        /// </summary>
        /// <param name="property">The property to check</param>
        /// <param name="modelClass">The destination class</param>
        /// <returns>The matching attribute if it exists.  Null otherwise.</returns>
        private AutomapAttribute GetCustomMapAttribute(PropertyInfo property)
        {
            var attr = property.GetCustomAttribute<AutomapAttribute>();
            return attr.DestType == this.DestinationType ? attr : null;
        }
    }
}