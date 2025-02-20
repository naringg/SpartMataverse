using UnityEngine;

public class Bug : MonoBehaviour
{
    private BugGameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<BugGameManager>(); // 게임 매니저 찾기
    }

    void OnMouseDown()
    { 
        gameManager.OnBugClicked();
        Destroy(gameObject); // 벌레 삭제
    }
}
