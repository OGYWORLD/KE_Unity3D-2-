using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public LayerMask targetLayer; // Layer를 받아옴

    private void OnTriggerEnter(Collider other)
    {
        // 트리거 안에 들어온 다른 객체의 Layer가 targetLayer와 다른 레이어면 무시
        if((targetLayer | (1 << other.gameObject.layer)) != targetLayer)
        {
            return;
        }

        // TryGetComponent는 Bool형.
        // 트리거로 충돌한 오브젝트의 스크립트를 가져와서 함수를 호출
        // 인터페이스를 통한 느슨한 커플링 (업캐스팅으로도 가능하지만 box도 끼고 싶어서 인터페이스로 구현)
        if(other.TryGetComponent<IHitable>(out IHitable moster)){
            moster.Hit(damage);
        }

        // 굳이 다형성을 이용하지 않아도 SendMessage를 통해 구현할 수 있다.
        // 정석은 위에가 맞는데 혼자 프로토타입 빠르게 만들어야할 때는 이렇게 쓴다.
        //other.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);

        Destroy(gameObject);
    }
}
