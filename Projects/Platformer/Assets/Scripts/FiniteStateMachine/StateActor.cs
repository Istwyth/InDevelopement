using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateActor : MonoBehaviour
{
    public StateMachine StateMachine { get; private set; }

    public Animator Anim { get; private set; }
    public Collider2D Collider { get; private set; }

    [SerializeField]
    private ActorData actorData;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Collider = GetComponent<Collider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public bool IsGrounded()
    {
        Vector3 min = Collider.bounds.min;
        Vector3 max = Collider.bounds.max;
        Vector3 leftCheck = new Vector3(min.x, min.y, min.z);
        Vector3 rightCheck = new Vector3(max.x, min.y + actorData.GroundDetectionDepth(), min.z);

        return Physics2D.OverlapArea(leftCheck, rightCheck, actorData.GroundLayers());
    }


}
