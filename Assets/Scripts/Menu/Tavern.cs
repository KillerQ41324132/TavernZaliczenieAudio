using UnityEngine;
using UnityEngine.UI;

public class Tavern : MonoBehaviour

{
    private FMOD.Studio.VCA vca;
    private Slider slider;

    [SerializeField] float vcaVolume;

    void Start()
    {
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/Tavern");
        vca.getVolume(out vcaVolume);
    }

    public void SetVolume(float volume)

    {
        vca.setVolume(volume);
    }
}