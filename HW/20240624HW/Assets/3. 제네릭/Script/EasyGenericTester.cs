using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyGenericTester : MonoBehaviour
{
    public CubeParent cubeFrom;
    public CubeParent cubeTo;

    private void Awake()
    {
        // cubeFrom�� colors, xPositions, scales, �迭�� ���� �����ϰ� ����
        // �� ���縦 �ϰ� ���� !
        cubeTo.colors = ArrayCopy(cubeFrom.colors);
        cubeTo.xPositions = ArrayCopy(cubeFrom.xPositions);
        cubeTo.scales = ArrayCopy(cubeFrom.scales);

        // �̷��� Ÿ���� ���ִ� �� ������ �ֽŹ����� �����ص� �ȴ���
        //cubeTo.colors = ArrayCopy<Color>(cubeFrom.colors);
    }

    // �̰� ���縦 �� ���̴�.
    // �Ϳ� ���׸��� ���� �����մϴ�~
    private T[] ArrayCopy<T>(T[] from)
    {
        T[] to = new T[from.Length];

        for(int i = 0; i < from.Length; i++)
        {
            to[i] = from[i];
        }

        return to;
    }
}

public class GenericExample : MonoBehaviour
{
    public List<int> intList = new List<int>();

    private void Start()
    {
        new GameObject().AddComponent<SpriteRenderer>();

    }
}

public class Parent { }
public class Child : Parent { }

// Ŭ�������� ����ϴ� ���׸� �ڷ����� ��������� ����� �� �ִ�.
class StructT<T> where T : struct { }
class ClassT<T> where T : class { }
class NewT<T> where T : new() { }
class Parent<T> where T : Parent { }
class InterfaceT<T> where T : IComparer { }