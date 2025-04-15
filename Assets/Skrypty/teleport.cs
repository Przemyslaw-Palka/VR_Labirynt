using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XR_Teleport : MonoBehaviour
{
    public Transform destination; 
    public GameObject gracz;      
    public GameObject requiredObject; 

    private bool isPlayerOnTeleport = false; 
    private bool hasRequiredObject = false; 

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOnTeleport = true;
            CheckTeleportConditions();
        }

       
        if (other.gameObject == requiredObject)
        {
            hasRequiredObject = true;
            CheckTeleportConditions();
        }
    }

    void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOnTeleport = false;
        }

       
        if (other.gameObject == requiredObject)
        {
            hasRequiredObject = false;
        }
    }

    private void CheckTeleportConditions()
    {
        
        if (isPlayerOnTeleport && hasRequiredObject)
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        // Wylaczamy komponent ruchu
        var moveProvider = gracz.GetComponent<UnityEngine.XR.Interaction.Toolkit.ActionBasedContinuousMoveProvider>();
        var snapTurnProvider = gracz.GetComponent<UnityEngine.XR.Interaction.Toolkit.ActionBasedSnapTurnProvider>();

        if (moveProvider != null)
        {
            moveProvider.enabled = false;
        }

        if (snapTurnProvider != null)
        {
            snapTurnProvider.enabled = false;
        }

        
        gracz.transform.position = destination.position;

        // Wlaczamy ponownie komponenty ruchu
        if (moveProvider != null)
        {
            moveProvider.enabled = true;
        }

        if (snapTurnProvider != null)
        {
            snapTurnProvider.enabled = true;
        }

    }
}
