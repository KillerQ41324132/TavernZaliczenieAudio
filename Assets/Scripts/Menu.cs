using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour

{
    private FMOD.Studio.VCA vca;
    private Slider slider;

    [SerializeField] float vcaVolume;

    void Start()
    {
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/Music");
        vca.getVolume(out vcaVolume);
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/Mute");
        vca.getVolume(out vcaVolume);
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/Outside");
        vca.getVolume(out vcaVolume);
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/Tavern");
        vca.getVolume(out vcaVolume);
    }

    public void SetVolume(float volume)

    {
        vca.setVolume(volume);
    }
}
