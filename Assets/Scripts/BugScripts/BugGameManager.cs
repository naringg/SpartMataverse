using UnityEngine;
using TMPro;

public class BugGameManager : MonoBehaviour
{
    public TextMeshProUGUI bugScoreText;
    public TextMeshProUGUI bugTimeText;
    public GameObject bugPrefab;
    public Transform spawnArea;
    public GameObject gameOverPanel; // ���� ���� �� ǥ�õ� �г�
    public TextMeshProUGUI gameOverText; // ���� ���� �� ǥ�õ� �ؽ�Ʈ (����/����)
    public TextMeshProUGUI finalScoreText; // ���� ���� �ؽ�Ʈ
    public TextMeshProUGUI highScoreText; // �ְ� ���� �ؽ�Ʈ

    [SerializeField] int totalScore = 0;
    [SerializeField] float totalTime = 30.0f;
    private GameObject currentBug;
    private int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // �ְ� ���� �ҷ�����
        gameOverPanel.SetActive(false); // ���� ���� �� �г� ��Ȱ��ȭ
        SpawnBug(); // ó�� ���� ����
    }

    void Update()
    {
        if (totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
            bugTimeText.text = totalTime.ToString("N2");
        }
        else
        {
            if (totalTime <=0)
            {
                totalTime = 0; // �ð��� 0���� ����
                GameOver(); // ���� ���� ó��
                Debug.Log("GameOver");
            }
        }
    }

    void SpawnBug()
    {
        if (currentBug != null) Destroy(currentBug);

        // ī�޶� �� �ȿ��� ���� ��ġ ����
        Vector3 randomPos = GetRandomSpawnPosition();
        currentBug = Instantiate(bugPrefab, randomPos, Quaternion.identity);

        float randomScale = Random.Range(0.2f, 1.0f); // 0.5�迡�� 1�� ������ ũ��
        currentBug.transform.localScale = new Vector3(randomScale, randomScale, 1);

        float randomRotation = Random.Range(0f, 360f); // 0���� 360�� ������ ȸ�� ����
        currentBug.transform.rotation = Quaternion.Euler(0, 0, randomRotation);
    }

    Vector3 GetRandomSpawnPosition()
    {
        // ī�޶��� Viewport�� ���� ��ǥ�� ��ȯ�Ͽ� ������ ���� ����
        Camera mainCamera = Camera.main;
        float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        // ���� ��ġ ��ȯ
        return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
    }

    public void OnBugClicked()
    {
        // ���� �ð��� 0 ���϶�� ������ �ø��� �ʰ� ����
        if (totalTime <= 0.0f)
        {
            return;
        }

        totalScore += 1; // ���� ����
        bugScoreText.text = "Score: " + totalScore;
        SpawnBug(); // ���ο� ���� ����
    }

    void GameOver()
    {
        // ���� ���� UI Ȱ��ȭ
        gameOverPanel.SetActive(true);
        Debug.Log("Game Over Panel Ȱ��ȭ��");

        // ���� ���� �޽��� ���
        if (totalScore >= 40)
        {
            gameOverText.text = "Sucess!";
            Debug.Log("Sucess");
        }
        else
        {
            gameOverText.text = "Fail...";
            Debug.Log("Fail");
        }

        finalScoreText.text = "Score: " + totalScore; // ���� ���� ���

        // �ְ� ���� ����
        if (totalScore > highScore)
        {
            highScore = totalScore;
            PlayerPrefs.SetInt("HighScore", highScore); // ���ο� �ְ� ���� ����
        }

        highScoreText.text = "High Score: " + highScore; // �ְ� ���� ���
    }
}
