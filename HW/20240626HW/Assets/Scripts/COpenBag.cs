using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COpenBag : MonoBehaviour
{
    public GameObject bag;
    public GameObject skillTab;

    private void Update()
    {
        OpenBag();
        OpenSkillTab();
    }

    void OpenBag()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SetOpenTabBool();
            bag.SetActive(!bag.activeSelf);
        }
    }

    void OpenSkillTab()
    {
        if(Input.GetKeyDown(KeyCode.F2))
        {
            SetOpenTabBool();
            skillTab.SetActive(!skillTab.activeSelf);
        }
    }

    void SetOpenTabBool()
    {
        if(GameManager.instance.isOpenTab)
        {
            GameManager.instance.isOpenTab = false;
        }
        else
        {
            GameManager.instance.isOpenTab = true;
        }
    }
}
