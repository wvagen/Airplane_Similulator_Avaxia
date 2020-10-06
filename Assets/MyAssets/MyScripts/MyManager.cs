using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyManager : MonoBehaviour
{
    public float latitudeStartPoint, longitudeStartPoint;
    public float latitudeEndPoint, longitudeEndPoint;

    public float moveSpeed = 50;

    public Text isMovingTxt;

    public GameObject startPoint,endPoint;

    Vector3 tempStartPointPos,tempEndPointPos;

    GameObject tempStartPoint, tempEndPoint;

    bool canMove = false;


    void Update()
    {
        if (canMove && tempStartPoint)
        {
            tempStartPoint.transform.position = Vector3.MoveTowards(tempStartPoint.transform.position, tempEndPoint.transform.position, Time.deltaTime * moveSpeed);
        }
    }

   public void SpawnPoints()
    {
        tempStartPointPos = Quaternion.AngleAxis(longitudeStartPoint, -Vector3.up) * Quaternion.AngleAxis(latitudeStartPoint, -Vector3.right) * new Vector3(0, 0, 1);
        tempEndPointPos = Quaternion.AngleAxis(longitudeEndPoint, -Vector3.up) * Quaternion.AngleAxis(latitudeEndPoint, -Vector3.right) * new Vector3(0, 0, 1);

        if (tempStartPoint != null) Destroy(tempStartPoint);
        if (tempEndPoint != null) Destroy(tempEndPoint);

        tempStartPoint = Instantiate(startPoint, tempStartPointPos, Quaternion.identity);
        tempEndPoint = Instantiate(endPoint, tempEndPointPos, Quaternion.identity);
    }


    public void StartMovingPoints()
    {
        canMove = !canMove;

        if (canMove) isMovingTxt.text = "Stop Moving";
        else isMovingTxt.text = "Start Moving";
    }

}
