using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    #region var
    public static bool gameIsRunning;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject endScreen;
    [SerializeField] Text scoreText;
    [SerializeField] Text coinText;
    [SerializeField] Text killScoreText;
    [SerializeField] InputField playerSpeed;
    [SerializeField] InputField playerFireRate;

    static int hightScore;
    static int coinCount;
    int currntScore;
    int click;
    int killScore;
    PlayerCentroller player;

    #endregion
    private void Awake() {        
        gameIsRunning=true;
    }
    private void Start() {
        menuPanel.SetActive(false);
        click=0;
        currntScore=0;
        killScore=0;
        scoreText.text="0";
        killScoreText.text="0";
        coinText.text=coinCount+" coins";
        player=FindObjectOfType<PlayerCentroller>();
    }
    private void Update() {
        
        if(!gameIsRunning) {
            Time.timeScale=0;
            if(currntScore>hightScore) {
                hightScore=currntScore;
                Debug.Log("new hight Score");
            }
            endScreen.SetActive(!gameIsRunning);
        }
        else {
            Time.timeScale=1;
            endScreen.SetActive(!gameIsRunning);
        }
    }
    #region buttens
    public void Reset() {

        SceneManager.LoadScene(0);
    }
    public void Exit() {
        Application.Quit();
    }
    public void openMenu() {
        click++;
        if(click==3)
            menuPanel.SetActive(true);
    }
    public void closeMenu() { 
        menuPanel.SetActive(false); 
    }
    public void addScore(int amunt) {
        currntScore+=amunt;
        scoreText.text=currntScore+"";
    }
    public void addCoin (int amunt){
        coinCount+=amunt;
        coinText.text=coinCount+" coins";
    }
    public void addKill() {
        killScore++;
        killScoreText.text=killScore+" kills";
    }
    public void saveTextChange() {
        float PS,PFR;
        float.TryParse(playerSpeed.text, out PS);
        float.TryParse(playerFireRate.text, out PFR);
        player.changePorams(PS,PFR);
    }
    public void resetChange() {
        player.resetPlayerPorams();
    }
    #endregion
}
