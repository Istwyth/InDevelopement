using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    
public Transform playerRectangle;
public float cameraDistance = 5.0f;

void Awake()
{
GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);

}

void FixedUpdate()
{
    transform.position = new Vector3(playerRectangle.position.x, playerRectangle.position.y, transform.position.z);
}

}
