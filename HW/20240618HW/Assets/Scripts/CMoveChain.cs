using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveChain : MonoBehaviour
{
    public GameObject chain01;
    public GameObject chain02;

    public void OnScrollChainMove(Vector2 value)
    {
        chain01.transform.localPosition = (Vector3)value * 70f;
        chain02.transform.localPosition = (Vector3)value * 70f;
    }
}
