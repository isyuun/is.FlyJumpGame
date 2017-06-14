using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COjbectMove : MonoBehaviour
{
    public Rigidbody2D _rigidbody2d; // 강체(물리엔진) 컴포넌트

    public float _speed; // 이동 속도

    public Vector2 _direction; // 이동 방향

    // Use this for initialization
    private void Start()
    {
        //Debug.Log("direction normalized => " + _direction.normalized);

        // 지정한 방향으로 지정한 속도대로 이동시킴
        _rigidbody2d.velocity = _direction.normalized * _speed;
    }

    private void Update()
    {
        // 게임이 중지 상태라면
        if (CGameManager.IsGameStop)
        {
            // 오브젝트 이동을 중지함
            _rigidbody2d.velocity = Vector2.zero;
        }

        // 현재 기둥이 왼쪽 -12f 지점을 넘으면 삭제함
        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }
}