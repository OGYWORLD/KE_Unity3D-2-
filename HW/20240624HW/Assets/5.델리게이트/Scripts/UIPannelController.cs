using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPannelController : MonoBehaviour
{
    public Transform PannelParent;
    //public GameObject pannelPrefab;

    public void AddPannelButtonClick()
    {
        var child = new GameObject("Image");
        child.transform.SetParent(PannelParent);

        var childImage = child.AddComponent<Image>();

        childImage.color = Color.white;

        DayNightManager.instance.onDayComesUp += (isDay) =>
        {
            childImage.color = isDay ? Color.white : Color.black;
        };
    }
}
