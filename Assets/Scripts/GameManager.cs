using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public bool gameStarted;

    public GameObject platformSpawner;
    public Text highScoreText;
    public Text scoreText;
    public GameObject gamePlayUI;
    public GameObject menuUI;
    int score = 0;
    int highScore;

    int adCounter =0;

    AudioSource audioSource;
    public AudioClip[] gameMusic;
   

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = highScore + "";

        CheckAdCount();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }        
    }


    public void GameStart()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);
        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        audioSource.clip = gameMusic[1];
        audioSource.Play();
        StartCoroutine("UpdateScore");
    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");
        SaveHighScore();
        //show ads
        // AdsManager.instance.ShowAds();
        if (adCounter > 3){
            
            adCounter=0;
            PlayerPrefs.SetInt("AdCount",adCounter);

            audioSource.Stop();
            
            AdsManager.instance.ShowRewardedAds();
        }else{
            Invoke("ReloadLevel", 0.5f);
        }   
        // Invoke("ReloadLevel", 0.5f);
    }



    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void IncrimentScore()
    {
        score += 10;
        scoreText.text = score.ToString();
        audioSource.PlayOneShot(gameMusic[2],2f);
    }

    void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    void CheckAdCount(){
        if(PlayerPrefs.HasKey("AdCount")){
            adCounter=PlayerPrefs.GetInt("AdCount");
            adCounter++;
            PlayerPrefs.SetInt("AdCount",adCounter);
            
        }else{
            PlayerPrefs.SetInt("AdCount",0);
        }
    }

}
