using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlane : _MonoBehaviour
{
    public Rigidbody2D _rigidbody2d; // 강체

    public float _riseForce; // 점프 힘

    private void Update()
    {
        // 화면을 넘어갔다면
        if (transform.position.y > 5.5f || transform.position.y < -5.5f)
        {
            // 게임을 중지함
            CGameManager.IsGameStop = true;
            CGameManager.GameEnd();

        }

        // 아무키나 누르고 게임이 중지 상태가 아니라면
        //if (Input.anyKeyDown && (CGameManager.IsGameStop == false))
        if (Input.anyKeyDown && !CGameManager.IsGameStop)
        {
            // 점프를 수행함

            // 속도를 0으로 초기화
            _rigidbody2d.velocity = Vector2.zero;

            // 상승 힘을 부여
            _rigidbody2d.AddForce(Vector2.up * _riseForce);
        }
    }

    // IsTrigger가 체크 되지 않은 오브젝트끼리 충돌
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 현재 비행기가 컬럼이랑 충돌한거라면
        if (collision.gameObject.tag == "Column")
        {
            // 게임을 중지함
            CGameManager.IsGameStop = true;
            CGameManager.GameEnd();
        }
    }

    // IsTrigger가 체크 되어 있는 오브젝트와 충돌
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 비행기가 먹은게 별아이템이면
        if (collision.gameObject.tag == "Star")
        {
            //Debug.Log("별 아이템 충돌");

            // 별 아이템을 파괴함
            Destroy(collision.gameObject);
        }
    }
}