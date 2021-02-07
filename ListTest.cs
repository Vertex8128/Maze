using System.Collections.Generic;
using UnityEngine;

public class ListTest : MonoBehaviour
{
    private List<int> numbers = new List<int>{3,5,7,2,3,8,9,3,4,8,9,2,3,0,8};
    void Start()
    {
        Dictionary<int, int> countedResult = new Dictionary<int, int>();

        foreach (var num in numbers)
        {
            if (!countedResult.ContainsKey(num))
            {
                countedResult.Add(num,1);
            }
            else
            {
                countedResult[num] += 1;
            }
        }

        foreach (KeyValuePair<int, int> result in countedResult)
        {
            Debug.Log($"Число {result.Key} встречается в коллекции {result.Value} раз");
        }
    }
}
