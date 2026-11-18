using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [SerializeField] private float damage = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth =
                collision.gameObject.GetComponentInParent<Health>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}