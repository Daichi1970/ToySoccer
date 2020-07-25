using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private AudioSource audioSource;

    public Text StartTimerText;
    public Text GameTimeText;
    public Text GameText;
    public GameObject second;
    public AudioClip audioClip1;

    float Interval = 3;

    static int InGameCount = 0;
    static int NotGameCount = 0;
    static float StartCount = 3;
    static float GameCount;
    static Quaternion SecondPos;
    static bool PlayOneShot = true;

    public static bool Game = false;

    void Start()
    {
        second.transform.rotation = SecondPos;
    }

    void Update()
    { 
        if (StartCount >= 0)
        {
            Game = false;
            NotGame();
        }
        else if (StartCount < 0)
        {
            Game = true;
            InGame();
        }
    }
    //試合中
    void InGame()
    {
        SecondPos = second.transform.rotation;
        second.transform.rotation = SecondPos;

        switch (InGameCount)
        {
            case 0:
                GameTimeText.text = "前半";
                break;
            case 1:
                StartCount = 3;
                break;
            case 2:
                GameTimeText.text = "後半";
                break;
            case 3:
                StartCount = 3;
                break;
        }
        if (GameCount > 45)
        {
            SecondPos = new Quaternion(0, 0, 0, 0);
            if (InGameCount <= 2)
                InGameCount++;
        }
        else
        {
            StartTimerText.text = "";
            GameCount += Time.deltaTime;
            second.transform.eulerAngles += new Vector3(0, Time.deltaTime * 6, 0);
        }
        //デバッグ用
        if (Input.GetKeyDown(KeyCode.Y))
        {
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
        }
    }
    //試合外
    void NotGame()
    {
        switch (NotGameCount)
        {
            case 0:
                GameText.text = "前半戦";
                StartTimerText.text = "";
                Interval -= Time.deltaTime;
                if (Interval <= 0)
                {
                    NextSwitch();
                }
                if (PlayOneShot)
                {
                    //サウンド再生
                    audioSource = gameObject.GetComponent<AudioSource>();
                    audioSource.clip = audioClip1;
                    audioSource.Play();
                    PlayOneShot = false;
                }
                break;
            case 1:
                GameCount = 0;
                StartCount -= Time.deltaTime;
                GameText.text = "";
                StartTimerText.text = StartCount.ToString("N0");
                break;
            case 2:
                //SecondPos = new Quaternion(0, 1, 0, 0);
                // 現在のScene名を取得する
                Scene loadScene = SceneManager.GetActiveScene();
                // Sceneの読み直し
                SceneManager.LoadScene(loadScene.name);
                NotGameCount++;
                break;
            case 3:
                GameText.text = "前半終了";
                StartTimerText.text = "";
                Interval -= Time.deltaTime;
                if (Interval <= 0)
                {
                    NextSwitch();
                }
                if (PlayOneShot)
                {
                    //サウンド再生
                    audioSource = gameObject.GetComponent<AudioSource>();
                    audioSource.clip = audioClip1;
                    audioSource.Play();
                    PlayOneShot = false;
                }
                break;
            case 4:
                GameText.text = "後半戦";
                Interval -= Time.deltaTime;
                if (Interval <= 0)
                {
                    NextSwitch();
                }
                break;
            case 5:
                GameCount = 0;
                StartCount -= Time.deltaTime;
                StartTimerText.text = StartCount.ToString("N0");
                GameText.text = "";
                break;
            case 6:
                GameText.text = "試合終了";
                StartTimerText.text = "";
                GameTimeText.text = "";
                Interval -= Time.deltaTime;
                if (Interval <= 0)
                {
                    NextSwitch();
                }
                if (PlayOneShot)
                {
                    //サウンド再生
                    audioSource = gameObject.GetComponent<AudioSource>();
                    audioSource.clip = audioClip1;
                    audioSource.Play();
                    PlayOneShot = false;
                }
                break;
            case 7:
                if (BallPos.GoalCount1 > BallPos.GoalCount2)
                {
                    GameText.text = "Player1 Win";
                }
                else if(BallPos.GoalCount1 < BallPos.GoalCount2)
                {
                    GameText.text = "Player2 Win";
                }
                else
                    GameText.text = "Drow";
                GameText.text += "\n"+ BallPos.GoalCount1 +"-" + BallPos.GoalCount2;
                break;
        }
        if (StartCount <= 0)
        {
            if (NotGameCount <= 6)
                NotGameCount++;
        }
    }
    void NextSwitch()
    {
        Interval = 3;
        PlayOneShot = true;
        NotGameCount++;
    }
}
