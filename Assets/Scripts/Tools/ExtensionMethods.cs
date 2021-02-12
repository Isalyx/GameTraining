using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static bool IsBetween(this int value, int firstValue, int secondValue, bool isIncludeValues = false)
    {
        return ((float)value).IsBetween(firstValue, secondValue, isIncludeValues);
    }

    public static bool IsBetween(this float value, float firstValue, float secondValue, bool isIncludeValues = false)
    {
        if (isIncludeValues)
        {
            if (value >= firstValue && value <= secondValue)
            {
                return true;
            }
            return false;
        }
        else
        {
            if (value > firstValue && value < secondValue)
            {
                return true;
            }

            return false;
        }
    }



    public static bool IsEquals<T>(T firstItem, T secondItem)
    {
        return false;
    }
}
