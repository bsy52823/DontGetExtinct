using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyDirector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
