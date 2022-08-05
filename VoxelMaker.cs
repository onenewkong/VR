using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    // 복셀 공장
    public GameObject voxelFactory;

    // 오브젝트 풀의 크기
    public int voxelPoolSize = 20;

    // 오브젝트 풀
    public static List<GameObject> voxelPool = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // 오브젝트 풀에 비활성화된 복셀을 담고 싶음
        for (int i =0; i < voxelPoolSize; i++)
        {
            // 1. 복셀 공장에서 복셀 생성
            GameObject voxel = Instantiate(voxelFactory);
            // 2. 복셀 비활성화
            voxel.SetActive(false);
            // 3. 복셀을 오브젝트 풀에 담고 싶음
            voxelPool.Add(voxel);
        }
    }

    // 생성 시간
    public float createTime = 0.1f;
    // 경과 시간
    float currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        // 사용자가 마우스를 클릭한 지점에 복셀을 1개 만들고 싶음

        // 1. 사용자가 마우스를 클릭했다면
        if(Input.GetButtonDown("Fire1"))
        {
            // 일정 시간마다 복셀을 만들고 싶음
            // 1) 경과 시간이 흐름
            currentTime += Time.deltaTime;
            // 2) 경과 시간이 생성 시간을 초과했다면
            if (currentTime > createTime)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo = new RaycastHit();

                // 3) Ray를 쏨
                // 2. 마우스의 위치가 바닥 위에 위치해 있다면
                if (Physics.Raycast(ray, out hitInfo))
                {
                    // 3. 복셀 공장에서 복셀을 만들어야 함
                    // GameObject voxel = Instantiate(voxelFactory);
                    // 4. 복셀을 배치하고 싶음
                    // voxel.transform.position = hitInfo.point;

                    // 복셀 오브젝트 풀 이용하기
                    // 1. 만약 오브젝트 풀에 복셀이 있다면
                    if (voxelPool.Count > 0)
                    {
                        // 복셀을 생성했을 때만 경과 시간을 초기회
                        currentTime = 0;

                        // 2. 오브젝트 풀에서 복셀을 하나 가져옴
                        GameObject voxel = voxelPool[0];
                        // 3. 복셀을 활성화함
                        voxel.SetActive(true);
                        // 4. 복셀을 배치하고 싶음
                        voxel.transform.position = hitInfo.point;
                        // 5. 오브젝트 풀에서 복셀을 제거
                        voxelPool.RemoveAt(0);
                    }
                }
            }
        }
    }
}
