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
    
    private GameObject mainMenu;

    public void Start()
    {
        
    }

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
            mainMenu = GameObject.FindGameObjectWithTag("Canvas");
            mainMenu.GetComponent<MainMenu>().accessLvl2();
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            mainMenu = GameObject.FindGameObjectWithTag("Canvas");
            mainMenu.GetComponent<MainMenu>().accessLvl3();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
