using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Diagnostics;

public class PerformanceTest : MonoBehaviour
{
    private List<int> numbers;
    [SerializeField] private int searchValue = 500000;

    void Start()
    {
        // リストの初期化
        numbers = new List<int>();
        for (int i = 0; i < searchValue; i++)
        {
            numbers.Add(i);
        }

        // LINQを使った検索の計測
        Stopwatch stopwatchLinq = new Stopwatch();
        stopwatchLinq.Start();
        var linqResult = numbers.Where(num => num == searchValue).FirstOrDefault();
        stopwatchLinq.Stop();
        UnityEngine.Debug.Log($"LINQ検索にかかった時間: {stopwatchLinq.ElapsedMilliseconds} ms");

        // List.Findを使った検索の計測
        Stopwatch stopwatchFind = new Stopwatch();
        stopwatchFind.Start();
        var findResult = numbers.Find(num => num == searchValue);
        stopwatchFind.Stop();
        UnityEngine.Debug.Log($"List.Find検索にかかった時間: {stopwatchFind.ElapsedMilliseconds} ms");
    }
}
