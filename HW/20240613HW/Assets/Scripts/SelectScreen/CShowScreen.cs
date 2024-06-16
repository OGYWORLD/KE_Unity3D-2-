using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShowScreen : MonoBehaviour
{
    public GameObject[] canvas = new GameObject[3];

    public virtual void SetCanvas()
    {
        for(int i = 0; i < canvas.Length; i++)
        {
            canvas[i].SetActive(false);
        }
    }
}
