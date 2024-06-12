using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public LayerMask targetLayer; // Layer�� �޾ƿ�

    private void OnTriggerEnter(Collider other)
    {
        // Ʈ���� �ȿ� ���� �ٸ� ��ü�� Layer�� targetLayer�� �ٸ� ���̾�� ����
        if((targetLayer | (1 << other.gameObject.layer)) != targetLayer)
        {
            return;
        }

        // TryGetComponent�� Bool��.
        // Ʈ���ŷ� �浹�� ������Ʈ�� ��ũ��Ʈ�� �����ͼ� �Լ��� ȣ��
        // �������̽��� ���� ������ Ŀ�ø� (��ĳ�������ε� ���������� box�� ���� �; �������̽��� ����)
        if(other.TryGetComponent<IHitable>(out IHitable moster)){
            moster.Hit(damage);
        }

        // ���� �������� �̿����� �ʾƵ� SendMessage�� ���� ������ �� �ִ�.
        // ������ ������ �´µ� ȥ�� ������Ÿ�� ������ �������� ���� �̷��� ����.
        //other.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);

        Destroy(gameObject);
    }
}
