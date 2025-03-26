using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem
{
    public ItemData data;
    public int quantity;
    public bool equipped;

    public InventoryItem(ItemData data, int quantity = 1)
    {
        this.data = data;
        this.quantity = quantity;
        this.equipped = false;
    }
}

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Transform slotParent;
    [SerializeField] private ItemSlot slotPrefab;

    private List<ItemSlot> slotList = new();
    private List<InventoryItem> inventory;

    private Character character;
    private UIStatus statusUI;

    /// <summary>
    /// 인벤토리 UI를 초기화하고 슬롯을 생성합니다.
    /// </summary>
    public void Init(List<InventoryItem> inventory, Character character, UIStatus statusUI)
    {
        this.inventory = inventory;
        this.character = character;
        this.statusUI = statusUI;

        RefreshUI();
    }

    /// <summary>
    /// 인벤토리 슬롯 UI를 모두 다시 생성합니다.
    /// </summary>
    public void RefreshUI()
    {
        foreach (Transform child in slotParent)
            Destroy(child.gameObject);
        slotList.Clear();

        for (int i = 0; i < inventory.Count; i++)
        {
            var item = inventory[i];
            var slot = Instantiate(slotPrefab, slotParent);
            slot.Inventory = this;
            slot.Item = item.data;
            slot.Quantity = item.quantity;
            slot.Equipped = item.equipped;
            slot.Index = i;
            slot.Set();
            slot.Button.onClick.AddListener(() => SelectItem(slot.Index));
            slotList.Add(slot);
        }
    }

    /// <summary>
    /// 선택한 아이템을 장착 또는 해제합니다.
    /// </summary>
    public void SelectItem(int index)
    {
        var item = inventory[index];

        if (item.data.CanEquip)
            item.equipped = !item.equipped;

        RefreshUI();
        statusUI.SetCharacterInfo(character);
    }
}