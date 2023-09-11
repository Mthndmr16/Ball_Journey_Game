using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    bool isHitting = true;
    public IEnumerator CameraShake(float duration, float magnitude )
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            float x = Random.Range(-1f,1f) * magnitude;
            float y = Random.Range(-1f,1f) * magnitude;

            transform.localPosition = new Vector3( x, y, originalPosition.z );

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPosition;
    }

    public void Shaker()
    {
        if (isHitting)
        {
            StartCoroutine(CameraShake(.22f, .4f));
            isHitting = false;  
        }       
    }
}
