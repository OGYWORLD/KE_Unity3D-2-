using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ObjInfo
{
    public Vector3 m_pos { get; set; }
    public Color m_color { get; set; }

    public ObjInfo(Vector3 _pos, Color _color)
    {
        m_pos = _pos;
        m_color = _color;
    }
}

public class CMakeObj : MonoBehaviour
{
    // Target Object
    public GameObject obj = null;

    // Make ObjInfo List
    List<ObjInfo> objInfoList = new List<ObjInfo>();

    // total object num
    const int TOTAL_OBJ_NUM = 5;

    private void Start()
    {
        // Set Object Position and Color
        SetRandomPosColor();

        // Start Coroutine
        StartCoroutine(ChangeObj());
    }

    void SetRandomPosColor()
    {
        for (int i = 0; i < TOTAL_OBJ_NUM; i++)
        {
            float randomX = Random.Range(-10f, 11f);
            float randomZ = Random.Range(-10f, 11f);

            float randomR = Random.Range(0f, 255f);
            float randomG = Random.Range(0f, 255f);
            float randomB = Random.Range(0f, 255f);

            objInfoList.Add(new ObjInfo(new Vector3(randomX, 2f, randomZ), new Color(randomR / 255f, randomG / 255f, randomB / 255f)));
        }
    }

    IEnumerator ChangeObj()
    {
        int index = 0;
        while(index < TOTAL_OBJ_NUM)
        {
            obj.transform.position = objInfoList[index].m_pos;
            obj.GetComponent<Renderer>().material.color = objInfoList[index].m_color;

            yield return new WaitForSeconds(1f);

            index++;
        }
        yield break;
    }
}
