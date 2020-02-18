using UnityEngine;

public class PlayerAxeWooshSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] woosh_Sounds;

    private void PlayerWooshSound()
    {
        // Play a random woosh sound from the array et voilà.
        audioSource.clip = woosh_Sounds[Random.Range(0, woosh_Sounds.Length)];
        audioSource.Play();
    }

}