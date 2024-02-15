using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private float height;
    private float width;

    private void Update()
    {
        Camera mainCam = Camera.main;
        width = Mathf.Min(10,mainCam.aspect * 2f * mainCam.orthographicSize);
        height = width;
        this.transform.localScale = new Vector3(width,height,0);
    }
}
