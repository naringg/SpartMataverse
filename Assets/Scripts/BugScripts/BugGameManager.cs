using UnityEngine;
using TMPro;

public class BugGameManager : MonoBehaviour
{
    public TextMeshProUGUI bugScoreText;
    public TextMeshProUGUI bugTimeText;
    public GameObject bugPrefab;
    public Transform spawnArea;  // spawnArea를 

    private int totalScore = 0;
    private float totalTime = 30.0f;
    private GameObject currentBug;

    void Start()
    {
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
            Time.timeScale = 0.0f;
            totalTime = 0.0f;
        }
    }

    void SpawnBug()
    {
        if (currentBug != null) Destroy(currentBug); //벌레가 있다면 벌레를 지움

        Vector3 randomPos = GetRandomSpawnPosition();
        currentBug = Instantiate(bugPrefab, randomPos, Quaternion.identity);
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
        if (totalTime <= 0.0f)
        {
            return;
        }
        int plusScore = 1;
        totalScore += plusScore;
        bugScoreText.text = "Score: " + totalScore;
        SpawnBug(); // 새로운 벌레 생성
        
    }
}
