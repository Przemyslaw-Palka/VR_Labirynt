using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject Image;         
    public AudioSource audioSource;  
    private Camera playerCamera;     

    void Start()
    {
    
        if (Camera.main != null)
        {
            playerCamera = Camera.main; 
        }
        else
        {
            Debug.LogError("Nie znaleziono glownej kamery!.");
        }

        
        if (Image != null)
        {
            Image.SetActive(false);
        }
        else
        {
            Debug.LogError("Nie przypisano obiektu Image w inspektorze!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {


            Vector3 spawnPosition = playerCamera.transform.position + playerCamera.transform.forward * 0.5f;
            Image.transform.position = spawnPosition;


            Image.transform.rotation = Quaternion.LookRotation(playerCamera.transform.forward);


            Image.SetActive(true);


            if (audioSource != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("Nie przypisano AudioSource w inspektorze!");
            }


            StartCoroutine(DisableImg());
        }
        else
        {
            Debug.Log("W trigger wszedl obiekt: " + other.name);
        }
    }

    IEnumerator DisableImg()
    {

        yield return new WaitForSeconds(5f);
        if (Image != null)
        {
            Image.SetActive(false);
        }
    }
}
