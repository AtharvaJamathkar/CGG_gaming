using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public Camera playerCamera;
    public float interactDistance = 3f;
    public SignalSource signalSource;

    void Update()
{
    if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
    {
        Debug.Log("E PRESSED");
        TryInteract();
    }
}

    void TryInteract()
{
    Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

    if (Physics.Raycast(ray, out RaycastHit hit, 10f, ~LayerMask.GetMask("Player")))
    {
        if (hit.collider.CompareTag("WalkieTalkie"))
        {
            Destroy(hit.collider.gameObject);
            signalSource.StartSignal();
            Debug.Log("Walkie-talkie picked up!");
        }
    }
}
}