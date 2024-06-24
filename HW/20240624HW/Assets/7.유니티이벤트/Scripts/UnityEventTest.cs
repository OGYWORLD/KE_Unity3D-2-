using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // �߰�!

public class UnityEventTest : MonoBehaviour
{
    private float maxHP = 100f;
    private float currentHP = 100f;
    private float hpCache = 100f;

    // ����Ƽ �̺�Ʈ(unity event)
    // ����Ƽ Inspector���� delegate�� ���� Ư�� �Լ��� ����Ͽ� ȣ�� �� �� �ֵ��� ������� Ŭ����
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

    // �����̵� UI
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
