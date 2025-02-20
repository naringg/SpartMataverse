using UnityEngine;
using TMPro;

public class BugGameManager : MonoBehaviour
{
    public TextMeshProUGUI bugScoreText;
    public TextMeshProUGUI bugTimeText;
    public GameObject bugPrefab;
    public Transform spawnArea;
    public GameObject gameOverPanel; // 게임 종료 후 표시될 패널
    public TextMeshProUGUI gameOverText; // 게임 종료 후 표시될 텍스트 (성공/실패)
    public TextMeshProUGUI finalScoreText; // 최종 점수 텍스트
    public TextMeshProUGUI highScoreText; // 최고 점수 텍스트

    [SerializeField] int totalScore = 0;
    [SerializeField] float totalTime = 30.0f;
    private GameObject currentBug;
    private int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // 최고 점수 불러오기
        gameOverPanel.SetActive(false); // 게임 시작 시 패널 비활성화
        SpawnBug(); // 처음 벌레 생성
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
                totalTime = 0; // 시간을 0으로 설정
                GameOver(); // 게임 오버 처리
                Debug.Log("GameOver");
            }
        }
    }

    void SpawnBug()
    {
        if (currentBug != null) Destroy(currentBug);

        // 카메라 뷰 안에서 랜덤 위치 생성
        Vector3 randomPos = GetRandomSpawnPosition();
        currentBug = Instantiate(bugPrefab, randomPos, Quaternion.identity);

        float randomScale = Random.Range(0.2f, 1.0f); // 0.5배에서 1배 사이의 크기
        currentBug.transform.localScale = new Vector3(randomScale, randomScale, 1);

        float randomRotation = Random.Range(0f, 360f); // 0에서 360도 사이의 회전 각도
        currentBug.transform.rotation = Quaternion.Euler(0, 0, randomRotation);
    }

    Vector3 GetRandomSpawnPosition()
    {
        // 카메라의 Viewport를 월드 좌표로 변환하여 생성할 범위 설정
        Camera mainCamera = Camera.main;
        float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        // 랜덤 위치 반환
        return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
    }

    public void OnBugClicked()
    {
        // 만약 시간이 0 이하라면 점수를 올리지 않고 종료
        if (totalTime <= 0.0f)
        {
            return;
        }

        totalScore += 1; // 점수 증가
        bugScoreText.text = "Score: " + totalScore;
        SpawnBug(); // 새로운 벌레 생성
    }

    void GameOver()
    {
        // 게임 종료 UI 활성화
        gameOverPanel.SetActive(true);
        Debug.Log("Game Over Panel 활성화됨");

        // 게임 종료 메시지 출력
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

        finalScoreText.text = "Score: " + totalScore; // 최종 점수 출력

        // 최고 점수 갱신
        if (totalScore > highScore)
        {
            highScore = totalScore;
            PlayerPrefs.SetInt("HighScore", highScore); // 새로운 최고 점수 저장
        }

        highScoreText.text = "High Score: " + highScore; // 최고 점수 출력
    }
}
