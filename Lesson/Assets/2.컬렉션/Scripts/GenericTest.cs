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

        // �� Sphere ����
        GameObject newSphere = Instantiate(sphere1);
        newSphere.name = "newShpere";

        // �� Sphere�� ��ġ�� Sphere1�� Sphere2 ���̿� �ΰ� ����
        // �� Sphere�� ���� Sphere1�� Sphere2�� rgb�� �� �߰������� �����ϰ� ����

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
    // ��ġ�� �߰����� ���ϴ� �Լ�
    private Vector3 GetMiddle(Vector3 a, Vector3 b)
    {
        Vector3 @return = new Vector3((a.x + b.x) / 2, (a.y + b.y) / 2, (a.z + b.z) / 2);
        
        return @return;
    }

    // ���� �߰����� ���ϴ� �Լ�
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
