using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth = 10f;

    public float CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(
            CurrentHealth - damage,
            0f,
            startingHealth
        );

        Debug.Log("Player health: " + CurrentHealth);

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1f);
        }
    }
}