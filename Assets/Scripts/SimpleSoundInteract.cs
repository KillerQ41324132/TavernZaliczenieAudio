using FMODUnity;
using UnityEngine;

public class SimpleSoundInteract : MonoBehaviour, IInteractable
{
    [Header("FMOD Settings")]
    [SerializeField] private EventReference interactSound;
    
    [Tooltip("Jeśli zaznaczone, dźwięk będzie podążał za obiektem (3D).")]
    [SerializeField] private bool attachToTransform = true;

    public void Interact()
    {
        PlaySound();
    }

    private void PlaySound()
    {
        if (interactSound.IsNull) return;

        if (attachToTransform)
        {
            // Dźwięk 3D przyczepiony do obiektu (np. beczki)
            RuntimeManager.PlayOneShotAttached(interactSound, gameObject);
        }
        else
        {
            // Dźwięk 2D lub 3D w stałym punkcie (bez śledzenia ruchu)
            RuntimeManager.PlayOneShot(interactSound, transform.position);
        }
    }
}