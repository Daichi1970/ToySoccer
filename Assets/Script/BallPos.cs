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

    [SerializeField] float GoalinPosZ;
    [SerializeField] float GoalinPosX;
    [SerializeField] float ClampPosX;
    [SerializeField] float ClampPosZ;

    public static int GoalCount1;
    public static int GoalCount2;
    public bool clamp;

    private void Start()
    {
        clamp = true;
        GoalCountText1.text = GoalCount1.ToString();
        GoalCountText2.text = GoalCount2.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        //試合中
        if (GameManager.Game)
        {
            //ゴール判定 上
            if (transform.position.z >= GoalinPosZ && transform.position.x <= GoalinPosX && transform.position.x >= -GoalinPosX)
            {
                GoalCount1++;
                GoalCountText1.text = GoalCount1.ToString();
                // 現在のScene名を取得する
                Scene loadScene = SceneManager.GetActiveScene();
                // Sceneの読み直し
                SceneManager.LoadScene(loadScene.name);
            }
            
            //ゴール判定 下
            if (transform.position.z <= -GoalinPosZ && transform.position.x <= GoalinPosX && transform.position.x >= -GoalinPosX)
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
    private void Clamp()
    {
        // ボールの位置情報を「pos」という箱の中に入れる。
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -ClampPosX, ClampPosX);
        pos.z = Mathf.Clamp(pos.z, -ClampPosZ, ClampPosZ);

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
