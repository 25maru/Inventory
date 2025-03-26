using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable
}

public enum StatType
{
    ATK,
    DEF,
    HP,
    CRIT
}

[System.Serializable]
public class EquipStatData
{
    public StatType type;
    public float value;
}

[System.Serializable]
public class ConsumeStatData
{
    public StatType type;
    public float value;
    public float duration;
}

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/Item Data", order = 1)]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;

    public bool CanEquip => type == ItemType.Equipable;
    public bool CanStack => type == ItemType.Consumable;

    [Header("Equip")]
    public EquipStatData[] equipStats;

    [Header("Consume")]
    public ConsumeStatData[] consumeStats;
    public int maxStackAmount;
}
