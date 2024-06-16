using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 클래스 상속
// 2. 인터페이스
// 3. 추상 클래스 사용 (컴포넌트로 생성 불가)
// 4. 프리팹 Variant
// 5. YAML과 유니티
// 6. Scene 병합을 위해 현업에서 사용하는 방법
// 7. Tag 대신 Layer로 오브젝트 구별하기 + 쉬프트 연산자 사용
// 8. 특정 Layer와 Physic 연산을 안 하게 하는 법(Project setting) -> 아예 충돌 연산을 안 하기 때문에 충돌하고 태그나 레이어를 확인하는 것 보다 성능이 좋음


// +) 추가적인 거
// 1. 코루틴의 정의와 반환
// 2. ForceMode.Impulse 찾아보기
// 3. use gravity 체크 유무에 따른 변화 테스트 좀
// 4. 스크립트를 Instantiate로 생성할 수 있음
// 5. public void destroy(MonoBehaviour destroyer);
// 6. TryGetComponent
// 7. other.SendMessage
// 8. Debug.Log와 print의 차이점
// 9. Ray ray = new Ray(Vector3.zero, Vector3.up);

// =========================================================================

// 추상 클래스는 컴포넌트로 붙일 수 없다.

// Orc랑 Slime에는 해당 스크립트를 붙여도 됨
// Orc Warrior는 프리팹 Variant -> 원본 프리팹에서 다른 부분만 용량을 사용해서 데이터 양을 줄임

// (YAML로 만들어진 거 더 있나 확인)
// 유니티 Scene, Prefab, GameObject은 YAML로 작성되므로 메모장으로 열 수 있음 -> YAML은 깃에서 merge가 안 되므로 Scene이나 프리팹은 merge가 안 됨
// 따라서 유니티에서 merge tool을 제공함 (좀 어려움)

// 그래서 보통 쓰는 방법
// 빈 오브젝트를 프리팹으로 만들어서 그 안에서 작업하는 것
// 해당 Scene은 수정되거나 무언가 추가되지 않도록 조심한다.

// Layer는 어디다가 쓰냐
// 1. 물리
// 2. 카메라 렌더링
// 이번 수업에서는 Player 밑에 bullet 스크립트의 targetLayer를 Player가 지정해줘서 걔만 쏠 수 있도록 했음
public class Moster : MonoBehaviour, IHitable
{
    public string monsterName;
    public float maxHP;
    public float currentHP;

    public float damage;

    public GameObject bulletPrefab; // Bullet 프리팹
    public Transform shotPoint; // 총구(bullet을 생성할 위치를 참조하기 위한 gameobject의 Transform)

    public float shotInterval = 1.1f; // 총 쏘는 속도

    private void Start()
    {
        StartCoroutine(ShotCoroutine());
    }    

    // Box도 Hit 해서 함수 호출해주고 싶은데 Moster 클래스를 상속받기는 좀 몬가몬가임 -> 인터페이스 사용
    public virtual void Hit(float damage)
    {
        currentHP -= damage;
        Debug.Log($"{name} Take Damage : {damage}, current HP : {currentHP} ");
    }

    // IEnumerator는 유니티에서 거의 코루틴으로 사용함
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
            //yield return null; // 이거 뭔지 다시한번 찾아보기
            // 그냥 코루틴을 다시 공부하셈
        }
    }

    public void Shot()
    {   // bullet 생성
        // 투사체 같은 건 오브젝트 풀링으로 할 것.
        GameObject bulletObject = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

        // rigidbody 참조 및 Addforce를 통해 앞으로 날아가도록 함
        // ForceMode.Impulse 찾아보기
        // use gravity 체크 유무에 따른 변화 테스트 좀
        bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * 10f, ForceMode.Impulse);
        // 정확하게 알고 싶다면  Unity Documentation에 검색해 보자.

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.damage = damage;
        // Monster의 bullet도 layer 설정
        bullet.targetLayer = (1 << LayerMask.NameToLayer("Box")) + (1 << LayerMask.NameToLayer("Player"));

        // Bullet 참조 및 데미지 할당
        // 총알에 있는 damage 변수에 자신이 가지고 있는 damage 내용 옮겨줌.
        //bulletObject.GetComponent<Bullet>().damage = damage;


        // 3초 후 소멸
        Destroy(bulletObject, 3f);
    }
}

/* Layer를 왜 shift로 표현하는가*/
// Layer는 총 32개
// LayerMask의 Value는 Layer 순서가 된다 ex) Nothing은 0, Default는 1 ..
// Layer를 여러개 적용하면 Layer의 2진수를 OR한 값이 LayerMask의 value가 됨