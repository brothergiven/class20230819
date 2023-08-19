using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    /* 1. 생성할 탄알의 원본 (prefab)
     * 2. 탄알을 발사할 목표물 위치 (플레이어)
     * 3. 탄알 발사를 관리하는 시간 간격 (밸런스)
     */

    public GameObject enemyPrefab;     
    public float spawnRateMin = 0.5f;    // 최소 생성 주기(초)
    public float spawnRateMax = 3f;      // 최대 생성 주기(초)

    private float spawnRate;             // 생성 주기
    private float timeAfterSpawn;        // 최근 생성 시점에서 지난 시간



    // Start is called before the first frame update
    void Start()
    {
        // 최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;

        // 탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이의 랜덤값으로 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

    }


    void Update()
    {
        // 매 프레임마다 timeAfterSpawn 갱신 한 프레임을 불러올 때마다 시간이 얼마나 지났는지
        timeAfterSpawn += Time.deltaTime; // 시간이 얼마나 지났는지를 계산하는

        // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if (timeAfterSpawn >= spawnRate)
        {
            // 누적된 시간 리셋
            timeAfterSpawn = 0f;

            // <핵심> bulletPrefab 복제품을 transform 위치와 회전으로 생성
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);


            // 다음에 발사될 총알 생성 간격을 다시 랜덤으로 설정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
