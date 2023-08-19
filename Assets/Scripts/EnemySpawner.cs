using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    /* 1. ������ ź���� ���� (prefab)
     * 2. ź���� �߻��� ��ǥ�� ��ġ (�÷��̾�)
     * 3. ź�� �߻縦 �����ϴ� �ð� ���� (�뷱��)
     */

    public GameObject enemyPrefab;     
    public float spawnRateMin = 0.5f;    // �ּ� ���� �ֱ�(��)
    public float spawnRateMax = 3f;      // �ִ� ���� �ֱ�(��)

    private float spawnRate;             // ���� �ֱ�
    private float timeAfterSpawn;        // �ֱ� ���� �������� ���� �ð�



    // Start is called before the first frame update
    void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;

        // ź�� ���� ������ spawnRateMin�� spawnRateMax ������ ���������� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

    }


    void Update()
    {
        // �� �����Ӹ��� timeAfterSpawn ���� �� �������� �ҷ��� ������ �ð��� �󸶳� ��������
        timeAfterSpawn += Time.deltaTime; // �ð��� �󸶳� ���������� ����ϴ�

        // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate)
        {
            // ������ �ð� ����
            timeAfterSpawn = 0f;

            // <�ٽ�> bulletPrefab ����ǰ�� transform ��ġ�� ȸ������ ����
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);


            // ������ �߻�� �Ѿ� ���� ������ �ٽ� �������� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
