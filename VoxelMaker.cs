using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    // 복셀 공장
    public GameObject voxelFactory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 사용자가 마우스를 클릭한 지점에 복셀을 1개 만들고 싶음

        // 1. 사용자가 마우스를 클릭했다면
        if(Input.GetButtonDown("Fire1"))
        {
            // 2. 마우스의 위치가 바닥 위에 위치해 있다면
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 3. 복셀 공장에서 복셀을 만들어야 함
                GameObject voxel = Instantiate(voxelFactory);
                // 4. 복셀을 배치하고 싶음
                voxel.transform.position = hitInfo.point;
            }
        }
    }
}
