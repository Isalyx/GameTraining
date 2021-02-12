using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerJump))]
[RequireComponent(typeof(PlayerRotation))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private PlayerData m_data;
    public PlayerData Data
    {
        get { return m_data; }
        private set { m_data = value; }
    }


    private Rigidbody m_rb;
    public Rigidbody Rb
    {
        get { return m_rb; }
        private set { m_rb = value; }
    }

    private PlayerInput m_playerInputScript;
    public PlayerInput PlayerInputScript
    {
        get { return m_playerInputScript; }
        private set { m_playerInputScript = value; }
    }

    private PlayerMovement m_playerMovementScript;
    public PlayerMovement PlayerMovementScript
    {
        get { return m_playerMovementScript; }
        private set { m_playerMovementScript = value; }
    }

    private PlayerJump m_playerJumpScript;
    public PlayerJump PlayerJumpScript
    {
        get { return m_playerJumpScript; }
        private set { m_playerJumpScript = value; }
    }

    private PlayerRotation m_playerRotationScript;

    public PlayerRotation PlayerRotationScript
    {
        get { return m_playerRotationScript; }
        private set { m_playerRotationScript = value; }
    }




    #region State
    private E_PlayerState m_previousState;
    public E_PlayerState PreviousState
    {
        get { return m_previousState; }
        private set { m_previousState = value; }
    }

    private E_PlayerState m_currentState;
    public E_PlayerState CurrentState
    {
        get { return m_currentState; }
        private set { m_currentState = value; }
    }

    private E_PlayerState m_nextState;
    public E_PlayerState NextState
    {
        get { return m_nextState; }
        private set { m_nextState = value; }
    }

    float m_timeChangeState;
    #endregion

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        PlayerInputScript = GetComponent<PlayerInput>();
        PlayerMovementScript = GetComponent<PlayerMovement>();
        PlayerJumpScript = GetComponent<PlayerJump>();
        PlayerRotationScript = GetComponent<PlayerRotation>();


        Data.Init(this);
    }

    private void Update()
    {
        switch (CurrentState)
        {
            case E_PlayerState.IDLE:
                IdleUpdate();
                break;
            case E_PlayerState.WALK:
                WalkUpdate();
                break;
            case E_PlayerState.RUN:
                RunUpdate();
                break;
            case E_PlayerState.SPRINT:
                SprintUpdate();
                break;
            case E_PlayerState.JUMP:
                JumpUpdate();
                break;
            case E_PlayerState.CROUCH:
                CrouchUpdate();
                break;
        }
    }

    private void IdleUpdate()
    {
        if(PlayerInputScript.DirectionMovement != Vector3.zero)
        {
            if(PlayerInputScript.IsWalking)
            {
                NextState = E_PlayerState.WALK;
            }
            else if(PlayerInputScript.IsSprintPress)
            {
                NextState = E_PlayerState.SPRINT;
            }
            else if(PlayerInputScript.IsCrouchPress)
            {
                NextState = E_PlayerState.CROUCH;
            }
            else if(PlayerInputScript.IsJumpPress)
            {
                NextState = E_PlayerState.JUMP;
            }
            else
            {
                NextState = E_PlayerState.RUN;
            }
        }


        switch (NextState)
        {
            case E_PlayerState.WALK:
                SetCurrentState(E_PlayerState.WALK);
                break;
            case E_PlayerState.RUN:
                SetCurrentState(E_PlayerState.RUN);
                break;
            case E_PlayerState.SPRINT:
                SetCurrentState(E_PlayerState.SPRINT);
                break;
            case E_PlayerState.JUMP:
                SetCurrentState(E_PlayerState.JUMP);
                break;
            case E_PlayerState.CROUCH:
                SetCurrentState(E_PlayerState.CROUCH);
                break;
        }
    }

    private void WalkUpdate()
    {
        if (PlayerInputScript.DirectionMovement == Vector3.zero)
        {
            NextState = E_PlayerState.IDLE;
        }
        else
        {
            if(!PlayerInputScript.IsWalking)
            {
                NextState = E_PlayerState.RUN;
            }
            else if(PlayerInputScript.IsCrouchPress)
            {
                NextState = E_PlayerState.CROUCH;
            }
            else if(PlayerInputScript.IsJumpPress)
            {
                NextState = E_PlayerState.JUMP;
            }
        }

        switch (NextState)
        {
            case E_PlayerState.IDLE:
                SetCurrentState(E_PlayerState.IDLE);
                break;
            case E_PlayerState.RUN:
                SetCurrentState(E_PlayerState.RUN);
                break;
            case E_PlayerState.SPRINT:
                SetCurrentState(E_PlayerState.SPRINT);
                break;
            case E_PlayerState.JUMP:
                SetCurrentState(E_PlayerState.JUMP);
                break;
            case E_PlayerState.CROUCH:
                SetCurrentState(E_PlayerState.CROUCH);
                break;
        }
    }

    private void RunUpdate()
    {
        if (PlayerInputScript.DirectionMovement == Vector3.zero)
        {
            NextState = E_PlayerState.IDLE;
        }
        else
        {
            if (PlayerInputScript.IsWalking)
            {
                NextState = E_PlayerState.WALK;
            }
            else if (PlayerInputScript.IsCrouchPress)
            {
                NextState = E_PlayerState.CROUCH;
            }
            else if (PlayerInputScript.IsJumpPress)
            {
                NextState = E_PlayerState.JUMP;
            }
        }


        switch (NextState)
        {
            case E_PlayerState.IDLE:
                SetCurrentState(E_PlayerState.IDLE);
                break;
            case E_PlayerState.WALK:
                SetCurrentState(E_PlayerState.WALK);
                break;
            case E_PlayerState.SPRINT:
                SetCurrentState(E_PlayerState.SPRINT);
                break;
            case E_PlayerState.JUMP:
                SetCurrentState(E_PlayerState.JUMP);
                break;
            case E_PlayerState.CROUCH:
                SetCurrentState(E_PlayerState.CROUCH);
                break;
        }
    }

    private void SprintUpdate()
    {
        throw new NotImplementedException();
    }

    private void JumpUpdate()
    {
        throw new NotImplementedException();
    }

    private void CrouchUpdate()
    {
        throw new NotImplementedException();
    }


    private void SetCurrentState(E_PlayerState nextState)
    {
        PreviousState = CurrentState;
        CurrentState = nextState;
        m_timeChangeState = Time.time;
        Data.SetCurrentSpeed(CurrentState);

        Debug.Log(CurrentState);
    }

}
