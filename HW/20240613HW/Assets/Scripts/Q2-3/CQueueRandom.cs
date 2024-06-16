using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ObjInfo02
{
    public Vector3 m_pos { get; set; }
    public Color m_color { get; set; }

    public ObjInfo02(Vector3 _pos, Color _color)
    {
        m_pos = _pos;
        m_color = _color;
    }
}

public class CQueueRandom : MonoBehaviour, IInputInfo
{
    public GameObject obj = null;

    Queue<ObjInfo02> colorQueue = new Queue<ObjInfo02>();

    protected Color color;

    private void Update()
    {
        StartCoroutine(ShowObj());
    }

    public virtual void ColorIntoQueue()
    {
        // Set Random Position
        Vector3 pos = new Vector3(Random.Range(-10f, 11f), 2f, Random.Range(-10f, 11f));

        colorQueue.Enqueue(new ObjInfo02(pos, color));
    }

    // Show Obj
    IEnumerator ShowObj()
    {
        if(colorQueue.Count != 0)
        {
            ObjInfo02 temp = colorQueue.Dequeue();
            obj.transform.position = temp.m_pos;
            obj.GetComponent<Renderer>().material.color = temp.m_color;

            yield return new WaitForSeconds(1f);
        }

        yield break;
    }
}
