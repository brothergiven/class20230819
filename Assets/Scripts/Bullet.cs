using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*
    * 1. 총알 속도
    * 2. 총알의 이동에 필요한 리지드바디 컴포넌트
    * 3. 플레이어를 인식하는 코드
    *
    */
    public float speed; // 총알 이동 속력
    public float damage = 30f; // 총알의 데미지
    public Rigidbody bulletRigidbody; // 총알에 사용할 리지드바디 컴포넌트

    // 게임 시작과 동시에 1회 호출
    void Start()
    {
        speed = 100f;
        // 리지드바디의 속도 = 총알의 앞쪽 방향 * 속력
        bulletRigidbody.velocity = transform.forward * speed;
        // 물리처리를 위한 리지드바디 컴포넌트에서
        // 불렛의 리지드바디를 선언해주면 드래그앤드롭으로 접근 가능
        // 속도 초기화
        // 움직일 수 있는 방법은 포지션의 동적 변경, 리지드바디 속도, 힘 주기 등
        

        // 3초 뒤에 총알은 스스로 자신을 삭제함
        Destroy(gameObject, 3f); // hierachy 창의 bullet 오브젝트 자신을 삭제함
        // 3f가 없으면 즉시파괴
        // gameObject는 스크립트가 작성된 자기자신. Cpp에서 this와 같은 뜻

    }

    private void OnTriggerEnter(Collider other) // 충돌이 발생하면 매개변수 other로 들어옴
    {
        if (other.GetComponent<Enemy>() == null) return;
        other.GetComponent<Enemy>().TakeDamage(damage);
    }


}
