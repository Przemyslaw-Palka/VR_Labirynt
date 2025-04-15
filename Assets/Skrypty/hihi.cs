using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XR_FakeTeleport : MonoBehaviour
{
    public Transform destination; // Punkt docelowy teleportacji
    public GameObject gracz;      // Obiekt "Gracz" (ca³y XR Rig)
    public AudioClip teleportSound; // DŸwiêk teleportacji

    private AudioSource audioSource;

    void Start()
    {
        // Dodajemy komponent AudioSource do obiektu z tym skryptem
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = teleportSound;
        audioSource.playOnAwake = false; // Nie odtwarzaj dŸwiêku przy starcie
    }

    void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy obiekt koliduj¹cy to nasz XR Rig
        if (other.gameObject.CompareTag("Player"))
        {
            // Odtwarzamy dŸwiêk teleportacji
            audioSource.Play();

            // Wy³¹czamy kontroler ruchu, aby unikn¹æ problemów
            var moveProvider = gracz.GetComponent<UnityEngine.XR.Interaction.Toolkit.ActionBasedContinuousMoveProvider>();
            if (moveProvider != null)
            {
                moveProvider.enabled = false;
            }

            // Przenosimy gracza na punkt docelowy
            gracz.transform.position = destination.position;

            // W³¹czamy kontroler ruchu ponownie
            if (moveProvider != null)
            {
                moveProvider.enabled = true;
            }
        }
    }
}
