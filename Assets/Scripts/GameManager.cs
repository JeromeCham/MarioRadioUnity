using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;

    [SerializeField]
    private float restartDelay = 0f;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    public void EndLevel()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Niveau terminé");
            Invoke("Restart", restartDelay);
        }
    }

    public  void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
