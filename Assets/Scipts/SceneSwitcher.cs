using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
