using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;

    public float detectionRange = 10f;
    public float moveSpeed = 2f;
    public float stopDistance = 1.5f;

    void Update()
{
    float distance = Vector3.Distance(transform.position, player.position);

    Debug.Log("Distance to player: " + distance);

    if (distance <= detectionRange && distance > stopDistance)
    {
        Debug.Log("Enemy is chasing!");

        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;

        transform.LookAt(new Vector3(
            player.position.x,
            transform.position.y,
            player.position.z
        ));
    }
}
}