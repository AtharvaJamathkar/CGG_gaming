using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;
    public float attackDistance = 1.8f;
    public int damage = 20;
    public float attackCooldown = 1.5f;

    private float nextAttackTime;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackDistance && Time.time >= nextAttackTime)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Enemy attacked player!");

                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
}