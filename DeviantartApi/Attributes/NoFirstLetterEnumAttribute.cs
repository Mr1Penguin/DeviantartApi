﻿using System;

namespace DeviantartApi.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NoFirstLetterEnumAttribute : Attribute
    {
    }
}
