using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ObjInfo03
{
    public Vector3 m_pos { get; set; }
    public Color m_color { get; set; }

    public ObjInfo03(Vector3 _pos, Color _color)
    {
        m_pos = _pos;
        m_color = _color;
    }
}

public class CStackRandom : MonoBehaviour
{
    public GameObject obj = null;

    Stack<ObjInfo03> colorStack = new Stack<ObjInfo03>();

    protected Color color;

    private void Update()
    {
        StartCoroutine(ShowObj());
    }

    public virtual void ColorIntoQueue()
    {
        // Set Random Position
        Vector3 pos = new Vector3(Random.Range(-10f, 11f), 2f, Random.Range(-10f, 11f));

        colorStack.Push(new ObjInfo03(pos, color));
    }

    // Show Obj
    IEnumerator ShowObj()
    {
        if (colorStack.Count != 0)
        {
            ObjInfo03 temp = colorStack.Pop();
            obj.transform.position = temp.m_pos;
            obj.GetComponent<Renderer>().material.color = temp.m_color;

            yield return new WaitForSeconds(1f);
        }

        yield break;
    }
}
