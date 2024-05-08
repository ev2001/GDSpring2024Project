using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healthValue = 1;
    [SerializeField] private AudioClip pickupSound;

    private AudioSource audioSource;

    private void Awake(){
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = pickupSound;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            other.GetComponent<Creature>().IncreaseHealth(healthValue);
            //audioSource.Play();
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            ObjectPooler.Instance.ReturnObjectToPool(gameObject);
        }
    }
}
