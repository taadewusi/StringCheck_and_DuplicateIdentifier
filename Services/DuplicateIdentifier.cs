using System;
using System.Collections.Generic;

public class DuplicateIdentifier<T> where T : IEquatable<T>
{
    public List<string> IdentifyDuplicates(List<T> cA, List<T> cS)
    {
        List<string> result = new List<string>();

        if (cA == null || cS == null)
        {
            throw new ArgumentNullException("Collections cannot be null.");
        }

        HashSet<T> setA = new HashSet<T>(cA); // Use a HashSet for fast lookups.

        foreach (T item in cS)
        {
            if (setA.Contains(item))
            {
                result.Add($"{item}:true");
            }
            else
            {
                result.Add($"{item}:false");
            }
        }

        return result;
    }
}
