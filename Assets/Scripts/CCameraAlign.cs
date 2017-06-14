using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraAlign : MonoBehaviour {
    private void Update()
    {
        float aspectRatio = Camera.main.aspect;
        float camSize = Camera.main.orthographicSize;
        float correctPositionX = aspectRatio * camSize;
        Camera.main.transform.position = new Vector3(correctPositionX, camSize, -10f);
    }
}
