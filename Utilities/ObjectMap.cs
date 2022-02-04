﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Utilities
{
   public static class ObjectMap
    {
        public static T MapObject<T>(this object obj)
        {
            T copiedObject = Activator.CreateInstance<T>();
            Type objectToMapDefinition = obj.GetType();
            Type copiedObjectType = copiedObject.GetType();
            foreach (PropertyInfo sourceProperty in objectToMapDefinition.GetProperties())
            {
                PropertyInfo targetProperty = copiedObjectType.GetProperty(sourceProperty.Name);
                if (targetProperty != null)
                    targetProperty.SetValue(copiedObject, sourceProperty.GetValue(obj));
            }
            return copiedObject;
        }
        public static void UpdateObject(this object objToUpdate, object objToMap)
        {
            Type objectToMapDefinition = objToMap.GetType();
            Type objectToUpdateDefinition = objToUpdate.GetType();
            foreach (PropertyInfo property in objectToMapDefinition.GetProperties())
            {
                PropertyInfo propertyToUpdate = objectToUpdateDefinition.GetProperty(property.Name);
                if (propertyToUpdate != null)
                    propertyToUpdate.SetValue(objToUpdate, property.GetValue(objToMap));
            }
        }
    }
}
