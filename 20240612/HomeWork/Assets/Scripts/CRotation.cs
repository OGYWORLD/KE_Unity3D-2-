using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRotation : MonoBehaviour
{
    public float mouseSensitivity = 5000f;

    float xMouse = 0f;

    void Update()
    {
        SetCharaRotation();
    }

    void SetCharaRotation()
    {
        xMouse += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(0f, xMouse, 0f);

    }
}
