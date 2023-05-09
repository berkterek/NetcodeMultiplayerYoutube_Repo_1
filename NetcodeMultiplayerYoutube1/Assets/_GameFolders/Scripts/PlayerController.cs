using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] Animator _animator;
    [SerializeField] float _moveSpeed = 5f;
    
    InputReader _inputReader;

    void OnValidate()
    {
        if (_characterController == null)
        {
            _characterController = GetComponent<CharacterController>();
        }

        if (_animator == null)
        {
            _animator = GetComponentInChildren<Animator>();
        }
    }

    void Awake()
    {
        _inputReader = new InputReader();
    }

    void Update()
    {
        _characterController.Move(Time.deltaTime * _moveSpeed * _inputReader.Direction);
    }

    void LateUpdate()
    {
        _animator.SetFloat("moveSpeed", _inputReader.Direction.magnitude,0.1f,Time.deltaTime);
    }
}