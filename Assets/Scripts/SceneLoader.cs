using UnityEngine;
using UnityEngine.SceneManagement; //robimy coś ze sceną

public class SceneLoader : MonoBehaviour
{
    [Header("Scena Tawerny")] //bardziej estetycznie/organizacyjnie - warto dawać jeżeli jest więcej różnych serializefieldów
    [SerializeField] private Object scena; //przeciągniemy tu naszą scenę - zmienna będzie wybraną sceną

    public void LoadScene() //funkcja którą podepniemy pod On Click w buttonie
    {
        if (scena != null) //zabezpieczenie, na wypadek nieprzypisania żadnego obiektu kod nie pójdzie dalej
        {
            SceneManager.LoadScene(scena.name); //wczytanie sceny
        }
        else
        {
            Debug.LogError("Scena nieprzypisana!"); //poza nullcheckiem to gdyby nie było żadnej sceny error jeszcze nam to przypomni
        }
    }
}
