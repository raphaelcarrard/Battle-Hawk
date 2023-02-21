using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{

    public static GameplayController instance;
    public GameObject player, statusTab, deployButton, upgradeButton, coinTab, upgradeMenuPanel, arrowIcon, gameOverPanel, pausePanel, cloud;
    public bool gameInProgress, startMoving;
    public Text warningText, coinText, currentCoinText, currentWeaponLevel, nextWeaponLevel, maxLevelText, activeWeaponLevelText, priceText, scoreText, gameOverCoinText;
    public int coins, price;
    public Animator upgrade;

    void Awake(){
        CreateInstance();
    }

    // Start is called before the first frame update
    void Start()
    {
       if(MusicController.instance != null && GameController.instance != null ){
            if(GameController.instance.isMusicOn){
                MusicController.instance.PlayGameplaySound();
            }else{
                MusicController.instance.StopAllSound();
            }
       } 
       InitializeGameplayVariables();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            PausePanel();
        }
    }

    void InitializeGameplayVariables(){
        if(GameController.instance != null){
            InitializeCoins();
            InitializeWeaponLevel();
            InitializeUpgradePrice();
        }
        InitializePlayer();
        statusTab.SetActive(true);
        deployButton.SetActive(true);
        upgradeButton.SetActive(true);
        coinTab.SetActive(false);
        gameOverPanel.SetActive(false);
        startMoving = false;
    }

    void InitializeCoins(){
        coins = 0;
        coinText.text = coins.ToString();
        currentCoinText.text = GameController.instance.coins.ToString("N0");
    }

    void InitializeWeaponLevel(){
        if(GameController.instance.weaponLevel != 5){
            currentWeaponLevel.text = "LVL " + GameController.instance.weaponLevel.ToString();
            int newLevel = GameController.instance.weaponLevel + 1;
            nextWeaponLevel.text = "LVL " + newLevel.ToString();
            maxLevelText.gameObject.SetActive(false);
            activeWeaponLevelText.text = GameController.instance.weaponLevel.ToString();
        }else{
            arrowIcon.SetActive(false);
            currentWeaponLevel.gameObject.SetActive(false);
            nextWeaponLevel.gameObject.SetActive(false);
            maxLevelText.gameObject.SetActive(true);
            activeWeaponLevelText.text = "MAX";
        }
    }

    void InitializeUpgradePrice(){
        if(GameController.instance.weaponLevel != 5){
            price = GetPrice(GameController.instance.weaponLevel);
            priceText.text = price.ToString();
        }else{
            priceText.transform.GetChild(0).gameObject.SetActive(false);
            priceText.text = "MAX";
        }
    }

    private int GetPrice(int level){
        int nextPrice = 0;

        switch(level){
            case 1:
                nextPrice = 500;
                break;
            case 2:
                nextPrice = 1200;
                break;
            case 3:
                nextPrice = 2500;
                break;
            case 4:
                nextPrice = 5000;
                break;
        }
        return nextPrice;
    }

    void InitializePlayer(){
        Instantiate(player, new Vector3(0, -3.5f, 0), Quaternion.identity);
    }

    void CreateInstance(){
        if(instance == null){
            instance = this;
        }
    }

    void ClearAllEnemies(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] bossbullets = GameObject.FindGameObjectsWithTag("BossBullet");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if(boss != null){
            Destroy(boss);
        }
        if(enemies != null){
            foreach(GameObject enemy in enemies){
                Destroy(enemy);
            }
        }
        if(bossbullets != null){
            foreach(GameObject bossBullet in bossbullets){
                Destroy(bossBullet);
            }
        }
        if(coins != null){
            foreach(GameObject coin in coins){
                Destroy(coin);
            }
        }
    }

    public void ShowWarning(){
        StartCoroutine(SpawnBossTime());
    }

    IEnumerator SpawnBossTime(){
        warningText.gameObject.SetActive(true);
        warningText.transform.GetComponent<WarningText>().PlayWarning();
        yield return new WaitForSeconds(5f);
        warningText.gameObject.SetActive(false);
        warningText.transform.GetComponent<WarningText>().StopWarning();
        GameObject.FindGameObjectWithTag("Spawner").transform.GetComponent<EnemySpawner>().SpawnBoss();
    }

    public void DeployButton(){
        statusTab.SetActive(false);
        deployButton.SetActive(false);
        upgradeButton.SetActive(false);
        coinTab.SetActive(true);
        Instantiate(cloud, new Vector3(0, 0, 0), Quaternion.identity);
        startMoving = true;
    }

    public void UpgradeButton(){
        upgradeMenuPanel.SetActive(true);
    }

    public void CloseButton(){
        upgradeMenuPanel.SetActive(false);
    }

    public void PurchaseUpgrade(){
        if(GameController.instance != null){
            if(GameController.instance.weaponLevel != 5){
                if(GameController.instance.coins >= price){
                    GameController.instance.coins -= price;
                    GameController.instance.weaponLevel += 1;
                    GameController.instance.Save();
                    InitializeCoins();
                    InitializeUpgradePrice();
                    InitializeWeaponLevel();
                }else{
                    upgrade.Play("Upgrade Button Anim");
                }
            }
        }
    }

    public void UpdateCoins(){
        coins += 1;
        coinText.text = coins.ToString();
    }

    public void GameOver(){
        gameOverPanel.SetActive(true);
        gameOverCoinText.text = coins.ToString("N0");
        scoreText.text = coins.ToString("N0");
        if(GameController.instance.coins != null){
            GameController.instance.coins += coins;
            GameController.instance.Save();
        }
    }

    public void RetryButton(){
        InitializeGameplayVariables();
        ClearAllEnemies();
        gameInProgress = false;
        GameObject.FindGameObjectWithTag("Spawner").transform.GetComponent<EnemySpawner>().active = false;
    }

    public void InitializeSpawners(){
        GameObject.FindGameObjectWithTag("Spawner").transform.GetComponent<EnemySpawner>().InitializeVariables();
        gameInProgress = true;
    }

    public void ResumeButton(){
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        gameInProgress = true;
    }

    public void QuitButton(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    void PausePanel(){
        if(gameInProgress && !pausePanel.activeInHierarchy){
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            gameInProgress = false;
        }else if(!gameInProgress && !pausePanel.activeInHierarchy){
            SceneManager.LoadScene("MainMenu");
        }
    }
}
