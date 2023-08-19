using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /*
     * 1. �Ѿ� ���
     * 2. ������
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
        float xInput = Input.GetAxis("Horizontal"); // ������ �Է� �ޱ� A, D, <- , -> . -1 ~ 1���� �� �Է��� ������ ���� 0
        
        Vector3 dir = new Vector3(xInput, 0f, 0f).normalized; // xInput�� �޾Ƽ� 3���� ���Ͱ����� �ٲ��� normalized�� ���Ͱ��� 1�� �ٿ��� �ӷ°��� ���� �� �ֵ��� ��

        characterController.Move(dir * speed * Time.deltaTime); // ��ǻ�� ���ɸ��� �������� �ٸ��� ������ ��ǻ�� ���ɸ��� �޶��� �� ���� ���� �ð����� ���� �Ÿ��� �����̰� �ϱ� ���� Time.deltaTime

    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺�� �� �� Ŭ�� �Ǿ��� �� (����)
        {
            GameObject Bullet = Instantiate(BulletPrefab, Camera.main.transform.position, Camera.main.transform.rotation); // BulletPrefab�� ī�޶��� ���߾ӿ� ����
            Bullet.transform.LookAt(transform.forward);
        }

        if(Input.GetMouseButtonDown(1)) // ������ ���콺 Ŭ��
        {
            if (!isZoomIn)
            { // Camera.main�� MainCamera�� ����
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

    private void LateUpdate() // ī�޶� ������ LateUpdate���� ���� ��
    {
        Camera.main.transform.position = CameraPosition.transform.position;

    }
}
