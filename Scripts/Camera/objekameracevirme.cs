using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objekameracevirme : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }
    private void LateUpdate()
    {
        transform.LookAt(
            transform.position + mainCameraTransform.rotation * Vector3.forward,
            mainCameraTransform.rotation * Vector3.up);
    }
}
/*
Hangi objeye atarsak kamera nereye hareket ederse etsin ona dönüyor.

Ben health bar gibi şeylerde kullandım.
-
*/
