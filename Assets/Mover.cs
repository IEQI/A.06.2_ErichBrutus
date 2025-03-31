using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Mover : MonoBehaviour
{

    private MoveDir moveDir;
    public TextMeshProUGUI uiTextPro;
    public float moveDistance = 3f;
    public float moveSpeed = 4f;
    Vector3 currentLocation;
    Vector3 activeDirVector;

    bool going = true;
    bool loopComp = false;

    void Start()
    {
        moveDir = GetComponent<MoveDir>();        
        moveDir.dirValue = DirectionEnum.Right; // init right from start

        activeDirVector = moveDir.GetVectors(moveDir.dirValue);
        StartCoroutine(MoveCoroutine(activeDirVector));        
        //||
    }

    IEnumerator MoveCoroutine(Vector3 dir)
    {
        while (!loopComp)
        {
            float realSpeed = moveSpeed * Time.deltaTime;
            currentLocation = gameObject.transform.position;
            Vector3 moveDest = dir * moveDistance;

            if (going)
            {
                gameObject.transform.Translate(dir * realSpeed);
                if (currentLocation.magnitude >= moveDest.magnitude)
                {
                    going = false;
                }
            }

            if (!going)
            {
                gameObject.transform.Translate(dir * -1 * realSpeed);

                if (Vector3.Distance(currentLocation, moveDest) >= 3)
                {
                    loopComp = true;
                }
            }
            yield return null;
        }

        loopComp = false;
        going = true;
        StartCoroutine(MoveCoroutine(activeDirVector));
        //Debug.Log("Coroutine restarted");
    }

    public void MoveUp()
    {
        moveDir.dirValue = DirectionEnum.Up;
        activeDirVector = moveDir.GetVectors(moveDir.dirValue);
        uiTextPro.text = "U";
    }

    public void MoveDown()
    {
        moveDir.dirValue = DirectionEnum.Down;
        activeDirVector = moveDir.GetVectors(moveDir.dirValue);
        uiTextPro.text = "D";
    }

    public void MoveLeft()
    {
        moveDir.dirValue = DirectionEnum.Left;
        activeDirVector = moveDir.GetVectors(moveDir.dirValue);
        uiTextPro.text = "L";
    }

    public void MoveRight()
    {
        moveDir.dirValue = DirectionEnum.Right;
        activeDirVector = moveDir.GetVectors(moveDir.dirValue);
        uiTextPro.text = "R";
    }

}
