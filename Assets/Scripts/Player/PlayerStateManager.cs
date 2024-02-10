using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    //Khởi tạo các state
    PlayerBaseState _currentState;
    PlayerStateFactory _state;

    private Rigidbody2D _rb;
    private BoxCollider2D _col;

    private float _dirX;
    private float _dirY;
    [SerializeField] private float _moveSpeed;

    public PlayerBaseState CurrentState { get => _currentState; set => _currentState = value; }
    public PlayerStateFactory State { get => _state; set => _state = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }
    public BoxCollider2D Col { get => _col; set => _col = value; }
    public global::System.Single DirX { get => _dirX; set => _dirX = value; }
    public global::System.Single DirY { get => _dirY; set => _dirY = value; }
    public global::System.Single MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

    private void Awake()
    {
        State = new PlayerStateFactory(this);

        Rb = GetComponent<Rigidbody2D>();
        Col = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        CurrentState = State.Idle();
        CurrentState.EnterState();
    }

    private void Update()
    {
        DirX = Input.GetAxisRaw("Horizontal");
        DirY = Input.GetAxisRaw("Vertical");
        CurrentState.UpdateState();
    }

    private void FixedUpdate() 
    {
        CurrentState.FixedUpdateState();
    }
}
