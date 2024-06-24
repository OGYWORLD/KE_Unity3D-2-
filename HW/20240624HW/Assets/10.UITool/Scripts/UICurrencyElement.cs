using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICurrencyElement : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public Slider progressBar;
    public TextMeshProUGUI progressText;

    private CurrencyData data;

    public void SetData(CurrencyData data)
    {
        this.data = data;
        // currency element�� �����ǰ� ���� ȣ�� �� �ʱ�ȭ �Լ�

        iconImage.sprite = data.iconSprite;
        nameText.text = data.currencyName;
        progressBar.minValue = 0;
        progressBar.maxValue = data.maxCount;

        int currentCount = DataManager.instance.userData[data.currencyType];

        // ����� �ؽ�Ʈ ����
        progressText.text = $"{currentCount} / {data.maxCount.ToString()}";

        // ����� ���簪 �Ҵ�
        progressBar.value = DataManager.instance.userData[data.currencyType];

        // ��ȭ ���� ����� �� ȣ��ǵ��� delegate stack�� �߰�
        DataManager.instance.onCurrencyAmountChange += OnCurrencyAmountChange;
    }


    public void OnCurrencyAmountChange(CurrencyType type, int count)
    {
        if(type == data.currencyType)
        {
            progressBar.value = count;

            progressText.text = $"{count} / {data.maxCount.ToString()}";
        }
    }
}
