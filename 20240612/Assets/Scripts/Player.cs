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
        // Input Manager�� Ȱ���� ���.
        // ����: Input.GetMouseButtonDown(0)
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    public void Shot()
    {
        //Debug.Log($"{gameObject.name} press button");

        // ����ü ���� �� ������Ʈ Ǯ������ �� ��.
        // ��ũ��Ʈ�� Instantiate�� ������ �� ����
        Bullet bullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10f, ForceMode.Impulse);
        // ��Ȯ�ϰ� �˰� �ʹٸ�  Unity Documentation�� �˻��� ����.

        // �Ѿ˿� �ִ� damage ������ �ڽ��� ������ �ִ� damage ���� �Ű���.
        bullet.damage = damage;

        // bullet���� �¾ƾ� �� ����� Layer�� ����
        // Layer�� ����� ���� ����Ʈ �����ڸ� ����ؾ� ��(������ ���߿�~)
        bullet.targetLayer = (1 << LayerMask.NameToLayer("Box")) + (1 << LayerMask.NameToLayer("Monster"));


        Destroy(bullet, 3f);
    }
}


/*

Ctrl + Shif + F : ������ ������Ʈ�� ���� ���� �������� �ű��
 
 */