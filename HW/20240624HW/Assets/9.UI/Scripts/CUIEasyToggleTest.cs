using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CUIEasyToggleTest : MonoBehaviour
{
    public Color changeColor;
    public Image targetImage;

    // 이 함수는 toggle이 on Value Change 이벤트로 호출 할 겁니다.
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
