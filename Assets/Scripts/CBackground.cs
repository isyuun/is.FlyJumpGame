using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBackground : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        // 씬이 넘어가도 배경을 삭제하지 않음
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // 게임이 정지 상태면
        if (CGameManager.IsGameStop)
        {
            // 애니메이션을 멈춰라
            _animator.speed = 0;
        }
    }
}