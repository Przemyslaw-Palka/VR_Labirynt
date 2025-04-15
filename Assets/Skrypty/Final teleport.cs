using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportWithSceneChange : MonoBehaviour
{
    public GameObject gracz;           
    public GameObject requiredObject; 
    public int sceneToLoad;      

    private bool isPlayerOnTeleport = false;
    private bool hasRequiredObject = false;  

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
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
        
        if (other.CompareTag("Player"))
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
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
       
        var moveProvider = gracz.GetComponent<UnityEngine.XR.Interaction.Toolkit.ActionBasedContinuousMoveProvider>();
        var snapTurnProvider = gracz.GetComponent<UnityEngine.XR.Interaction.Toolkit.ActionBasedSnapTurnProvider>();

        if (moveProvider != null) moveProvider.enabled = false;
        if (snapTurnProvider != null) snapTurnProvider.enabled = false;

        SceneManager.LoadSceneAsync(sceneToLoad);
        SceneManager.UnloadSceneAsync(0);
    }
}
