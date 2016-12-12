using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public float distance;
    GameObject player;
    /* 유니티에서 사용되는 게임 오브젝트 속성의 변수를 만들어 주었습니다. */

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        /* 시작함과 동시에 변수에 태그 이름 Player로 된 오브젝트를 넣어 줍니다. */
    }

  

    void LateUpdate()
    {
        /* 카메라의 자연스러운 워킹을 위해서 살짝 더딘 LateUpdate를 사용한다고 합니다. */

        transform.position = new Vector3(player.transform.position.x+distance, 4.7f, -800f);
        
        /* 핵심인 이동 명령, 플레이어의 X 좌표를 따라가고 Y, Z 좌표는 고정하여주었습니다. */
        /* Y 축과 Z 축의 값은 편집화면을 참고하여 나름대로 정하면 됩니다. */

    }
}
