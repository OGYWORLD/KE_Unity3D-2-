using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUISliderSetting : MonoBehaviour
{
    // �����̴� �̺�Ʈ���� ȣ��
    public void OnSliderValueChange(float value)
    {
        transform.localScale = Vector3.one * value;
    }
}
