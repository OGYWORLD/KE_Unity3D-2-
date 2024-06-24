using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // 추가!

public class UnityEventTest : MonoBehaviour
{
    private float maxHP = 100f;
    private float currentHP = 100f;
    private float hpCache = 100f;

    // 유니티 이벤트(unity event)
    // 유니티 Inspector에서 delegate와 같이 특정 함수를 등록하여 호출 할 수 있도록 만들어진 클래스
    public UnityEvent someMethod;

    public UnityEvent<float> onHPChange;
    public UnityEvent<string> onHPChangeString;

    public void SomeEvent()
    {
        print("Some Event Called.");
    }

    private void Start()
    {
        someMethod?.Invoke();

        onHPChange.AddListener(PrintCurrentHP);
    }

    public void PrintCurrentHP(float value)
    {
        print($"current HP Ammount {value}");
    }

    public void OnValueChange(float value)
    {
        print(value);
    }

    // 슬라이드 UI
    public void OnPositionChange(Vector2 value)
    {
        transform.position = value;
    }

    public void OnDamageButtonClick()
    {
        currentHP -= 10f;
    }



    private void Update()
    {
        if(hpCache != currentHP)
        {
            onHPChange?.Invoke(currentHP/maxHP);
            onHPChangeString?.Invoke((currentHP/maxHP).ToString("p1"));
            hpCache = currentHP;
        }
    }
}
