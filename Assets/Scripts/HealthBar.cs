using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHP;
    [SerializeField] private Image currentHP;
    [SerializeField] private Image totalHP;
    [SerializeField] private float totalGambarHati;
    [SerializeField] private float totalAttackFor1HP;
    void Start()
    {
        totalHP.fillAmount = playerHP.healthNow / totalGambarHati / totalAttackFor1HP;   
    }

    void Update()
    {   
        currentHP.fillAmount = playerHP.healthNow / totalGambarHati/ totalAttackFor1HP;
    }
}
