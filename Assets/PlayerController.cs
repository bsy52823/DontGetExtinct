using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rigid2D;
    Animator animator;

    private Vector2 moveInput;  // 입력 방향
    private SpriteRenderer spriteRenderer;  // 좌우 반전용 SpriteRenderer

    void Start()
    {
        Application.targetFrameRate = 60;

        this.rigid2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 좌우 입력 받아오기
        float moveX = Input.GetAxisRaw("Horizontal");
        moveInput = new Vector2(moveX, 0f).normalized;

        // 이동 방향에 따라 캐릭터 방향 반전
        if (moveX != 0)
            spriteRenderer.flipX = moveX > 0;
    }

    void FixedUpdate()
    {
        rigid2D.linearVelocity = new Vector2(moveInput.x * moveSpeed, rigid2D.linearVelocity.y);
    }

    void LateUpdate()
    {
        ClampToScreen(); // 화면 바깥 이동 제한
    }

    void ClampToScreen()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        float margin = 0.07f; // 여유 마진 (7%) 화면 여백 설정

        viewPos.x = Mathf.Clamp(viewPos.x, margin, 1f - margin);
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }
}
