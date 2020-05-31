using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float intensityAmount = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<Flashlight>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<Flashlight>().RestoreLightIntensity(intensityAmount);
            Destroy(gameObject);
        }
    }

}
