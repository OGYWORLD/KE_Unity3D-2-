using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COpenTab : MonoBehaviour
{
    public GameObject evidenceTab;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            evidenceTab.SetActive(!evidenceTab.activeSelf);
        }
    }
}
