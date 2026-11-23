using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private bool hasLoadedNextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasLoadedNextLevel)
            return;

        if (collision.CompareTag("Player"))
        {
            hasLoadedNextLevel = true;
            SceneController.Instance.NextLevel();
        }
    }
}