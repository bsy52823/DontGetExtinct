using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Image[] heartImages;         // 3°³
    public Sprite fullHeartSprite;
    public Sprite bittenHeartSprite;

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            int indexFromRight = heartImages.Length - 1 - i;

            heartImages[indexFromRight].sprite = (i < currentHealth) ? fullHeartSprite : bittenHeartSprite;
        }
    }
}
