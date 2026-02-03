using FMODUnity;
using UnityEngine;

public class FireplaceInteract : MonoBehaviour, IInteractable
{
    [Header("Ognisko")]
    [SerializeField] private GameObject targetObject; // Tu przeciągamy ognisko/particle

    [Header("Dźwięki")] 
    [SerializeField] private EventReference fireplaceStart;
    [SerializeField] private EventReference fireplaceStop;
    
    [Header("Stan")]
    [SerializeField] private bool isActive = true;
    public void Interact()
    {
        isActive = !isActive; // Odwrócenie stanu / przełączanie wł/wył

        if (targetObject != null)
        {
            targetObject.SetActive(isActive);
            PlayInteractSound(); //odtworzenie odpowiedniego dźwięku
        }
    }

    private void PlayInteractSound()
    {
        if (isActive)
        {
            RuntimeManager.PlayOneShot(fireplaceStart);
            //RuntimeManager.PlayOneShotAttached(fireplaceStart, targetObject); //zapalenie ogniska w miejscu ogniska (3D)
        }
        else
        {   RuntimeManager.PlayOneShot(fireplaceStop);
            //RuntimeManager.PlayOneShotAttached(fireplaceStop, targetObject); //zgaszenie ogniska w miejscu gdzie było (3D)
        }
    }
}
