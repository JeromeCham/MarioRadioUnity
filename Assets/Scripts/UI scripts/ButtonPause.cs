using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPause : MonoBehaviour
{
    private bool isPaused = false;
    private bool isInInventory = false;
    private bool fixFonction = false;
    int count = 0;

    [SerializeField]
    private GameObject pauseMenuUI;

    [SerializeField]
    private GameObject inventoryMenuUI;

    [SerializeField]
    private GameObject outInventory;

    [SerializeField]
    private GameObject inInventory;

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
        if (isInInventory == false)
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
    }

    public void InventoryGame()
    {
        if (isPaused == false)
        {
            isInInventory = !isInInventory;

            if (isInInventory == true)
            {
                Time.timeScale = 0;
                AudioListener.pause = true;
                inventoryMenuUI.SetActive(true);
                outInventory.SetActive(false);
                inInventory.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                AudioListener.pause = false;
                inventoryMenuUI.SetActive(false);
                inInventory.SetActive(false);
                outInventory.SetActive(true);
            }
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
