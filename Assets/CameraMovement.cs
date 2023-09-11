using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float smoothTime = 0.25f;
    private Vector3 offset = new Vector3(0f, 1f, -10f);
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 finalPos = target.position + offset;
        this.transform.position = Vector3.SmoothDamp(this.transform.position, finalPos, ref velocity, smoothTime);
    }
}
