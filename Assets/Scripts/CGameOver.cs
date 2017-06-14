using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameOver : _MonoBehaviour
{
    public Text bestStarCountText;

    private void Start()
    {
        bestStarCountText.text = PlayerPrefs.GetInt("BestStarCount").ToString();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            CGameManager2.GameStart();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.SetInt("BestStarCount", 0);
        }
    }
}
