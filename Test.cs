using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Test : MonoBehaviour
{
    Dictionary<string, int> dict = new Dictionary<string, int>()
    {
        {"four",4 },
        {"two",2 },
        {"one",1 },
        {"three",3 },
    };
    
    private void Start()
    {
        var d = dict.OrderBy(pair => pair.Value);
        foreach (var pair in d)
        {
            Debug.Log($"{pair.Key} - {pair.Value}");
        }
    }
}
