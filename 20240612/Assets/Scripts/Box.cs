using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IHitable
{
    public float maxDamage = 10f;
    public LayerMask someLayer;

    private void Start()
    {
        print(someLayer.value);


        Ray ray = new Ray(Vector3.zero, Vector3.up);
        //Physics.Raycast(ray, Mathf.Infinity,  1 << LayerMask.NameToLayer("Monster"));
        Physics.Raycast(ray, Mathf.Infinity, someLayer); // 이렇게 하면 인스펙터에서 설정한 값으로 편하게 들어감
    }

    public void Hit(float damage)
    {
        if(damage >= maxDamage)
        {
            Destroy(gameObject);
        }

        print($"{name} hitted and damage : {damage}");
    }
}
