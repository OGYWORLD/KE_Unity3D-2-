using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItemRotation : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.right * 5f);   
    }
}
