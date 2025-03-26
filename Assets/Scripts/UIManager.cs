using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum PanelType
{
    Main,
    Status,
    Inventory
}

/// <summary>
/// PanelType과 UIPanel 오브젝트를 연결하는 데이터 구조입니다.
/// </summary>
[System.Serializable]
public class UIPanelBinding
{
    public PanelType type;
    public UIPanel panel;
}

/// <summary>
/// 전체 UI 패널들을 중앙에서 제어하는 매니저입니다.
/// </summary>
public class UIManager : MonoBehaviour
{
    public Character Player { get; private set; }

    [Foldout("Info", true)]
    [SerializeField] private UIInfo infoUI;

    [Foldout("Panels", true)]
    [SerializeField] private List<UIPanelBinding> panelList;

    [Foldout("Inventory", true)]
    [SerializeField] private UIInventory inventoryUI;
    [SerializeField] private UIStatus statusUI;

    [Foldout("Buttons", true)]
    [SerializeField] private Button openStatusBtn;
    [SerializeField] private Button closeStatusBtn;
    [SerializeField] private Button openInventoryBtn;
    [SerializeField] private Button closeInventoryBtn;

    [Foldout("Transition", true)]
    [SerializeField] private float transitionDuration = 0.5f;

    private Dictionary<PanelType, UIPanel> panelDict;

    /// <summary>
    /// 캐릭터 정보를 모든 UI 요소에 전달하고 버튼/패널 초기화합니다.
    /// </summary>
    public void Initialize(Character player)
    {
        infoUI.SetCharacterInfo(player);
        statusUI.SetCharacterInfo(player);
        inventoryUI.Init(player.Inventory, player, statusUI);

        panelDict = new Dictionary<PanelType, UIPanel>();
        foreach (var binding in panelList)
        {
            if (!panelDict.ContainsKey(binding.type) && binding.panel != null)
                panelDict.Add(binding.type, binding.panel);
        }

        ShowPanel();
        InitButtonListener();
    }

    /// <summary>
    /// 패널 전환 버튼 이벤트를 등록합니다.
    /// </summary>
    private void InitButtonListener()
    {
        openStatusBtn.onClick.AddListener(() => ShowPanel(PanelType.Status));
        closeStatusBtn.onClick.AddListener(() => ShowPanel());
        openInventoryBtn.onClick.AddListener(() => ShowPanel(PanelType.Inventory));
        closeInventoryBtn.onClick.AddListener(() => ShowPanel());
    }

    /// <summary>
    /// 지정한 패널만 활성화하고 나머지는 비활성화합니다.
    /// </summary>
    public void ShowPanel(PanelType target = PanelType.Main)
    {
        if (!panelDict.ContainsKey(target))
        {
            Debug.LogWarning($"UIManager: '{target}' 패널이 등록되어 있지 않습니다!");
            return;
        }

        UIPanel targetPanel = panelDict[target];
        UIPanel currentPanel = null;

        foreach (var pair in panelDict)
        {
            if (pair.Value.IsActive && pair.Key != target)
            {
                currentPanel = pair.Value;
                break;
            }
        }

        if (currentPanel != null)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.AppendCallback(() => currentPanel.SetActivePanel(false, transitionDuration));
            sequence.AppendInterval(transitionDuration);
            sequence.AppendCallback(() => targetPanel.SetActivePanel(true, transitionDuration));
        }
        else
        {
            targetPanel.SetActivePanel(true, transitionDuration);
        }
    }
}
