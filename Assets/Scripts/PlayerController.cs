using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /*
     * 1. 총알 쏘기
     * 2. 움직임
     */
    public CharacterController characterController;

    public GameObject BulletPrefab;

    public GameObject CameraPosition;

    public float speed = 8f;

    public bool isZoomIn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal"); // 가로축 입력 받기 A, D, <- , -> . -1 ~ 1까지 들어감 입력이 없으면 값은 0
        
        Vector3 dir = new Vector3(xInput, 0f, 0f).normalized; // xInput을 받아서 3차원 벡터값으로 바꿔줌 normalized는 벡터값을 1로 줄여서 속력값을 곱할 수 있도록 함

        characterController.Move(dir * speed * Time.deltaTime); // 컴퓨터 성능마다 프레임은 다르기 때문에 컴퓨터 성능마다 달라질 수 있음 같은 시간동안 같은 거리를 움직이게 하기 위한 Time.deltaTime

    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스가 한 번 클릭 되었을 때 (왼쪽)
        {
            GameObject Bullet = Instantiate(BulletPrefab, Camera.main.transform.position, Camera.main.transform.rotation); // BulletPrefab을 카메라의 정중앙에 생성
            Bullet.transform.LookAt(transform.forward);
        }

        if(Input.GetMouseButtonDown(1)) // 오른쪽 마우스 클릭
        {
            if (!isZoomIn)
            { // Camera.main은 MainCamera에 접근
                Camera.main.fieldOfView = 30f;
                isZoomIn = true;
            }
            else
            {
                Camera.main.fieldOfView = 60f;
                isZoomIn = false;
            }
        }
    }

    private void LateUpdate() // 카메라 조정은 LateUpdate에서 해줄 것
    {
        Camera.main.transform.position = CameraPosition.transform.position;

    }
}
