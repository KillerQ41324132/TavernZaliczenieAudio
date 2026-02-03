using System;
using UnityEngine;
using UnityEngine.UI;

public class VCAControlEasy : MonoBehaviour
{
    private FMOD.Studio.VCA vca;
    private Slider slider; 

    [Header("Ustawienia FMOD")] 
    [SerializeField] private string vcaPath; // np. vca:/Music - ściezka do wybranego VCA
    [Header("Zapisanie ustawień")] 
    [SerializeField] private string saveKey; // np. MusicVolume - pod tą nazwą zostaną zapisane dane ze slidera - ustawienia głosności

    private void Start()
    {
        slider = GetComponent<Slider>(); //automatycznie pobiera komponent slider z tego obiektu - skrypt wie którym sliderem sterować
        vca = FMODUnity.RuntimeManager.GetVCA(vcaPath); //nie wpisuję ściezki manualnie ze skryptu tylko z inspektora
        
        // Wczytujemy wartość zapisaną z saveKey, jeżeli jej nie ma to domyślnie 1f (100% głośności).
        float savedVolume = PlayerPrefs.GetFloat(saveKey, 1f); //saveKey to te dane do wczytania, po przecinku - 1f wczyta się kiedy te dane będa puste
        
        vca.setVolume(savedVolume); //ustawia poziom dźwięku na tą która była obliczona linijkę wyżej (albo z zapisanych danych - saveKey, albo domyślnie na 100% - 1f)
        slider.value = savedVolume; //ustawia slider na zapisaną wcześniej wartość
    }

    //Funkcja musi być publiczna żeby móc wybrać ją w inspektorze slidera w "on value changed" 
    public void SetVolume(float volume)
    {
        vca.setVolume(volume); 
        
        // Zapisujemy wartość (0-1) w zmiennej saveKey - pod nazwą jaką określiliśmy
        PlayerPrefs.SetFloat(saveKey, volume); 
    }
}