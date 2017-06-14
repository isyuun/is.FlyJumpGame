using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CGameManager : _MonoBehaviour
{
    // 게임 진행 여부
    public static bool IsGameStop = false;

    public static void GameEnd()
    {
        // 종료 씬으로 이동함
        SceneManager.LoadScene("End");
    }
}