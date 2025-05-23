using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject comics;

    public void PlayGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void ShowComics() 
    {
        comics.SetActive(true);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
