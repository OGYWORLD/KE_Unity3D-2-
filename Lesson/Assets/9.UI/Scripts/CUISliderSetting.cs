using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUISliderSetting : MonoBehaviour
{
    // 슬라이더 이벤트에서 호출
    public void OnSliderValueChange(float value)
    {
        transform.localScale = Vector3.one * value;
    }
}
