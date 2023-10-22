using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.Utils
{
    public static class Utilitary
    {
        
        public static T GetPropValue<T>(this object value, string propertyName)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            if (String.IsNullOrEmpty(propertyName)) { throw new ArgumentException("propertyName"); }
            PropertyInfo info = value.GetType().GetProperty(propertyName);
            return (T)info.GetValue(value, null);
        }
        public static FieldInfo GetFieldInfo(this Type objType, string fieldName, BindingFlags flags, bool isFirstTypeChecked = true)
        {
            FieldInfo fieldInfo = objType.GetField(fieldName, flags);
            if (fieldInfo == null && objType.BaseType != null)
            {
                fieldInfo = objType.BaseType.GetFieldInfo(fieldName, flags, false);
            }
            if (fieldInfo == null && isFirstTypeChecked)
            {
                throw new MissingFieldException(String.Format("Field {0}.{1} could not be found with the following BindingFlags: {2}", objType.ReflectedType.FullName, fieldName, flags.ToString()));
            }
            return fieldInfo;
        }
    }
}
