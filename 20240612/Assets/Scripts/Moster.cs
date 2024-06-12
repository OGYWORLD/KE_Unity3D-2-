using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. Ŭ���� ���
// 2. �������̽�
// 3. �߻� Ŭ���� ��� (������Ʈ�� ���� �Ұ�)
// 4. ������ Variant
// 5. YAML�� ����Ƽ
// 6. Scene ������ ���� �������� ����ϴ� ���
// 7. Tag ��� Layer�� ������Ʈ �����ϱ� + ����Ʈ ������ ���
// 8. Ư�� Layer�� Physic ������ �� �ϰ� �ϴ� ��(Project setting) -> �ƿ� �浹 ������ �� �ϱ� ������ �浹�ϰ� �±׳� ���̾ Ȯ���ϴ� �� ���� ������ ����


// +) �߰����� ��
// 1. �ڷ�ƾ�� ���ǿ� ��ȯ
// 2. ForceMode.Impulse ã�ƺ���
// 3. use gravity üũ ������ ���� ��ȭ �׽�Ʈ ��
// 4. ��ũ��Ʈ�� Instantiate�� ������ �� ����
// 5. public void destroy(MonoBehaviour destroyer);
// 6. TryGetComponent
// 7. other.SendMessage
// 8. Debug.Log�� print�� ������
// 9. Ray ray = new Ray(Vector3.zero, Vector3.up);

// =========================================================================

// �߻� Ŭ������ ������Ʈ�� ���� �� ����.

// Orc�� Slime���� �ش� ��ũ��Ʈ�� �ٿ��� ��
// Orc Warrior�� ������ Variant -> ���� �����տ��� �ٸ� �κи� �뷮�� ����ؼ� ������ ���� ����

// (YAML�� ������� �� �� �ֳ� Ȯ��)
// ����Ƽ Scene, Prefab, GameObject�� YAML�� �ۼ��ǹǷ� �޸������� �� �� ���� -> YAML�� �꿡�� merge�� �� �ǹǷ� Scene�̳� �������� merge�� �� ��
// ���� ����Ƽ���� merge tool�� ������ (�� �����)

// �׷��� ���� ���� ���
// �� ������Ʈ�� ���������� ���� �� �ȿ��� �۾��ϴ� ��
// �ش� Scene�� �����ǰų� ���� �߰����� �ʵ��� �����Ѵ�.

// Layer�� ���ٰ� ����
// 1. ����
// 2. ī�޶� ������
// �̹� ���������� Player �ؿ� bullet ��ũ��Ʈ�� targetLayer�� Player�� �������༭ �¸� �� �� �ֵ��� ����
public class Moster : MonoBehaviour, IHitable
{
    public string monsterName;
    public float maxHP;
    public float currentHP;

    public float damage;

    public GameObject bulletPrefab; // Bullet ������
    public Transform shotPoint; // �ѱ�(bullet�� ������ ��ġ�� �����ϱ� ���� gameobject�� Transform)

    public float shotInterval = 1.1f; // �� ��� �ӵ�

    private void Start()
    {
        StartCoroutine(ShotCoroutine());
    }    

    // Box�� Hit �ؼ� �Լ� ȣ�����ְ� ������ Moster Ŭ������ ��ӹޱ�� �� �󰡸��� -> �������̽� ���
    public virtual void Hit(float damage)
    {
        currentHP -= damage;
        Debug.Log($"{name} Take Damage : {damage}, current HP : {currentHP} ");
    }

    // IEnumerator�� ����Ƽ���� ���� �ڷ�ƾ���� �����
    IEnumerator ShotCoroutine()
    {
        if(bulletPrefab == null || shotPoint == null)
        {
            yield break;
        }

        while(true)
        {
            Shot();

            yield return new WaitForSeconds(shotInterval);
            //yield return null; // �̰� ���� �ٽ��ѹ� ã�ƺ���
            // �׳� �ڷ�ƾ�� �ٽ� �����ϼ�
        }
    }

    public void Shot()
    {   // bullet ����
        // ����ü ���� �� ������Ʈ Ǯ������ �� ��.
        GameObject bulletObject = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

        // rigidbody ���� �� Addforce�� ���� ������ ���ư����� ��
        // ForceMode.Impulse ã�ƺ���
        // use gravity üũ ������ ���� ��ȭ �׽�Ʈ ��
        bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * 10f, ForceMode.Impulse);
        // ��Ȯ�ϰ� �˰� �ʹٸ�  Unity Documentation�� �˻��� ����.

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.damage = damage;
        // Monster�� bullet�� layer ����
        bullet.targetLayer = (1 << LayerMask.NameToLayer("Box")) + (1 << LayerMask.NameToLayer("Player"));

        // Bullet ���� �� ������ �Ҵ�
        // �Ѿ˿� �ִ� damage ������ �ڽ��� ������ �ִ� damage ���� �Ű���.
        //bulletObject.GetComponent<Bullet>().damage = damage;


        // 3�� �� �Ҹ�
        Destroy(bulletObject, 3f);
    }
}

/* Layer�� �� shift�� ǥ���ϴ°�*/
// Layer�� �� 32��
// LayerMask�� Value�� Layer ������ �ȴ� ex) Nothing�� 0, Default�� 1 ..
// Layer�� ������ �����ϸ� Layer�� 2������ OR�� ���� LayerMask�� value�� ��