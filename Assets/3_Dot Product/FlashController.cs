using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class FlashController : MonoBehaviour
{
    public GameObject[] ghostObjectArray;

    public float moveSpeed = 3f;
    public float rangeAngle = 25f;
    public float rangeDistance = 4f;
    void Update()
    {
        PlayerMove();
        CheckGhost();
    }

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(x,y) * (moveSpeed * Time.deltaTime));
    }

    void CheckGhost()
    {
        int i = 0;
        foreach (var ghost in ghostObjectArray)
        {
            Vector3 distanceVec = ghost.transform.position - transform.position;
            if (distanceVec.magnitude < rangeDistance)
            {
                Vector3 dirVec = distanceVec.normalized;
                
                if(Vector3.Dot(transform.up, dirVec) > Mathf.Cos(rangeAngle*Mathf.Deg2Rad))
                    i++;
            }
        }
        
        Debug.Log("감지된 유령의 수: "+i);
    }
}
