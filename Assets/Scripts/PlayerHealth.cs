using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
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


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Newspaper"))
        {
            currentEnergy -= newspaperPenalty;
            currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
            energySlider.value = currentEnergy;

            // Optional: destroy the newspaper after the hit
            Destroy(other.gameObject);
        }
    }
}
