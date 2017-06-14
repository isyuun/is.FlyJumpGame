using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cplane2 : CPlane
{
    private float MAX_LEVEL = 5.5f;
    //private float MIN_LEVEL = -5.5f;

    private Rigidbody2D rb;

    void GameOver()
    {
        CGameManager2.IsGameStop = true;
        CGameManager2.GameEnd();
    }

    void DisableRagdoll()
    {
        //Debug.Log(this.GetMethodName());
        ///*if (rb != null && rb.isKinematic) */rb.isKinematic = true;
    }

    void EnableRagdoll()
    {
        //Debug.Log(this.GetMethodName());
        ///*if (rb != null && !rb.isKinematic) */rb.isKinematic = false;
    }

    private void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        MAX_LEVEL += transform.position.y;
        EnableRagdoll();
    }

    private void Update()
    {
        // 화면을 위로 넘어갔다면
        if (transform.position.y > MAX_LEVEL)
        {
            Debug.Log(this.GetMethodName() + "!!!HIGH!!!" + ":" + transform.position.y);
            CGameManager2.IsGameStop = true;
        }

        // 화면을 아래로 넘어갔다면
        else if (transform.position.y < -MAX_LEVEL)
        {
            Debug.Log(this.GetMethodName() + "!!!LOW!!!" + ":" + transform.position.y);
            GameOver();
        }

        // 아무키나 누르고 게임이 중지 상태가 아니라면
        //if (Input.anyKeyDown && (CGameManager2.IsGameStop == false))
        if ((/*Input.anyKey || */Input.anyKeyDown) && !CGameManager2.IsGameStop)
        {
            // 점프를 수행함

            // 속도를 0으로 초기화
            _rigidbody2d.velocity = Vector2.zero;

            // 상승 힘을 부여
            _rigidbody2d.AddForce(Vector2.up * _riseForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(this.GetMethodName() + ":" + collision + ":BoxCollider2D:" + (collision.collider is BoxCollider2D) + ":CircleCollider2D:" + (collision.collider is CircleCollider2D));
        // 현재 비행기가 컬럼이랑 충돌한거라면
        if (collision.gameObject.tag == "Column")
        {
            //컬럼이랑 충돌하고 화면 하단을 넘으면 게임을 종료함
            CGameManager2.IsGameStop = true;
            if (collision.collider is CircleCollider2D)
            {
                DisableRagdoll();
                //컬럼위에 걸쳤을때는 3초뒤에 게임을 종료함
                Invoke("GameOver", 3.0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(this.GetMethodName() + ":" + collision + ":" + collision.gameObject.tag);
        // 비행기가 먹은게 별아이템이면
        if (collision.gameObject.tag == "Star")
        {
            //Debug.Log("별 아이템 충돌");

            // 별 아이템을 파괴함
            Destroy(collision.gameObject);

            // star count up
            CGameManager2.StarCountUp();
        }
    }
}
