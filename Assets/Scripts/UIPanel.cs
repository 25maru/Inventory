using UnityEngine;
using DG.Tweening;

/// <summary>
/// UI 패널의 활성화/비활성화를 관리하는 클래스입니다.
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class UIPanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    /// <summary>
    /// 현재 패널이 상호작용 가능한 상태인지 확인합니다.
    /// </summary>
    public bool IsActive => canvasGroup.interactable;

    /// <summary>
    /// 패널 초기화 시 CanvasGroup을 설정하고, 기본값으로 비활성화 상태로 설정합니다.
    /// </summary>
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        SetCanvasGroup(false);
    }

    /// <summary>
    /// 패널을 활성화하거나 비활성화합니다.
    /// </summary>
    /// <param name="active">활성화 여부 (true: 보여줌, false: 숨김)</param>
    /// <param name="duration">페이드 인/아웃에 걸리는 시간(초)</param>
    public void SetActivePanel(bool active, float duration = 0.5f)
    {
        if (active == IsActive) return;
        
        if (active) SetCanvasGroup(true);

        DOTween.Kill(canvasGroup);

        canvasGroup.DOFade(active ? 1f : 0f, duration)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => {
                if (!active) SetCanvasGroup(false);
            });
    }

    /// <summary>
    /// CanvasGroup의 상호작용 가능 여부를 설정합니다.
    /// </summary>
    /// <param name="active">상호작용 가능 여부 (true: 허용, false: 차단)</param>
    private void SetCanvasGroup(bool active)
    {
        canvasGroup.interactable = active;
        canvasGroup.blocksRaycasts = active;
    }
}