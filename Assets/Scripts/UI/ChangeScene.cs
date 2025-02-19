using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public string sceneName = ""; // 전환할 씬 이름

    private void Start()
    {
        // 버튼 컴포넌트 가져오기
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
