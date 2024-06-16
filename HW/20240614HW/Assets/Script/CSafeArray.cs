using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSafeArray : MonoBehaviour
{
    public class SafeArray<T>
    {
        public List<T> safeAr;

        // Constructor
        public SafeArray(int _n)
        {
            safeAr = new List<T>(_n);

            for(int i = 0; i < _n; i++)
            {
                safeAr.Add(default(T));
            }

        }

        // Indexer
        public T this[int index]
        {
            get
            {
                if (index >= safeAr.Count)
                {
                    Debug.LogWarning("Array Out Of Bounds");
                    return default(T);
                }
                else
                {
                    return safeAr[index];
                }
            }

            set
            {
                if (index >= safeAr.Count)
                {
                    Debug.LogWarning("Array Out Of Bounds");
                }
                else
                {
                    safeAr[index] = value;
                }
            }
        }
    }

    // Make Instance
    public SafeArray<int> SafeC;

    private void Start()
    {
        SafeC = new SafeArray<int>(30);
    }
}