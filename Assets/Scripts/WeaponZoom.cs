using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera = default;
    [SerializeField] Canvas reticle = default;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 35f;

    [SerializeField] float zoomInSpeed = 10f;
    [SerializeField] float zoomOutSpeed = 20f;

    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;

    RigidbodyFirstPersonController fpsController = default;

    Vector3 originalPos = default;

    private void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
        originalPos = GameObject.Find("Weapons").transform.localPosition;
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
            GameObject.Find("Weapons").transform.localPosition = GameObject.Find("Zoomed").transform.localPosition;
            fpsController.mouseLook.XSensitivity = zoomInSensitivity;
            fpsController.mouseLook.YSensitivity = zoomInSensitivity;
        }
        else
        {
            reticle.enabled = true;
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, zoomedOutFOV, Time.deltaTime * zoomOutSpeed);
            GameObject.Find("Weapons").transform.localPosition = originalPos;
            fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
            fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
        }
    }
}
