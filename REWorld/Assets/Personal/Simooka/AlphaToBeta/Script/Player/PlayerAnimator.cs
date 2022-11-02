using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //インスタンス化
    public static PlayerAnimator instance;

    //アニメーター
    private Animator _animator;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //方向トリガー（right/left）をSet　基本はright
    public void SetDirection(bool value = true)
    {
        _animator.SetBool("right", value);
        _animator.SetBool("left", !value);
    }

    //移動トリガーをSet
    public void SetMove(bool value = true)
    {
        _animator.SetBool("isMoving", value);
    }

    public void SetJump(bool value = true)
    {
        _animator.SetBool("isJumping", value);
    }

    public void SetKanjyo(bool value = true)
    {
        _animator.SetBool("kanjo", value);
    }
}
