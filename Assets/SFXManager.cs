using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioClip starCollect;   // 별 수집 효과음
    public AudioClip meatballHit;   // 미트볼 피격 효과음

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환해도 유지
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();  // AudioSource 가져오기
    }

    // 별 수집 효과음 재생
    public void PlayStarCollect()
    {
        if (starCollect != null)
            audioSource.PlayOneShot(starCollect);
    }

    // 미트볼 피격 효과음 재생
    public void PlayMeatballHit()
    {
        if (meatballHit != null)
            audioSource.PlayOneShot(meatballHit);
    }
}
