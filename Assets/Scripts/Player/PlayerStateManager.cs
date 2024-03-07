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
    private Animator _anim;

    private float _dirX;
    private float _dirY;

    private bool _onPlantingArea = false;
    private bool _onFishingZone = false;

    [Header("Speed")]
    [SerializeField] private float _moveSpeed;

    [Header("Childern Object")]
    [SerializeField] private GameObject _attackZone;

    public PlayerBaseState CurrentState { get => _currentState; set => _currentState = value; }
    public PlayerStateFactory State { get => _state; set => _state = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }
    public BoxCollider2D Col { get => _col; set => _col = value; }

    public Animator Anim { get => _anim; set => _anim = value; }
    public float DirX { get => _dirX; set => _dirX = value; }
    public float DirY { get => _dirY; set => _dirY = value; }
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public GameObject AttackZone { get => _attackZone; set => _attackZone = value; }
    public bool OnPlantingArea { get => _onPlantingArea; set => _onPlantingArea = value; }
    public bool OnFishingZone { get => _onFishingZone; set => _onFishingZone = value; }

    private void Awake()
    {
        State = new PlayerStateFactory(this);

        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Col = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        CurrentState = State.Idle();
        CurrentState.EnterState();
        AttackZone.SetActive(false);
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

    public void UpdateObjectDirX()
    {
        switch (DirX)
        {
            case 1: transform.rotation = Quaternion.Euler(0, 0, 0); break;
            case -1: transform.rotation = Quaternion.Euler(0, 180, 0); break;
            default: break;
        }
    }

    #region TriggerCheck
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("PlantingArea"))
        {
            OnPlantingArea = true;
        }
        else if(other.gameObject.CompareTag("FishingZone"))
        {
            OnFishingZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlantingArea"))
        {
            OnPlantingArea = false;
        }
        else if(other.gameObject.CompareTag("FishingZone"))
        {
            OnFishingZone = false;
        }
    }
    #endregion TriggerCheck
}
