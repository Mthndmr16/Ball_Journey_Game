using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlide : MonoBehaviour
{
    [SerializeField] private Vector3 leftPosition;
    [SerializeField] private Vector3 rightPosition;
    private float speed = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(leftPosition,rightPosition,Mathf.PingPong(Time.time * speed,1f));
    }
}
