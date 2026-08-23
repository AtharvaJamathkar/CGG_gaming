using UnityEngine;

public class SignalSource : MonoBehaviour
{
    public float signalRange = 100f;

    private Transform player;
    private bool signalActive = false;
    private AudioSource audioSource;

    public void StartSignal()
    {
        signalActive = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();

        Debug.Log("SIGNAL STARTED!");
    }

    void Update()
{
    if (!signalActive || player == null)
        return;

    float distance = Vector3.Distance(transform.position, player.position);

    float strength = Mathf.Clamp01(1f - (distance / signalRange));

    audioSource.volume = strength;

    // Stop radio when player gets close
    if (distance <= 3f)
    {
        audioSource.Stop();
        signalActive = false;
    }
}
}