using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public string sceneName = "FlappyPlane"; // ��ȯ�� �� �̸�

    private void Start()
    {
        // ��ư ������Ʈ ��������
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(LoadNewScene);
        }
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
