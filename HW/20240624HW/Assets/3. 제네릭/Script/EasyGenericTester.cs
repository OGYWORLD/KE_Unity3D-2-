using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyGenericTester : MonoBehaviour
{
    public CubeParent cubeFrom;
    public CubeParent cubeTo;

    private void Awake()
    {
        // cubeFrom의 colors, xPositions, scales, 배열을 각각 복사하고 싶음
        // 값 복사를 하고 싶음 !
        cubeTo.colors = ArrayCopy(cubeFrom.colors);
        cubeTo.xPositions = ArrayCopy(cubeFrom.xPositions);
        cubeTo.scales = ArrayCopy(cubeFrom.scales);

        // 이렇게 타입을 써주는 게 맞지만 최신버전은 생략해도 된다함
        //cubeTo.colors = ArrayCopy<Color>(cubeFrom.colors);
    }

    // 이게 복사를 한 것이다.
    // 와우 제네릭을 쓰니 이지합니다~
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

// 클래스에서 사용하는 제네릭 자료형에 제약사향을 명시할 수 있다.
class StructT<T> where T : struct { }
class ClassT<T> where T : class { }
class NewT<T> where T : new() { }
class Parent<T> where T : Parent { }
class InterfaceT<T> where T : IComparer { }