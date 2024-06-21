using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CUIToggleTest : MonoBehaviour
{
    public Toggle[] toggles;

    private void Awake()
    {
        toggles = GetComponentsInChildren<Toggle>();
    }

    private void Start()
    {
        // toggles의 동작을 동적으로 할당하기 위해
        // toggles.Addlistener 호출

        for(int i = 0; i < toggles.Length; i++)
        {
            int index = i; // i 쓰면 i 주소가 들어가서 다 i의 최종값이 4가 들어가기 때문에 주소를 옮겨서 할당
            // # 인수로 넘기면 값이 복사되는 거 아냐?

            toggles[i].onValueChanged.AddListener(
                delegate(bool isOn)
                {
                    if(isOn)
                    {
                        OnToggleValueChange(index);
                    }
                }     
            );
        }
    }

    public void OnToggleValueChange(int index)
    {
        print($"Toggle {index} is On");
    }
}
