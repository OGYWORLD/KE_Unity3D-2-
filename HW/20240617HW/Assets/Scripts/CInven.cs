using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CInven : MonoBehaviour
{
    public GameObject InvenCanvas;
    public Transform PannelParent;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            InvenManager.instance.ShowItems();
            InvenCanvas.SetActive(!InvenCanvas.activeSelf);
        }
    }
}
