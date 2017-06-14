using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MouseLock : _MonoBehaviour
{
    private bool mouseLockFlag = true;        //마우스를 고정하는 기능

    public bool MouseLock { get; private set; }

    public static _MouseLock instance = null;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        MouseLock = true;
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 잠금 처리
        CheckMouseLock();
    }

    /*
	 *	마우스 잠금 처리 검사
	 */
    private void CheckMouseLock()
    {

        //Esc 키를 눌렀을 때의 동작
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //플래그를 반전시킨다
            MouseLock = mouseLockFlag = !mouseLockFlag;
        }

        //마우스가 잠겨있는지 검사
        if (mouseLockFlag)
        {
            //잠겨 있으면 잠금 해제
            //Screen.lockCursor = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            //잠금이 해제되어 있다면 잠금
            //Screen.lockCursor = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
