using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour

{
    private FMOD.Studio.VCA vca;
    private Slider slider;

    [Header("Ustawienia FMOD")]
    [SerializeField] private string vcaPath; //np. vca:/Music
    [SerializeField] private string saveKey; //np. MusicVolume - pod t¹ nazw¹ zostana zapisane dane ze slidera

    [Header("Poziom G³oœnoœci")]
    [SerializeField] private float vcaVolume;

    void Start()
    {
        slider = GetComponent<Slider>();
        vca = FMODUnity.RuntimeManager.GetVCA(vcaPath);

        float savedVolume = PlayerPrefs.GetFloat(saveKey, defaultValue:1);

        vca.getVolume(out vcaVolume);
        slider.value = savedVolume;
    }

    public void SetVolume(float volume)

    {
        vca.setVolume(volume);

        PlayerPrefs.SetFloat(saveKey, volume);
    }
}
