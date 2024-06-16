using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHitable
{
    public Bullet bulletPrefab;
    public Transform shotPoint;

    public float damage = 10f;

    public float maxHP = 100f;
    public float currentHP = 100f;

    public void Hit(float damage)
    {
        currentHP -= damage;
        print($"Player take damage : {damage}, current hp : {currentHP}");
    }

    void Update()
    {
        // Input Manager를 활용한 기능.
        // 기존: Input.GetMouseButtonDown(0)
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    public void Shot()
    {
        //Debug.Log($"{gameObject.name} press button");

        // 투사체 같은 건 오브젝트 풀링으로 할 것.
        // 스크립트를 Instantiate로 생성할 수 있음
        Bullet bullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10f, ForceMode.Impulse);
        // 정확하게 알고 싶다면  Unity Documentation에 검색해 보자.

        // 총알에 있는 damage 변수에 자신이 가지고 있는 damage 내용 옮겨줌.
        bullet.damage = damage;

        // bullet에게 맞아야 할 대상의 Layer를 지정
        // Layer를 사용할 때는 시프트 연산자를 사용해야 됨(이유는 나중에~)
        bullet.targetLayer = (1 << LayerMask.NameToLayer("Box")) + (1 << LayerMask.NameToLayer("Monster"));


        Destroy(bullet, 3f);
    }
}


/*

Ctrl + Shif + F : 선택한 오브젝트를 내가 보는 시점으로 옮기기
 
 */