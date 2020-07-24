using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallPos : MonoBehaviour
{
    private Vector3 pos;
    private Vector3 newVector;
    static int GoalCount1;
    static int GoalCount2;
    public TextMesh GoalCountText1;
    public TextMesh GoalCountText2;
    private AudioSource audioSource;
    public AudioClip audioClip1;
    bool clamp = true;

    void Start()
    {
        GoalCountText1.text = GoalCount1.ToString();
        GoalCountText2.text = GoalCount2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(clamp);
        if (transform.position.z >= 3.3f && transform.position.x <= 0.6f && transform.position.x >= -0.6f)
        {
            GoalCount1++;
            GoalCountText1.text = GoalCount1.ToString();
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
        }
        if (transform.position.z <= -3.3f && transform.position.x <= 0.6 && transform.position.x >= -0.6f)
        {
            GoalCount2++;
            GoalCountText2.text = GoalCount2.ToString();
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
        }
        if(clamp)
            Clamp();
    }
    // プレーヤーの移動できる範囲を制限する命令ブロック
    void Clamp()
    {
        // プレーヤーの位置情報を「pos」という箱の中に入れる。
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -1.2f, 1.2f);
        pos.z = Mathf.Clamp(pos.z, -3, 3f);

        transform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        audioSource.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Goal")
        {
            clamp = false;
        }
    }
}
