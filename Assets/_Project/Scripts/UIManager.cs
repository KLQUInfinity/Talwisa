using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider LoadingSlider;

    /// <summary>
    /// Exit the game
    /// </summary>
    public void QuitTheGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Load the MainMenu Scene
    /// </summary>
    public void BackToMainMenu()
    {
        StartCoroutine(LoadAsynchronously("MainMenu"));
    }

    /// <summary>
    /// Restart the current Scene
    /// </summary>
    public void RestartLevel()
    {
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().name));
    }

    /// <summary>
    /// Moving from scene to another
    /// </summary>
    /// <param name="scencName">name of the scene you will go to</param>
    public void LoadLevel(string scencName)
    {
        StartCoroutine(LoadAsynchronously(scencName));
    }

    private IEnumerator LoadAsynchronously(string scencName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scencName);
        while (!operation.isDone)
        {
            LoadingSlider.value = operation.progress;

            yield return null;
        }
    }
}
