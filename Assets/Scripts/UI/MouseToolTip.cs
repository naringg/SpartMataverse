using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltipText;  // 텍스트 UI

    private void Start()
    {
        if (tooltipText != null)
        {
            tooltipText.SetActive(false);  // 텍스트는 시작할 때 숨기기
        }
    }

    // 마우스가 버튼에 올라갔을 때 호출되는 함수
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tooltipText != null)
        {
            tooltipText.SetActive(true);  // 텍스트 UI 보이기
        }
    }

    // 마우스가 버튼에서 나갔을 때 호출되는 함수
    public void OnPointerExit(PointerEventData eventData)
    {
        if (tooltipText != null)
        {
            tooltipText.SetActive(false);  // 텍스트 UI 숨기기
        }
    }
}
