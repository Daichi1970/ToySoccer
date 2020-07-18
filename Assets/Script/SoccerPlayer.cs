using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayer : MonoBehaviour
{
    private float StopCoroutine = 0;
    bool Player1RightOn;
    bool Player1LeftOn;
    bool Player2RightOn;
    bool Player2LeftOn;

    void Start()
    {
        Player1RightOn = false;
        Player1LeftOn = false;
        Player2RightOn = false;
        Player2LeftOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ButtonA1")&& gameObject.tag == ("SoccerPlayer"))
        {
            //Playerを左回転を強制的に止める
            Player1LeftOn = false;

            if (Player1RightOn == false)
            {
                StopCoroutine = 0;
                Player1RightOn = true;
            }
        }
        if (Input.GetButtonDown("ButtonB1")&& gameObject.tag == ("SoccerPlayer"))
        {
            //Playerを右回転を強制的に止める
            Player1RightOn = false;

            if (Player1LeftOn == false)
            {
                StopCoroutine = 0;
                Player1LeftOn = true;
            }
        }
        if (Input.GetButtonDown("ButtonA2") && gameObject.tag == ("SoccerPlayer2"))
        {
            //Playerを左回転を強制的に止める
            Player2LeftOn = false;

            if (Player2RightOn == false)
            {
                StopCoroutine = 0;
                Player2RightOn = true;
            }
        }
        if (Input.GetButtonDown("ButtonB2") && gameObject.tag == ("SoccerPlayer2"))
        {
            //Playerを右回転を強制的に止める
            Player2RightOn = false;

            if (Player2LeftOn == false)
            {
                StopCoroutine = 0;
                Player2LeftOn = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && gameObject.tag == ("SoccerPlayer"))
        {
            //Playerを左回転を強制的に止める
            Player1LeftOn = false;

            if (Player1RightOn == false)
            {
                StopCoroutine = 0;
                Player1RightOn = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && gameObject.tag == ("SoccerPlayer"))
        {
            //Playerを右回転を強制的に止める
            Player1RightOn = false;

            if (Player1LeftOn == false)
            {
                StopCoroutine = 0;
                Player1LeftOn = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.O) && gameObject.tag == ("SoccerPlayer2"))
        {
            //Playerを左回転を強制的に止める
            Player2LeftOn = false;

            if (Player2RightOn == false)
            {
                StopCoroutine = 0;
                Player2RightOn = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.U) && gameObject.tag == ("SoccerPlayer2"))
        {
            //Playerを右回転を強制的に止める
            Player2RightOn = false;

            if (Player2LeftOn == false)
            {
                StopCoroutine = 0;
                Player2LeftOn = true;
            }
        }
        if (Player1RightOn)
        {
            RightTurn();
        }
        if (Player1LeftOn)
        {
            LeftTurn();
        }

        if (Player2RightOn)
        {
            RightTurn();
        }
        if (Player2LeftOn)
        {
            LeftTurn();
        }
    }
    void RightTurn()
    {
        if (gameObject.tag == ("SoccerPlayer"))
        {
            StopCoroutine += Time.deltaTime;
            transform.Rotate(0, 360 / 0.2f * Time.deltaTime, 0);
            if (StopCoroutine > 0.2f)
            {
                Player1RightOn = false;
            }
        }
        if (gameObject.tag == ("SoccerPlayer2"))
        {
            StopCoroutine += Time.deltaTime;
            transform.Rotate(0, 360 / 0.2f * Time.deltaTime, 0);
            if (StopCoroutine > 0.2f)
            {
                Player2RightOn = false;
            }
        }
    }
    void LeftTurn()
    {
        if (gameObject.tag == ("SoccerPlayer"))
        {
            StopCoroutine += Time.deltaTime;
            transform.Rotate(0, -360 / 0.2f * Time.deltaTime, 0);
            if (StopCoroutine > 0.2f)
            {
                Player1LeftOn = false;
            }
        }
        if (gameObject.tag == ("SoccerPlayer2"))
        {
            StopCoroutine += Time.deltaTime;
            transform.Rotate(0, -360 / 0.2f * Time.deltaTime, 0);
            if (StopCoroutine > 0.2f)
            {
                Player2LeftOn = false;
            }
        }
    }
}