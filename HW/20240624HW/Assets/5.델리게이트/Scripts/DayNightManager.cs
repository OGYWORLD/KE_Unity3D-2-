using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    // 싱글톤
    public static DayNightManager instance { get; private set; }

    public Transform lightTransform; // Directional Light

    private bool isDay = true; // 낮이면 true, 밤이면 false

    // observer pattern을 부분적으로 구현
    // 유니티에서는 obersver pattern을 구현 시, delegate, eventHandler를 주로 활용
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

    // 밤낮 토글 버튼이 호출
    public void DayToggleButtonClick()
    {
        isDay = !isDay; // isDay 토글

        onDayComesUp?.Invoke(isDay);
    }
}
