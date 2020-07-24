using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text StartTimerText;
    public TextMesh GameTimerText;
    public Text GameText;
    public float GameTime;
    static int Count = 1;
    static float StartCount = 4;
    static float GameCount;
    public static bool Game = false;

    void Start()
    {

    }

    void Update()
    {
        Debug.Log(Count);
        if (StartCount >= 0)
        {
            NotGame();
        }
        else if (StartCount < 0)
        {
            InGame();
        }
    }
    void InGame()
    {
        switch (Count)
        {
            case 1:
                Debug.Log("前半");
                GameText.text = "前半";
                Game = true;
                break;
            case 2:
                Debug.Log("前半終了");
                // 現在のScene名を取得する
                Scene loadScene = SceneManager.GetActiveScene();
                // Sceneの読み直し
                SceneManager.LoadScene(loadScene.name);
                StartCount = 3;
                StartTimerText.text = "前半終了";
                Game = false;
                break;
            case 3:
                Debug.Log("後半");
                GameText.text = "後半";
                Game = true;
                break;
            case 4:
                Debug.Log("試合終了");
                // 現在のScene名を取得する
                loadScene = SceneManager.GetActiveScene();
                // Sceneの読み直し
                SceneManager.LoadScene(loadScene.name);
                Game = false;
                StartTimerText.text = "試合終了";
                break;
        }
        if (GameCount > 45)
        {
            if (Count <= 3)
                Count++;
        }
       else
        {
            StartTimerText.text = "";
            GameCount += Time.deltaTime;
            GameTimerText.text = GameCount.ToString("N0");
        }
    }
    void NotGame()
    {
        GameCount = 0;
        StartCount -= Time.deltaTime;
        StartTimerText.text = StartCount.ToString("N0");
    }
}
