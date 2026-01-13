using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour

{
    private FMOD.Studio.VCA vca;
    private Slider slider;

    [SerializeField] float vcaVolume;

    void Start()
    {
        vca = FMODUnity.RuntimeManager.GetVCA("vca:/Mute");
        vca.getVolume(out vcaVolume);
    }

    public void SetVolume(float volume)

    {
        vca.setVolume(volume);
    }
}
