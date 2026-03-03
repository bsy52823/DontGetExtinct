using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource 컴포넌트
    public AudioClip bgmClip;       // 재생할 BGM 클립

    void Start()
    {
        audioSource.clip = bgmClip;
        audioSource.loop = true;    // 반복 재생 설정
        audioSource.Play();         // 재색 시작
    }
}
