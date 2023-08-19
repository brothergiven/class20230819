using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*
    * 1. �Ѿ� �ӵ�
    * 2. �Ѿ��� �̵��� �ʿ��� ������ٵ� ������Ʈ
    * 3. �÷��̾ �ν��ϴ� �ڵ�
    *
    */
    public float speed; // �Ѿ� �̵� �ӷ�
    public float damage = 30f; // �Ѿ��� ������
    public Rigidbody bulletRigidbody; // �Ѿ˿� ����� ������ٵ� ������Ʈ

    // ���� ���۰� ���ÿ� 1ȸ ȣ��
    void Start()
    {
        speed = 100f;
        // ������ٵ��� �ӵ� = �Ѿ��� ���� ���� * �ӷ�
        bulletRigidbody.velocity = transform.forward * speed;
        // ����ó���� ���� ������ٵ� ������Ʈ����
        // �ҷ��� ������ٵ� �������ָ� �巡�׾ص������ ���� ����
        // �ӵ� �ʱ�ȭ
        // ������ �� �ִ� ����� �������� ���� ����, ������ٵ� �ӵ�, �� �ֱ� ��
        

        // 3�� �ڿ� �Ѿ��� ������ �ڽ��� ������
        Destroy(gameObject, 3f); // hierachy â�� bullet ������Ʈ �ڽ��� ������
        // 3f�� ������ ����ı�
        // gameObject�� ��ũ��Ʈ�� �ۼ��� �ڱ��ڽ�. Cpp���� this�� ���� ��

    }

    private void OnTriggerEnter(Collider other) // �浹�� �߻��ϸ� �Ű����� other�� ����
    {
        if (other.GetComponent<Enemy>() == null) return;
        other.GetComponent<Enemy>().TakeDamage(damage);
    }


}
