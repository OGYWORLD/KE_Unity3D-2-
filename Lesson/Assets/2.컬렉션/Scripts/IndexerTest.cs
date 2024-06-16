using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyIndexer
{
    //private int[] a = new int[10];
    private int[] a = new int[10];

    // Constructor
    public MyIndexer()
    {
        for(int i = 0; i < a.Length; i++)
        {
            a[i] = i;
        }
    }

    // Indexer
    public int this[int i]
    {
        get
        {
            return a[i];
        }

        set
        {
            a[i] = value;
        }
    }

    private string temp = string.Empty;

    public string this[string a]
    {
        get
        {
            if(a == "a")
            {
                return "apple";
            }
            else if(a == "b")
            {
                return "boat";
            }
            else
            {
                return temp;
            }
        }

        set
        {
            if(a != "a" || a != "b")
            {
                temp = value;
            }
        }
    }

}

public class IndexerTest : MonoBehaviour
{
    private void Start()
    {
        MyIndexer myIndexer = new MyIndexer();

        print(myIndexer[0]); // 1

        print(myIndexer["a"]); // apple
        myIndexer["abc"] = "abc";
        print(myIndexer["c"]); // abc
    }
}
