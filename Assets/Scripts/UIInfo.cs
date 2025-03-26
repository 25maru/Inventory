using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI levelBarText;
    [SerializeField] private Image levelBarFill;

    public void SetCharacterInfo(Character character)
    {
        nameText.text = $"{character.Name}";
        descriptionText.text = $"{character.Description}";
        levelText.text = $"Lv <font=\"GmarketSansBold SDF\"><size=40>{character.Level}";
        levelBarText.text = $"{character.CurEXP} / {character.MaxEXP}";
        levelBarFill.fillAmount = (float)character.CurEXP / character.MaxEXP;
    }
}