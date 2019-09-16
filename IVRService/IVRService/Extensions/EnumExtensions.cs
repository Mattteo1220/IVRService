﻿using System;
using System.ComponentModel;

namespace IVRService.Extensions
{
  public static class EnumExtensions
  {
    public static string GetDescription<t>(this t enumerationValue) where t : struct
    {
      var type = enumerationValue.GetType();
      if (!type.IsEnum)
      {
        throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
      }
      var memberInfo = type.GetMember(enumerationValue.ToString());
      if (memberInfo.Length > 0)
      {
        var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attrs.Length > 0)
        {
          return ((DescriptionAttribute)attrs[0]).Description;
        }
      }
      return enumerationValue.ToString();
    }
  }
}
