using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LinqTest : MonoBehaviour
{
    private List<int> numbers = new List<int>{3,5,7,2,3,8,9,3,4,8,9,2,3,0,8};
    void Start()
    {
        var countedResult = numbers.GroupBy(n => n).Select(g => new {NumValue = g.Key, Count = g.Count()});
        foreach (var result in countedResult)
        {
            Debug.Log($"Число {result.NumValue} встречается в коллекции {result.Count} раз");
        }
    }
}