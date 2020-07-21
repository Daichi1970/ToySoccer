using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaerMove : MonoBehaviour
{
    private Vector3 pos;
    public float posUp;
    public float posDown;
    public float moveSpeed;
    float YInp;
    float YInp2;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Game)
        {
            YInp = Input.GetAxis("Vertical1");
            YInp2 = Input.GetAxis("Vertical2");
            if (YInp > 0 && gameObject.tag == ("SoccerPlayer"))
            {
                transform.Translate(0, 0, moveSpeed);
            }
            if (YInp < 0 && gameObject.tag == ("SoccerPlayer"))
            {
                transform.Translate(0, 0, -moveSpeed);
            }
            if (YInp2 < 0 && gameObject.tag == ("SoccerPlayer2"))
            {
                transform.Translate(0, 0, -moveSpeed);
            }
            if (YInp2 > 0 && gameObject.tag == ("SoccerPlayer2"))
            {
                transform.Translate(0, 0, moveSpeed);
            }

            if (Input.GetKey(KeyCode.W) && gameObject.tag == ("SoccerPlayer"))
            {
                transform.Translate(0, 0, moveSpeed);
            }
            if (Input.GetKey(KeyCode.S) && gameObject.tag == ("SoccerPlayer"))
            {
                transform.Translate(0, 0, -moveSpeed);
            }
            if (Input.GetKey(KeyCode.I) && gameObject.tag == ("SoccerPlayer2"))
            {
                transform.Translate(0, 0, moveSpeed);
            }
            if (Input.GetKey(KeyCode.K) && gameObject.tag == ("SoccerPlayer2"))
            {
                transform.Translate(0, 0, -moveSpeed);
            }
            Clamp();
        }
    }
    void Clamp()
    {
        // プレーヤーの位置情報を「pos」という箱の中に入れる。
        pos = transform.position;

        pos.z = Mathf.Clamp(pos.z, posDown, posUp);

        transform.position = pos;
    }
}
