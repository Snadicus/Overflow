using UnityEngine;

public class CallAction : MonoBehaviour
{
    [SerializeField] InputDetector inputDetector;
    [SerializeField] BasicFunctions basicFunctions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputDetector.OnInteract += StartGame;
    }

    void StartGame() 
    {
        basicFunctions.LoadScene(1);
    }
}
