using UnityEngine;

public class ItemController : MonoBehaviour
{
    // 아이템 타입 구분 : 미트볼 또는 별
    public enum ItemType { Meatball, Star }
    public ItemType itemType;

    public int starIndex; // 0 = 빨강, 1 = 노랑, ..., 4 = 보라
    public float dropSpeed = -0.1f;

    private ItemGenerator generator;  // 별 생성기(연결된 Generator) 참조

    // 외부에서 ItemGenerator를 설정할 수 있게 함
    public void SetGenerator(ItemGenerator gen)
    {
        generator = gen;
    }

    void Update()
    {
        // 프레임마다 등속으로 낙하시킨다.
        transform.Translate(0, this.dropSpeed, 0);

        // 화면 밖으로 나오면 오브젝트를 삭제한다.
        if (transform.position.y < -5.0f)
        {
            NotifyDestroyIfStar();  // 별이면 제거 알림을 보냄
            Destroy(gameObject);
        }
    }

    // 충돌 처리 (Trigger 방식 사용 시)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        switch (itemType)
        {
            case ItemType.Meatball: // 플레이어가 미트볼에 맞았을 경우
                GameManager.Instance.OnPlayerHit(); // 하트 감소
                Destroy(gameObject);
                break;

            case ItemType.Star:     // 플레이어가 별을 획득했을 경우
                if (GameManager.Instance.CanCollect(starIndex))
                {
                    // 별 수집 처리
                    GameManager.Instance.CollectStar(starIndex, transform.position);
                    NotifyDestroyIfStar(); // 별이면 제거 알림을 보냄
                    Destroy(gameObject);
                }
                break;
        }
    }

    // 현재 오브젝트가 별이고 Generator가 연결되어 있다면, 제거 알림을 보냄
    private void NotifyDestroyIfStar()
    {
        if (itemType == ItemType.Star && generator != null)
        {
            generator.NotifyStarDestroyed();
        }
    }
}