using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CUIEasyToggleTest : MonoBehaviour
{
    public Color changeColor;
    public Image targetImage;

    // �� �Լ��� toggle�� on Value Change �̺�Ʈ�� ȣ�� �� �̴ϴ�.
    public void onToggleValueChange(bool isOn)
    {
        if(isOn)
        {
            print($"{name} toggle is on");
            targetImage.color = changeColor;

        }
        else
        {
            print($"{name} toggle is off");
        }
    }
}
