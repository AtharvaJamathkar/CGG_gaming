using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class EnemyInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public Transform player;
    public TextMeshProUGUI interactionText;
    public GameObject dialoguePanel;
    public EnemyHealth enemyHealth;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= interactionDistance)
        {
            interactionText.gameObject.SetActive(true);

           if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                dialoguePanel.SetActive(true);
                interactionText.gameObject.SetActive(false);

                Debug.Log("Talking to mysterious guy...");
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}