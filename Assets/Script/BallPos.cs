using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallPos : MonoBehaviour
{
    private Vector3 pos;
    private AudioSource audioSource;

    public TextMesh GoalCountText1;
    public TextMesh GoalCountText2;
    public AudioClip audioClip1;

    public static int GoalCount1;
    public static int GoalCount2;
    bool clamp;

    void Start()
    {
        clamp = true;
        GoalCountText1.text = GoalCount1.ToString();
        GoalCountText2.text = GoalCount2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Game)
        {
            if (transform.position.z >= 3.3f && transform.position.x <= 0.7f && transform.position.x >= -0.7f)
            {
                GoalCount1++;
                GoalCountText1.text = GoalCount1.ToString();
                // 現在のScene名を取得する
                Scene loadScene = SceneManager.GetActiveScene();
                // Sceneの読み直し
                SceneManager.LoadScene(loadScene.name);
            }
            if (transform.position.z <= -3.3f && transform.position.x <= 0.7 && transform.position.x >= -0.7f)
            {
                GoalCount2++;
                GoalCountText2.text = GoalCount2.ToString();
                // 現在のScene名を取得する
                Scene loadScene = SceneManager.GetActiveScene();
                // Sceneの読み直し
                SceneManager.LoadScene(loadScene.name);
            }
        }
            if (clamp)
            Clamp();
    }
    // ボールの移動できる範囲を制限する命令ブロック
    void Clamp()
    {
        // ボールの位置情報を「pos」という箱の中に入れる。
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -1.1f, 1.1f);
        pos.z = Mathf.Clamp(pos.z, -3, 3f);

        transform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //サウンド再生
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        audioSource.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        //ボールの移動できる範囲を制限を外す
        if (other.gameObject.name == "Goal")
        {
            clamp = false;
        }
    }
}
