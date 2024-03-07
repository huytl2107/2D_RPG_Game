using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmEntity : MonoBehaviour
{
    private BoxCollider2D _col;
    private Animator _anim;
    private float _price;

    public BoxCollider2D Col { get => _col; set => _col = value; }
    public Animator Anim { get => _anim; set => _anim = value; }
    public float Price { get => _price; set => _price = value; }

    public virtual void Awake()
    {
        Col = GetComponent<BoxCollider2D>();
        Anim = GetComponent<Animator>();
    }
}
