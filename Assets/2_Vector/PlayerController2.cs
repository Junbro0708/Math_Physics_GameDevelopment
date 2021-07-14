using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController2 : MonoBehaviour
{
    public GameObject bulletObject;
    public Transform bulletContainer;
    public GameObject guideLine;
    
    public float ditectionRange = 4f;


    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        MouseCheck();
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = mainCamera.ScreenToWorldPoint(mousePos);

            Vector3 playerPos = transform.position;
            
            Vector2 dirVec = mousePos - (Vector2)playerPos;
            dirVec = dirVec.normalized;

            GameObject tempObject = Instantiate(bulletObject, bulletContainer);
            tempObject.transform.right = dirVec;

            tempObject.transform.position = (Vector2)playerPos + dirVec * 0.5f; // 총알이 플레이어보다 약간 앞에서 발사
            
            transform.Translate(-dirVec); // 플레이어가 반대 방향으로 넉백
        }
    }

    void MouseCheck()
    {
        Vector2 mousePos = Input.mousePosition;
        mousePos = mainCamera.ScreenToWorldPoint(mousePos); // 화면이 아닌 게임 내의 좌표값을 받을 수 있음
        // 현재 마우스의 위치를 게임 내의 포지션 값으로 전환

        Vector3 playerPos = transform.position;
            
        Vector2 distanceVec = mousePos - (Vector2)playerPos;
        guideLine.SetActive(distanceVec.magnitude < ditectionRange ? true : false); // 가이드 라인을 일정 거리 안에 들어가면 활성화를 하자

        guideLine.transform.right = distanceVec.normalized;
        // 가이드라인의 방향을 distanceVec의 방향으로 설정하겠다는 뜻.
        // .normalized는 Vector / Vector.magnitude와 같음
        // 방향에 관련된 것은 전부 방향 벡터로 설정해야함. 크기가 1이기 때문에 오류를 피할 수 있음.
    }
}
