using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    // 1. 복셀이 날아갈 속도 속성
    public float speed = 5;

    // Start is called before the first frame update
    // void Start()
    void OnEnable()
    {
        currentTime = 0;
        // 2. 랜덤한 방향을 찾음
        Vector3 direction = Random.insideUnitSphere;
        // 3. 랜덤한 방향으로 날아가는 속도를 줌
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }

    // 복셀을 제거할 시간
    public float destoryTime = 3.0f;
    // 경과 시간
    float currentTime;

    // Update is called once per frame
    void Update()
    {
        // 1. 시간이 흘러야 함
        currentTime += Time.deltaTime;
        // 2. 제거 시간이 됐으니까
        // 만약 경과 시간이 제거 시간을 초과했다면
        if(currentTime > destoryTime)
        {
            // 3. 복셀을 제거하고 싶음
            // Destroy(gameObject);

            // 오브젝트 풀 사용_3. Voxel을 비활성화
            gameObject.SetActive(false);    
            // 오브젝트 풀 사용_4. 오브젝트 풀에 다시 넣어줌
            VoxelMaker.voxelPool.Add(gameObject);
        }
    }
}
