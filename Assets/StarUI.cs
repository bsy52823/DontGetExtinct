using UnityEngine;
using UnityEngine.UI;

public class StarUI : MonoBehaviour
{
    public Image[] starSlots;           // StarSlot1~5
    public Sprite[] coloredStars;       // »¡, ³ë, ÃÊ, ÆÄ, º¸

    public void FillStarSlot(int index)
    {
        if (index >= 0 && index < starSlots.Length)
        {
            starSlots[index].sprite = coloredStars[index];
        }
    }
}
