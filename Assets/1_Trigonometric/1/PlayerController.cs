using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 4가지의 실습.
// 1. Player 이동 2. Player 이동 패턴을 원을 그리며 이동 3. 미사일 발사(순차적) 4. 미사일 발사(한번에)
public enum Pattern { One, Two };
public class PlayerController : MonoBehaviour
{
    public GameObject bulletObject;
    public Transform bulletContainer;

    public Pattern shotPattern; // 패턴을 선택할 수 있게 되어 있음
    public float moveSpeed = 2f;
    public float circleScale = 5f;
    public int angleInterval = 10;
    public int startAngle = 30;
    public int endAngle = 330;

    private int iteration = 0;
    
    private void Start()
    {
        if (shotPattern == Pattern.One)
            StartCoroutine(MakeBullet());
        else if (shotPattern == Pattern.Two)
            StartCoroutine(MakeBullet2());
    }

    private void Update()
    {
        //PlayerMove(30);
        //PlayerCircle();
    }

    void PlayerMove(float _angle)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 direction = new Vector2(Mathf.Cos(_angle * Mathf.Deg2Rad), Mathf.Sin(_angle * Mathf.Deg2Rad));
            //Mathf에 들어가는 각도는 라디안으로 들어감 Deg2Rad은 디그리 값을 라디안으로 변환하는 키워드
            transform.Translate(moveSpeed * direction * Time.deltaTime);
        }
    }

    void PlayerCircle()
    {
        Vector2 direction = new Vector2(Mathf.Cos(iteration * Mathf.Deg2Rad), Mathf.Sin(iteration * Mathf.Deg2Rad));
        transform.Translate(direction * (circleScale * Time.deltaTime));
        iteration++;
        if (iteration > 360) iteration -= 360;
    }

    private IEnumerator MakeBullet()
    {
        int fireAngle = 0;
        while (true)
        {
            GameObject tempObject = Instantiate(bulletObject, bulletContainer, true);
            Vector2 direction = new Vector2(Mathf.Cos(fireAngle*Mathf.Deg2Rad),Mathf.Sin(fireAngle*Mathf.Deg2Rad));
            tempObject.transform.right = direction;
            tempObject.transform.position = transform.position;

            yield return new WaitForSeconds(0.1f);
            
            fireAngle += angleInterval;
            if (fireAngle > 360) fireAngle -= 360;
        }
    }
    
    private IEnumerator MakeBullet2()
    {
        while (true)
        {
            for (int fireAngle = startAngle; fireAngle < endAngle; fireAngle += angleInterval)
            {
                GameObject tempObject = Instantiate(bulletObject, bulletContainer, true);
                Vector2 direction = new Vector2(Mathf.Cos(fireAngle*Mathf.Deg2Rad),Mathf.Sin(fireAngle*Mathf.Deg2Rad));
               
                tempObject.transform.right = direction;
                tempObject.transform.position = transform.position;
            }

            yield return new WaitForSeconds(4f);
        }
    }
}
