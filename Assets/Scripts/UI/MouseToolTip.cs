using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltipText;  // �ؽ�Ʈ UI

    private void Start()
    {
        if (tooltipText != null)
        {
            tooltipText.SetActive(false);  // �ؽ�Ʈ�� ������ �� �����
        }
    }

    // ���콺�� ��ư�� �ö��� �� ȣ��Ǵ� �Լ�
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tooltipText != null)
        {
            tooltipText.SetActive(true);  // �ؽ�Ʈ UI ���̱�
        }
    }

    // ���콺�� ��ư���� ������ �� ȣ��Ǵ� �Լ�
    public void OnPointerExit(PointerEventData eventData)
    {
        if (tooltipText != null)
        {
            tooltipText.SetActive(false);  // �ؽ�Ʈ UI �����
        }
    }
}
