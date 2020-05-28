using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{

    [SerializeField] private Transform tail;
    [SerializeField] private Transform head;

    // Start is called before the first frame update
    void Start()
    {
        tail.GetComponent<SnakeTailControl>().setPieceToFollow(head.GetComponent<SnakeMovement>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
