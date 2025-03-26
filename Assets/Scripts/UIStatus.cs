using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI atkText;
    [SerializeField] private TextMeshProUGUI defText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI critText;

    private Character character;

    /// <summary>
    /// 캐릭터 능력치 정보를 스탯 UI에 표시합니다.
    /// </summary>
    public void SetCharacterInfo(Character character)
    {
        this.character = character;


        float totalAtk = character.GetTotalStat(StatType.ATK, out float baseAtk, out float bonusAtk);
        float totalDef = character.GetTotalStat(StatType.DEF, out float baseDef, out float bonusDef);
        float totalHP = character.GetTotalStat(StatType.HP, out float baseHP, out float bonusHP);
        float totalCrit = character.GetTotalStat(StatType.CRIT, out float baseCrit, out float bonusCrit);

        atkText.text = $"공격력\n<font=\"GmarketSansBold SDF\">{totalAtk} <size=15><color=#ccc>({baseAtk}+<color=#fc3>{bonusAtk}<color=#ccc>)";
        defText.text = $"방어력\n<font=\"GmarketSansBold SDF\">{totalDef} <size=15><color=#ccc>({baseDef}+<color=#d8f>{bonusDef}<color=#ccc>)";
        hpText.text = $"체력\n<font=\"GmarketSansBold SDF\">{totalHP} <size=15><color=#ccc>({baseHP}+<color=#d8f>{bonusHP}<color=#ccc>)";
        critText.text = $"치명타\n<font=\"GmarketSansBold SDF\">{totalCrit}% <size=15><color=#ccc>({baseCrit}+<color=#5df>{bonusCrit}<color=#ccc>)";
    }
}