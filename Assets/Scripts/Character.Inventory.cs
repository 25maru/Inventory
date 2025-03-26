using System.Collections.Generic;

public partial class Character
{
    public List<InventoryItem> Inventory { get; private set; } = new();

    /// <summary>
    /// 인벤토리에 아이템을 추가합니다.
    /// </summary>
    public void AddItem(ItemData data, int quantity = 1)
    {
        Inventory.Add(new InventoryItem(data, quantity));
    }

    /// <summary>
    /// 장착 아이템을 고려하여 최종 능력치를 반환합니다.
    /// </summary>
    public float GetTotalStat(StatType statType, out float baseValue, out float bonusValue)
    {
        baseValue = statType switch
        {
            StatType.ATK => ATK,
            StatType.DEF => DEF,
            StatType.HP => HP,
            StatType.CRIT => CRIT,
            _ => 0
        };

        bonusValue = 0;

        foreach (var item in Inventory)
        {
            if (item.equipped && item.data.CanEquip)
            {
                foreach (var stat in item.data.equipStats)
                {
                    if (stat.type == statType)
                        bonusValue += stat.value;
                }
            }
        }
        return baseValue + bonusValue;
    }
}