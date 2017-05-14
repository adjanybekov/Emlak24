using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Wohnungstausch24.Core.EnumExtensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            if (enumValue == null)
            {
                return "Not defined";
            }
            var displayAttribute = enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute != null) return displayAttribute.GetName();
            return enumValue.ToString();
        }
    }
}
