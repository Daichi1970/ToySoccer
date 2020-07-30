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
    public GameObject Red;
    public GameObject Blue;
    public AudioClip audioClip1;
    public float IntervalTime;
    public float StartTime;
    public float MatchTime;

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
        //赤色 紙ふぶき
        Red.SetActive(false);

        //青色 紙ふぶき
        Blue.SetActive(false);

        //保持されているQuaternion代入
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

        //試合進行
        switch (InGameCount)
        {
            case 0:
                GameTimeText.text = "前半";
                break;
            case 1:
                StartCount = StartTime;
                break;
            case 2:
                GameTimeText.text = "後半";
                break;
            case 3:
                StartCount = StartTime;
                break;
        }

        //試合時間
        if (GameCount > MatchTime)
        {
            SecondPos = new Quaternion(0, 0, 0, 0);
            if (InGameCount <= InGameCount-1)
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
        //試合外進行
        switch (NotGameCount)
        {
            //前半戦開始通知
            case 0:
                GameText.text = "前半戦";
                StartTimerText.text = "";
                Interval -= Time.deltaTime;
                if (Interval <= IntervalTime)
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
            //前半戦開始カウントダウン
            case 1:
                GameCount = 0;
                StartCount -= Time.deltaTime;
                GameText.text = "";
                StartTimerText.text = StartCount.ToString("N0");
                break;
            //前半終了
            case 2:
                // 現在のScene名を取得する
                Scene loadScene = SceneManager.GetActiveScene();
                // Sceneの読み直し
                SceneManager.LoadScene(loadScene.name);
                NotGameCount++;
                break;
            //前半終了通知
            case 3:
                GameText.text = "前半終了";
                StartTimerText.text = "";
                Interval -= Time.deltaTime;
                if (Interval <= IntervalTime)
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
            //後半戦開始通知
            case 4:
                GameText.text = "後半戦";
                Interval -= Time.deltaTime;
                if (Interval <= IntervalTime)
                {
                    NextSwitch();
                }
                break;
            //後半戦開始カウントダウン
            case 5:
                GameCount = 0;
                StartCount -= Time.deltaTime;
                StartTimerText.text = StartCount.ToString("N0");
                GameText.text = "";
                break;
            //後半戦終了通知
            case 6:
                GameText.text = "試合終了";
                StartTimerText.text = "";
                GameTimeText.text = "";
                Interval -= Time.deltaTime;
                if (Interval <= IntervalTime)
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
            //勝敗
            case 7:
                if (BallPos.GoalCount1 > BallPos.GoalCount2)
                {
                    GameText.text = "Player1 Win";
                    Red.SetActive(true);
                }
                else if (BallPos.GoalCount1 < BallPos.GoalCount2)
                {
                    GameText.text = "Player2 Win";
                    Blue.SetActive(true);
                }
                else
                {
                    GameText.text = "Drow";
                    Red.SetActive(true);
                    Blue.SetActive(true);
                }
                GameText.text += "\n"+ BallPos.GoalCount1 +"-" + BallPos.GoalCount2;
                break;
        }

        //試合外時間
        if (StartCount <= IntervalTime)
        {
            if (NotGameCount <= NotGameCount-1)
                NotGameCount++;
        }
    }
    //一回サウンドを再生かつ次のswitch caseへ
    void NextSwitch()
    {
        Interval = 3;
        PlayOneShot = true;
        NotGameCount++;
    }
}
