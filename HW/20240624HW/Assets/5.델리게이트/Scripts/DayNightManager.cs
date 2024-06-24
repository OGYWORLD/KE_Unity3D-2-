using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    // �̱���
    public static DayNightManager instance { get; private set; }

    public Transform lightTransform; // Directional Light

    private bool isDay = true; // ���̸� true, ���̸� false

    // observer pattern�� �κ������� ����
    // ����Ƽ������ obersver pattern�� ���� ��, delegate, eventHandler�� �ַ� Ȱ��
    public Action<bool> onDayComesUp;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }

        onDayComesUp = (isDay) =>
        lightTransform.rotation = Quaternion.Euler(isDay ? 30 : 190, 0, 0);
    }

    // �㳷 ��� ��ư�� ȣ��
    public void DayToggleButtonClick()
    {
        isDay = !isDay; // isDay ���

        onDayComesUp?.Invoke(isDay);
    }
}
