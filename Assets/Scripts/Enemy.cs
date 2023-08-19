using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float hp;
    public float speed;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        hp = 100f;
        speed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.forward * speed; // spawner�� forward

    }
    public void TakeDamage(float damage) // �������� �޴� �Լ�
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
            return; // return�� ���� ����ó��
        }

        hp -= damage;
    }
}
