using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPause : MonoBehaviour
{
    private bool isPaused = false;
    
    [SerializeField]
    private GameObject pauseMenuUI;

    [SerializeField]
    private GameObject inventoryMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryGame();
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;

        if (isPaused == true)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            pauseMenuUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            pauseMenuUI.SetActive(false);
        }
    }

    public void InventoryGame()
    {
        isPaused = !isPaused;

        if (isPaused == true)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            inventoryMenuUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            inventoryMenuUI.SetActive(false);
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
