using UnityEngine;

public class Bug : MonoBehaviour
{
    private BugGameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<BugGameManager>(); // ���� �Ŵ��� ã��
    }

    void OnMouseDown()
    { 
        gameManager.OnBugClicked();
        Destroy(gameObject); // ���� ����
    }
}
