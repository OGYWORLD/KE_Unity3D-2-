using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInven : MonoBehaviour
{
    public GameObject InvenCanvas;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            InvenManager.instance.ShowItems();
            InvenCanvas.SetActive(!InvenCanvas.activeSelf);
        }
    }
}
