using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera = default;
    [SerializeField] Canvas reticle = default;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 35f;

    [SerializeField] float zoomInSpeed = 10f;
    [SerializeField] float zoomOutSpeed = 20f;

    Vector3 originalPos = default;

    private void Start()
    {
        originalPos = GameObject.Find("Carbine").transform.localPosition;
    }

    void Update()
    {
        HoldClickToZoom();
    }

    private void HoldClickToZoom() //smooth zoom transition with controllable speed
    {
        if (Input.GetMouseButton(1))
        {
            reticle.enabled = false;
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, zoomedInFOV, Time.deltaTime * zoomInSpeed);
            GameObject.Find("Carbine").transform.localPosition = GameObject.Find("Zoomed").transform.localPosition;
        }
        else
        {
            reticle.enabled = true;
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, zoomedOutFOV, Time.deltaTime * zoomOutSpeed);
            GameObject.Find("Carbine").transform.localPosition = originalPos;
        }
    }
}
