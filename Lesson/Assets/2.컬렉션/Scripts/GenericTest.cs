using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGeneric<SomeType> where SomeType : class
{
    private SomeType someVal;

    public MyGeneric(SomeType someVal)
    {
        this.someVal = someVal;
    }

    public SomeType GetSome() { return someVal; }
}

public class GenericTest : MonoBehaviour
{
    public GameObject sphere1;
    public GameObject sphere2;

    private void Start()
    {
        // Get Renderer
        Renderer sphere1Renderer = sphere1.GetComponent<Renderer>();
        Renderer sphere2Renderer = sphere2.GetComponent<Renderer>();

        // Change Color
        sphere1Renderer.material.color = Color.red;
        sphere2Renderer.material.color = Color.blue;

        // 새 Sphere 생성
        GameObject newSphere = Instantiate(sphere1);
        newSphere.name = "newShpere";

        // 새 Sphere의 위치를 Sphere1과 Sphere2 사이에 두고 싶음
        // 새 Sphere의 색을 Sphere1과 Sphere2의 rgb의 딱 중간값으로 설정하고 싶음

        //newSphere.transform.position = GetMiddle<Vector3>(sphere1.transform.position, sphere2.transform.position);

        //newSphere.GetComponent<Renderer>().material.color =
            //GetMiddle<Color>(sphere1Renderer.material.color,
            //sphere2Renderer.material.color);

        //MyGeneric<int> myIntGeneric = new MyGeneric<int>(1);
        //print(myIntGeneric.GetSome()); // 1

        MyGeneric<string> myStringGeneric = new MyGeneric<string>("a");
        print(myStringGeneric.GetSome()); // a

        MyGeneric<GameObject> myGameObjectGeneric = new MyGeneric<GameObject>(new GameObject());
        myGameObjectGeneric.GetSome().name = "myGameObjectGeneric";
    
    }

    /*
    // 위치의 중간값을 구하는 함수
    private Vector3 GetMiddle(Vector3 a, Vector3 b)
    {
        Vector3 @return = new Vector3((a.x + b.x) / 2, (a.y + b.y) / 2, (a.z + b.z) / 2);
        
        return @return;
    }

    // 색의 중간값을 구하는 함수
    private Color GetMiddle(Color a, Color b)
    {
        Color @return = new Color((a.r + b.r)/2, (a.g + b.g) / 2, (a.b + b.b) / 2);

        return @return;
    }
    */

    /*
    private T GetMiddle<T>(T a, T b)
    {
        dynamic da = a;
        dynamic db = b;
        dynamic c = (da + db) / 2;

        return (T)c;
    }
*/
}
