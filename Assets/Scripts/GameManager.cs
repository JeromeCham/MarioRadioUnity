using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;

    [SerializeField]
    private float restartDelay = 0f;

    [SerializeField]
    private GameObject text = null;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            text.SetActive(true);
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            MainMenu.lvlControl.Lvl2Done = true;
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            MainMenu.lvlControl.Lvl3Done = true;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
