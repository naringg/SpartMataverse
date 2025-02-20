using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMusic : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (audioSource != null)
        {
            audioSource.Stop(); // Ω√¿€«“ ∂ß ¿Ωæ« ≤®µ“
        }
    }

    // Update is called once per frame
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // ¿Ωæ« ¡§¡ˆ
        }
    }
}
