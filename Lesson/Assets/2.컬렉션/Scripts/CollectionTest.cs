using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTest : MonoBehaviour
{
    #region �迭

    // ������ �迭�� �����Ѵ�.
    // �⺻������ �迭�� ���� Ÿ��(���۷��� Ÿ��)�̱� ������ �ʱ�ȭ �Ҵ��� ���� ������ NULL ����
    private int[] intArray = new int[5];

    // ��Ÿ��(���ͷ� Ÿ��)�̱� ������
    // �ʱⰪ�� �������� �ʾƵ� �⺻���� �Ҵ�Ǿ� ������ �߻����� �ʴ´�.
    private int someInt;

    public int[] publicInArray = new int[10];

    #endregion

    #region ����Ʈ

    private List<int> intList = new List<int>();

    public List<int> publicIntList;

    public List<GameObject> gameObjArray;

    private ArrayList arrayList = new ArrayList();

    #endregion

    #region ��ųʸ�

    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject capsule;

    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

    public Dictionary<string, GameObject> publicDic = new Dictionary<string, GameObject>();
    #endregion

    #region ����/ť

    private Stack<int> intStack = new Stack<int>();

    private Queue<int> intQueue = new Queue<int>();

    #endregion

    private void Start()
    {
        /*
        Array.Fill<int>(intArray, 1);

        foreach (int someInt in intList)
        {
            print(someInt);
        }
        */

        /*
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.Add(4);
        intList.Add(5);
        
        foreach(GameObject obj in gameObjArray)
        {
            print(obj.name);
        }
        */

        /*
        dictionary.Add("cube", cube);
        dictionary.Add("sphere", sphere);
        dictionary.Add("cylinder", cylinder);
        dictionary.Add("capsule", capsule);

        dictionary["capsule"].GetComponent<Renderer>().material.color = Color.red;
        */


        intStack.Push(5);
        intStack.Push(4);
        intStack.Push(3);
        intStack.Push(2);
        intStack.Push(1);

        print(intStack.Pop()); // 1
        print(intStack.Pop()); // 2
        print(intStack.Pop()); // 3

        intStack.Push(6); // 5 4 6 7
        intStack.Push(7);

        print(intStack.Pop()); // 7
        print(intStack.Pop()); // 6
        print(intStack.Pop()); // 4
        print(intStack.Pop()); // 5

        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);
        intQueue.Enqueue(7);
        intQueue.Enqueue(6);

        print(intQueue.Dequeue()); // 1
        print(intQueue.Dequeue()); // 2
        print(intQueue.Dequeue()); // 3

        // 7 6 4 5
        intQueue.Enqueue(4);
        intQueue.Enqueue(5);

        print(intQueue.Dequeue()); // 7 
        print(intQueue.Dequeue()); // 6
        print(intQueue.Dequeue()); // 4
        print(intQueue.Dequeue()); // 5
    }
}
