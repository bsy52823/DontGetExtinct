using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // UI 연결
    public HeartUI heartUI;
    public StarUI starUI;
    public TextMeshProUGUI scoreText;   // 점수 UI 텍스트

    // 점수 설정
    private int score = 0;
    private float scoreTimer = 0f;
    public float scoreInterval = 1f; // 점수 갱신 간격 (1초당)
    public int scorePerTick = 10;    // 초당 증가 점수 (10점)

    // 게임 진행
    public bool isGameStarted = false;  // 게임 시작 상태 변수
    public int currentStarIndex = 0;    // 수집 중인 별의 인덱스
    public int maxHearts = 3;           // 최대 하트 수
    private int currentHearts;

    // 플로팅 점수 효과
    public GameObject floatingScorePrefab;  // 프리팹 연결
    public Canvas worldCanvas;              // Canvas 참조

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        currentHearts = maxHearts;
        UpdateScoreUI(); // 초기 점수 0 표시
    }

    void Update()
    {
        if (!isGameStarted) return;  // 게임 시작 전이면 점수 타이머 계산 중지

        scoreTimer += Time.deltaTime;

        if (scoreTimer >= scoreInterval)
        {
            scoreTimer = 0f;
            AddScore(scorePerTick); // 시간당 점수 추가
        }
    }

    public void OnPlayerHit()
    {
        currentHearts--;
        heartUI.UpdateHearts(currentHearts); // 하트 UI 갱신
        // Debug.Log("플레이어 피격, 남은 하트: " + currentHearts);

        AddScore(-50); // 미트볼 피격 시 감점
        ShowFloatingScore(-50, HexToColor("#B86B28")); // 감점 연출
        SFXManager.Instance.PlayMeatballHit();         // 감점 효과음 재생

        if (currentHearts <= 0)
        {
            GameOver();
        }
    }

    // 해당 순서인 색 별만 수집 가능
    public bool CanCollect(int starIndex)
    {
        return starIndex == currentStarIndex;
    }

    // 별을 수집했을 때 호출
    public void CollectStar(int starIndex, Vector3 worldPosition)
    {
        if (!CanCollect(starIndex)) return;

        int[] starScore = { 100, 200, 300, 400, 500 };
        string[] starHexColors = {
            "#E88686", // 빨강
            "#E6B667", // 노랑
            "#BAC573", // 초록
            "#80C6C2", // 파랑
            "#AE90C1"  // 보라
        };

        int reward = starScore[starIndex];
        AddScore(reward); // 별 수집 시 득점
        ShowFloatingScore(reward, HexToColor(starHexColors[starIndex])); // 득점 연출
        SFXManager.Instance.PlayStarCollect(); // 득점 효과음

        starUI.FillStarSlot(starIndex);
        currentStarIndex++;

        if (currentStarIndex >= 5) // 별 5개 수집 시
        {
            GameClear(); // 게임 클리어 처리
        }
    }


    public bool HasNextStar()
    {
        return currentStarIndex < 5;
    }

    public int GetCurrentStarIndex()
    {
        return currentStarIndex;
    }

    // 점수 계산 후 UI 갱신
    public void AddScore(int amount)
    {
        score += amount;
        score = Mathf.Max(0, score); // 점수는 0 미만으로 내려가지 않게
        UpdateScoreUI();
    }

    // UI 텍스트 반영
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = Mathf.FloorToInt(score).ToString();
        }
    }

    // 점수 떠오르는 이펙트 표시
    private void ShowFloatingScore(int amount, Color color)
    {
        Vector3 fixedPosition = scoreText.transform.position + new Vector3(0, -50f, 0); // 위치 조정 필요

        GameObject go = Instantiate(floatingScorePrefab, worldCanvas.transform);
        go.transform.position = fixedPosition;

        TMP_Text text = go.GetComponent<TMP_Text>();
        text.text = (amount > 0 ? "+" : "") + amount.ToString();
        text.color = color;
    }

    // HTML 형식 색상 코드를 Color로 변환
    private Color HexToColor(string hex)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        return Color.white;
    }

    // 게임 오버 처리
    private void GameOver()
    {
        // Debug.Log("게임 오버!");
        SceneManager.LoadScene("OverScene");
    }

    // 게임 클리어 처리
    private void GameClear()
    {
        // Debug.Log("게임 클리어!");
        SceneManager.LoadScene("ClearScene");
    }
}
