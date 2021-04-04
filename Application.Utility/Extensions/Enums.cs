using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.Utility.Extensions
{
    public static class Enums
    {
        public static DisplayAttribute GetDisplayAttribute(this Enum _mAt)
        {
            DisplayAttribute attr = _mAt.GetType()?.GetField(_mAt.ToString())?.GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>().Where(new Func<DisplayAttribute, bool>(delegate (DisplayAttribute _mEnum)
            {
                return true;
            })).FirstOrDefault() ?? new DisplayAttribute() { Name = _mAt.ToString() };

            attr.ShortName = _mAt.ToString();
            attr.Order = Convert.ToInt32(_mAt);
            return attr;
        }
    }
}
