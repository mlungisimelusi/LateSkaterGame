using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    public Slider energySlider;
    public float maxEnergy = 100f;
    public float currentEnergy;
    public float drainRate = 20f;
    public float newspaperPenalty = 10f;

    void Start()
    {
        currentEnergy = maxEnergy;
        energySlider.maxValue = maxEnergy;
        energySlider.value = currentEnergy;
    }

    void Update()
    {
        // Drain energy when holding shift
        if (Input.GetKey(KeyCode.LeftShift) && currentEnergy > 0)
        {
            currentEnergy -= drainRate * Time.deltaTime;
        }

        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
        energySlider.value = currentEnergy;
    }

    public bool HasEnoughEnergy(float cost)
    {
        return currentEnergy >= cost;
    }

    public void UseEnergy(float cost)
    {
        currentEnergy -= cost;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
        energySlider.value = currentEnergy;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Newspaper"))
        {
            currentEnergy -= newspaperPenalty;
            currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
            energySlider.value = currentEnergy;
        }
    }
}
