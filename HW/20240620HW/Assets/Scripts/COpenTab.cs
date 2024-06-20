using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COpenTab : MonoBehaviour
{
    public GameObject InfoTab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(GameManager.instance.isTab)
            {
                GameManager.instance.isTab = false;
            }
            else
            {
                GameManager.instance.isTab = true;
            }

            InfoTab.SetActive(!InfoTab.activeSelf);
        }
    }
}
