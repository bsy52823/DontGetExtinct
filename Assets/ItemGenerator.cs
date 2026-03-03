using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject meatballPrefab;
    public GameObject[] starPrefabs; // 빨강, 노랑, 초록, 파랑, 보라 순서

    public float span = 1.0f;
    private float delta = 0;

    private bool starExists = false;  // 현재 화면에 별이 이미 존재하는지 여부

    void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > this.span)
        {
            this.delta = 0;

            // 미트볼 생성
            Vector3 meatballPos = new Vector3(Random.Range(-6, 7), 7f, 0f);
            Instantiate(meatballPrefab, meatballPos, Quaternion.identity);

            // 별 생성 (현재 목표 별만 등장, 현재 생성된 별 없음)
            if (!starExists && Random.value < 0.3f && GameManager.Instance.HasNextStar())
            {
                int starIndex = GameManager.Instance.GetCurrentStarIndex();
                GameObject starPrefab = starPrefabs[starIndex];

                Vector3 starPos = new Vector3(Random.Range(-6, 7), 9f, 0f);
                GameObject star = Instantiate(starPrefab, starPos, Quaternion.identity);

                // 별 프리팹에 Generator 연결
                ItemController ic = star.GetComponent<ItemController>();
                if (ic != null)
                {
                    ic.SetGenerator(this);
                }

                starExists = true;  // 별 생성 상태로 전환
            }
        }
    }

    // 별이 제거되었을 때 호출됨
    public void NotifyStarDestroyed()
    {
        this.starExists = false;
    }
}