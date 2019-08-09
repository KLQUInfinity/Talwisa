using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UIMethods", menuName = "SO/UI", order = 0)]
public class UIMainMethods : ScriptableObject
{

    /// <summary>
    /// Exit the game
    /// </summary>
    public void QuitTheGame()
    {
        Application.Quit();
    }

    
}
