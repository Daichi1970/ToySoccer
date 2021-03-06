﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keeper : MonoBehaviour
{
    private Vector3 pos;

    public GameObject Player;

    [SerializeField] float KeeperMove;
    [SerializeField] float KeeperPosX;

    float XInp;
    float XInp2;

    private void Start()
    {

    }

    private void Update()
    {
        //試合中
        if (GameManager.Game)
        {      
            XInp = Input.GetAxis("Horizontal1");
            XInp2 = Input.GetAxis("Horizontal2");
            //Xbox360コントローラー操作
            if (XInp > 0 && Player.name == ("Jammo_keeper"))
            {
                transform.Translate(KeeperMove, 0, 0);
            }
            if (XInp < 0 && Player.name == ("Jammo_keeper"))
            {
                transform.Translate(-KeeperMove, 0, 0);
            }

            if (XInp2 > 0 && Player.name == ("Jammo_keeper2"))
            {
                transform.Translate(KeeperMove, 0, 0);
            }
            if (XInp2 < 0 && Player.name == ("Jammo_keeper2"))
            {
                transform.Translate(KeeperMove, 0, 0);
            }

            //キーボード操作
            if (Input.GetKey(KeyCode.D) && Player.name == ("Jammo_keeper"))
            {
                transform.Translate(KeeperMove, 0, 0);
            }
            if (Input.GetKey(KeyCode.A) && Player.name == ("Jammo_keeper"))
            {
                transform.Translate(-KeeperMove, 0, 0);
            }

            if (Input.GetKey(KeyCode.L) && Player.name == ("Jammo_keeper2"))
            {
                transform.Translate(KeeperMove, 0, 0);
            }
            if (Input.GetKey(KeyCode.J) && Player.name == ("Jammo_keeper2"))
            {
                transform.Translate(-KeeperMove, 0, 0);
            }
            Clamp();
        }
    }
    //キーパーの移動できる範囲を制限する命令ブロック
    private void Clamp()
    {
        //キーパーの位置情報を「pos」という箱の中に入れる。
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -KeeperPosX, KeeperPosX);

        transform.position = pos;
    }
}
