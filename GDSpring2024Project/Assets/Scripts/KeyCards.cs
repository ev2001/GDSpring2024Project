using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyCards : MonoBehaviour
{
    [SerializeField] InventoryHandler.AllItems itemType;
    [SerializeField] AudioClip pickupSound;

    bool hasBeenPickedUp = false;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (!hasBeenPickedUp && collision.CompareTag("Player")) 
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            InventoryHandler.Instance.AddItem(itemType);
            hasBeenPickedUp = true;
            Destroy(gameObject);
        }
    }
}
