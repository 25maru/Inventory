using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<ItemData> itemDatabase;
    [SerializeField] private UIManager uIManager;

    /// <summary>
    /// 게임 시작 시 캐릭터를 초기화하고 UIManager에 전달합니다.
    /// </summary>
    private void Start()
    {
        var player = new Character(
            name: "마루",
            description: "내일배움캠프 8기 수강생입니다.\nUnity 배치고사에서 스탠다드로 강등되었습니다!",
            level: 10,
            curExp: 9,
            maxExp: 12,
            atk: 35,
            def: 40,
            hp: 100,
            crit: 25
        );

        foreach (var item in itemDatabase)
            player.AddItem(item);

        uIManager.Initialize(player);
    }
}