using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CInteraction : MonoBehaviour, IInteractable
{
    // Dialog
    public GameObject dialog = null;

    // Text
    public Text name = null;
    public Text talk = null;

    public virtual void ShowPreInteract()
    {

    }

    public virtual void ShowInteract()
    {

    }

    public virtual void Init()
    {

    }
}
