using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CGameManager2 : CGameManager
{
    public Text starCountText;
    static int starCount = 0;

    public static void GameStart()
    {
        IsGameStop = false;
        SceneManager.LoadScene("Game");
    }

    private void Reset()
    {
        Debug.Log(this.GetMethodName());
        starCount = 0;
    }

    private void Start()
    {
        Debug.Log(this.GetMethodName());
        Reset();
    }

    public static void StarCountUp()
    {
        starCount++;
    }

    private void Update()
    {
        if (int.Parse(starCountText.text) != starCount)
        {
            starCountText.text = starCount.ToString();
            if (PlayerPrefs.GetInt("BestStarCount") < starCount)
            {
                PlayerPrefs.SetInt("BestStarCount", starCount);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CGameManager2.GameStart();
        }
    }
}
