using System;

namespace DeviantartApi.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DateTimeFormatAttribute : Attribute
    {
        public string ToStringFormat { get; private set; }

        public DateTimeFormatAttribute(string toStringFormat)
        {
            ToStringFormat = toStringFormat;
        }
    }
}
