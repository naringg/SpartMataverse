using UnityEngine;
using UnityEngine.UI;

public class NPCUIButton : MonoBehaviour
{
    public GameObject MiniGameButton;
    public AudioSource audioSource;

    private void Start()
    {
        if (MiniGameButton != null)
        {
            MiniGameButton.SetActive(false); 
        }
        if (audioSource != null)
        {
            audioSource.Stop(); // Ω√¿€«“ ∂ß ¿Ωæ« ≤®µ“
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            MiniGameButton.SetActive(true);
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play(); 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            MiniGameButton.SetActive(false);
        }
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // ¿Ωæ« ¡§¡ˆ
        }
    }
}
