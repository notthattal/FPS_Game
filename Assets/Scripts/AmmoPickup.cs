using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType = default;
    [SerializeField] AudioClip pickupSFX = default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
            StartCoroutine(Pickup());
        }
    }

    IEnumerator Pickup()
    {
        GetComponent<AudioSource>().PlayOneShot(pickupSFX);
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
