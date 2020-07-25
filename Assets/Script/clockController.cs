using System;   // DateTimeに必要
using System.Collections;
using UnityEngine;

public class clockController : MonoBehaviour
{

    public bool sec;   // 秒針の有無
    public bool secTick;   // 秒針を秒ごとに動かすか

    public GameObject second;

    void Start()
    {
        if (!sec)
            Destroy(second); // 秒針を消す
    }

    void Update()
    {
        if (sec)
        {
            if (secTick)
                second.transform.eulerAngles += new Vector3(0, 0, -Time.deltaTime);
        }

    }
}