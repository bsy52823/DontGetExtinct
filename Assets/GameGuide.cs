using UnityEngine;

public class GameGuide : MonoBehaviour
{
    public GameObject guidePanel;
    public GameObject player;
    public GameObject itemGenerator;

    private bool guideActive = true; // 현재 가이드가 보이는지 여부

    void Start()
    {
        // 시작 시: 가이드 패널 표시, 게임 정지 상태
        guidePanel.SetActive(true);
        player.SetActive(false);
        itemGenerator.SetActive(false);
    }

    void Update()
    {
        // 가이드 상태이고 클릭(터치)되면 시작
        if (guideActive && Input.GetMouseButtonDown(0))
        {
            guidePanel.SetActive(false);    // 설명 패널 숨김
            player.SetActive(true);         // 플레이어 활성화
            itemGenerator.SetActive(true);  // 아이템 생성 시작
            guideActive = false;

            GameManager.Instance.isGameStarted = true; // 점수 타이머 시작
        }
    }
}
