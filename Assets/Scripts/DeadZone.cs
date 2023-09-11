using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Hittable" || hit.gameObject.tag == "Obstacle")
        {
            
           hit.gameObject.SetActive(false);
        }
    }
}
