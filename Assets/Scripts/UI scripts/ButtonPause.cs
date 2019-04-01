using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPause : MonoBehaviour
{
    private bool isPaused = false;
    private bool isInInventory = false;
    private bool isInShop = false;
    private int tempMoney = 0;

    public static ButtonPause instancePause;

    [SerializeField]
    private GameObject pauseMenuUI = null;

    [SerializeField]
    private GameObject inventoryMenuUI = null;

    [SerializeField]
    private GameObject outInventory = null;

    [SerializeField]
    private GameObject inInventory = null;

    [SerializeField]
    private GameObject shopMenuUI = null;

    [SerializeField]
    private PlayerMovement player = null;

    private void Awake()
    {
        if (instancePause != null)
        {
            return;
        }
        instancePause = this;
    }

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
        player = FindObjectOfType<PlayerMovement>();
        if (isInInventory == false && isInShop == false && player.IsDead == false)
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
        player = FindObjectOfType<PlayerMovement>();
        if (isPaused == false && isInShop == false && player.IsDead == false)
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

    public void ShopGame()
    {
        player = FindObjectOfType<PlayerMovement>();
        if (isPaused == false && isInInventory == false && player.IsDead == false)
        {
            isInShop = !isInShop;

            if (isInShop == true)
            {
                Time.timeScale = 0;
                AudioListener.pause = true;
                shopMenuUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                AudioListener.pause = false;
                shopMenuUI.SetActive(false);
            }
        }
    }

    public void AmmoPistolet()
    {
        tempMoney = Inventaire.instance.NbMoney();
        if (tempMoney >= 10)
        {
            Inventaire.instance.AddMagazinePistolet();
            Inventaire.instance.MoinsShop();
        }
    }

    public void AmmoMitraillette()
    {
        tempMoney = Inventaire.instance.NbMoney();
        if (tempMoney >= 10)
        {
            Inventaire.instance.AddMagazineMitraillette();
            Inventaire.instance.MoinsShop();
        }
    }

    public void AmmoBazooka()
    {
        tempMoney = Inventaire.instance.NbMoney();
        if (tempMoney >= 10)
        {
            Inventaire.instance.AddMagazineBazooka();
            Inventaire.instance.MoinsShop();
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
