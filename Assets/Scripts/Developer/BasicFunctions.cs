using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicFunctions : MonoBehaviour
{
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
