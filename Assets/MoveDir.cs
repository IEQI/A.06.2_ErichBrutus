using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveDir : MonoBehaviour
{
    public DirectionEnum dirValue;

    Vector3 rightDir = new Vector3(1, 0, 0);
    Vector3 upDir = new Vector3(0, 1, 0);
    Vector3 downDir = new Vector3(0, -1, 0);
    Vector3 leftDir = new Vector3(-1, 0, 0);


    public Vector3 GetVectors(DirectionEnum dirEnum)
    {
        switch (dirEnum)
        {
            case DirectionEnum.Up:
                return upDir;

            case DirectionEnum.Down:
                return downDir;

            case DirectionEnum.Left:
                return leftDir;

            case DirectionEnum.Right:
                return rightDir;

            default:
                return rightDir;

        }
    }
}


public enum DirectionEnum
{
    Up,
    Down,
    Left,
    Right
}

