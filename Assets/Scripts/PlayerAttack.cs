using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Camera playerCamera;
    public float attackRange = 5f;
    public int damage = 25;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Attack();
        }
    }

   void Attack()
{
    Ray ray = new Ray(
        playerCamera.transform.position,
        playerCamera.transform.forward
    );

    int layerMask = ~LayerMask.GetMask("Player");

    float hitRadius = 0.75f;

    if (Physics.SphereCast(ray, hitRadius, out RaycastHit hit, attackRange, layerMask))
    {
        Debug.Log("Attack hit: " + hit.collider.gameObject.name);

        EnemyHealth enemyHealth =
            hit.collider.GetComponentInParent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
            Debug.Log("Enemy hit!");
        }
    }
}
}