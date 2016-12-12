using UnityEngine;
using System.Collections;

public class CsGroundManager : MonoBehaviour
{

    //그라운드 생성 및 제거
    //왼쪽이 B 오른쪽이 A
    public GameObject A_Type;
    public GameObject B_Type;

    public GameObject[] Grounds;

    public float speed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        MoveGround();
    }
    //움직이기
    void MoveGround()
    {
        A_Type.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        B_Type.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        if (B_Type.transform.position.x <= -3)
        {
            DestroyGround();
        }

    }
    //생성
    void MakeGround()
    {
        A_Type = B_Type;
        int type = Random.Range(0, Grounds.Length);
        B_Type = Instantiate(Grounds[type], new Vector3(30, 0, 0), Quaternion.identity) as GameObject;
        B_Type.transform.parent = transform; //GroundManager 의 자식으로 설정
    }
    void DestroyGround()
    {
        Destroy(A_Type);
        MakeGround();
    }
}