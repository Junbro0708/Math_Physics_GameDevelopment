using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    private Rigidbody2D warriorRigidbody2D;

    public float jumpPower;
    public float speed;
    void Start()
    {
        warriorRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMove();
        PlayerJump();
    }
    
    void PlayerMove()
    {
        float  x = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (x * speed * Time.deltaTime));
    }

    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            warriorRigidbody2D.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D _col)
    {
        if (_col.gameObject.tag != "Ground")
        {
            UpOrDown(_col);
        }
    }

    void UpOrDown(Collision2D _col)
    {
        Vector3 distVec = transform.position - _col.transform.position;
        if (Vector3.Cross(_col.transform.right, distVec).z > 0)
        {
            Debug.Log("Up");
            return;
        }
        Debug.Log("Down");
    }
 
}
