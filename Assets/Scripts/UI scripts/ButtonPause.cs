using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonPause : MonoBehaviour
{
    private bool isPaused = false;
    private bool isInInventory = false;

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
        if (Input.GetKeyDown(KeyCode.P) && isInInventory == false)
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.I) && isPaused == false)
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
            outInventory.SetActive(true);
            inInventory.SetActive(false);
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
