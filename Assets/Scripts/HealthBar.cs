using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image HealthBarTotal;
    [SerializeField]  private Image HealthBarCurrent;

    private void Start()
    {
        HealthBarTotal.fillAmount = playerHealth.CurrentHealth / 10;

    }

    private void Update()
    {
        HealthBarCurrent.fillAmount = playerHealth.CurrentHealth / 10;
    }
}
