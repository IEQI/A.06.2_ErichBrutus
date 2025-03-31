using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoverBackup : MonoBehaviour
{

    private MoveDir moveDir;
    public TextMeshProUGUI uiTextPro;
    public float moveDistance = 3f;
    public float moveSpeed = 4f;
    Vector3 currentLocation;
    //bool going = true;
    float goingComing = 1;

    void Start()
    {
        moveDir = GetComponent<MoveDir>();

        //StartCoroutine(MoveCoroutine(goingComing));
    }

    //IEnumerator MoveCoroutine (float dir)
    //{
        
    //}



    void Update()
    {
        // Second version of ping-pong
        //---------------------------

        float realSpeed = moveSpeed * Time.deltaTime;        
        currentLocation = gameObject.transform.position;

        //Debug.Log(currentLocation.x);
        //Debug.Log(moveDistance);

        if (goingComing == 1f)
        {
            gameObject.transform.Translate(goingComing * realSpeed, 0f * realSpeed, 0f * realSpeed);

            if (currentLocation.x >= moveDistance)
            {                
                goingComing = -1f;
            }
        }


        if (goingComing == -1f)
        {
            gameObject.transform.Translate(goingComing * realSpeed, 0f * realSpeed, 0f * realSpeed);

            if (currentLocation.x <= 0)
            {
                goingComing = 1f;
            }            
        }

        
        // FIRST VERSION OF PING-PONG
        //---------------------------

        //float modSpeed = moveSpeed * Time.deltaTime * goingComing;
        //gameObject.transform.Translate(1f * modSpeed, 0f * modSpeed, 0f * modSpeed);
        //currentLocation = gameObject.transform.position;

        //if (currentLocation.x >= moveDistance && going)
        //{
        //    goingComing = -1;
        //    going = false;
        //}


        //if (currentLocation.x <= 0 && !going)
        //{
        //    goingComing = 1;
        //    going = true;
        //}


    }

    public void MoveUp()
    {
        //Debug.Log("Up clicked");
        moveDir.dirValue = DirectionEnum.Up;
        uiTextPro.text = "U";
    }

    public void MoveDown()
    {
        moveDir.dirValue = DirectionEnum.Down;
        uiTextPro.text = "D";
    }

    public void MoveLeft()
    {
        moveDir.dirValue = DirectionEnum.Left;
        uiTextPro.text = "L";
    }

    public void MoveRight()
    {
        moveDir.dirValue = DirectionEnum.Right;
        uiTextPro.text = "R";
    }

}
