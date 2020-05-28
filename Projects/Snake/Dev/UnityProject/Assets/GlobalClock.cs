using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalClock : MonoBehaviour
{
    public static GlobalClock INSTANCE;

    [SerializeField] private float ticksPerSecond;
    private float estimatedTickTime;
    private float lastTick;

    void Awake()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
        } else
        {
            if(INSTANCE != this)
            {
                Destroy(this);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        estimatedTickTime = 1/ticksPerSecond;
        lastTick = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if((lastTick + estimatedTickTime) < Time.time)
        {
            lastTick = Time.time;
            updateSnakes();
        } else
        {
            //Debug.Log(Time.time.ToString() + " : " + (lastTick + estimatedTickTime));
        }
    }

    private void updateSnakes()
    {
        foreach(GameObject snake in GameObject.FindGameObjectsWithTag("Player"))
        {
            snake.GetComponent<SnakeBodyControl>().Move();
        }

        /*foreach (SnakeMovement sm in FindObjectsOfType(typeof(SnakeMovement))){
            sm.SendMessage("moveUpdate");
        }*/
    }
}
