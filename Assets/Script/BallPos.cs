using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallPos : MonoBehaviour
{
    private Vector3 pos;
    static int GoalCount1;
    static int GoalCount2;
    public Text GoalCountText1;
    public Text GoalCountText2;
    private AudioSource audioSource;
    public AudioClip audioClip1;

    void Start()
    {
        GoalCountText1.text = GoalCount1.ToString();
        GoalCountText2.text = GoalCount2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
         Clamp();
    }
    // プレーヤーの移動できる範囲を制限する命令ブロック
    void Clamp()
    {
        // プレーヤーの位置情報を「pos」という箱の中に入れる。
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -1.2f, 1.2f);
        pos.z = Mathf.Clamp(pos.z, -5, 5f);

        transform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.Game)
        {
            if (collision.gameObject.name == ("BlueGoal"))
            {
                GoalCount1++;
                GoalCountText1.text = GoalCount1.ToString();
                // 現在のScene名を取得する
                Scene loadScene = SceneManager.GetActiveScene();
                // Sceneの読み直し
                SceneManager.LoadScene(loadScene.name);
            }
            if (collision.gameObject.name == ("RedGoal"))
            {
                GoalCount2++;
                GoalCountText2.text = GoalCount2.ToString();
                // 現在のScene名を取得する
                Scene loadScene = SceneManager.GetActiveScene();
                // Sceneの読み直し
                SceneManager.LoadScene(loadScene.name);
            }
        }
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        audioSource.Play();
    }
}
