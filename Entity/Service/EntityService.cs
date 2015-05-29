using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Entity
{
    public static class EntityService
    {
        public static void CopyAllPropertiesFrom<T>(this T obj, T entity) where T : IBaseEntity
        {
            Type objType = obj.GetType();
            if (objType.ToString() != entity.GetType().ToString()) {
                Exception e = new Exception("EntityService.CopyAllFieldsFrom type mismatch");
                throw e;
            }
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                PropertyInfo entityProperty = entity.GetType().GetProperty(property.Name);
                property.SetValue(obj, entityProperty.GetValue(entity, null));
            }
        }
    }
}
