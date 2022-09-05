using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;                        // VideoPlayer 기능을 사용하기 위한 네임스페이스

// Video Player 컴포넌트 제어 
// 바라보는 방향이 아래를 향하면 메뉴 활성화
public class MenuSwitch : MonoBehaviour
{
    public GameObject videoFrameMenu;
    public float dot;
    public VideoPlayer vp;

    // Update is called once per frame
    void Update()
    {
        // 내적을 통한 방향 비교
        dot = Vector3.Dot(transform.forward, Vector3.up);
        if (dot < -0.5)
        {
            videoFrameMenu.SetActive(true);          // 메뉴 활성화
        }
        else
        {
            videoFrameMenu.SetActive(false);         // 메뉴 비활성화
        }
    }

    private void OnEnable()
    {
        if (vp != null)
        {
            vp.Stop();
        }
    }
}
