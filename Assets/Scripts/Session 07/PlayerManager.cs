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

    #region Unity Methods

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        PlayerInputScript = GetComponent<PlayerInput>();
        PlayerMovementScript = GetComponent<PlayerMovement>();
        PlayerJumpScript = GetComponent<PlayerJump>();
        PlayerRotationScript = GetComponent<PlayerRotation>();
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
            case E_PlayerState.FALL:
                break;
            case E_PlayerState.CROUCH:
                CrouchUpdate();
                break;
            case E_PlayerState.SLIDE:
                SlideUpdate();
                break;
        }
    }

    #endregion

    #region State Update

    private void IdleUpdate()
    {
        if (PlayerIsMoving())
        {
            if (PlayerInputScript.IsWalking)
            {
                NextState = E_PlayerState.WALK;
            }
            else if (PlayerInputScript.IsSprintPress)
            {
                NextState = E_PlayerState.SPRINT;
            }
            else
            {
                NextState = E_PlayerState.RUN;
            }
        }
        else
        {
            if (PlayerInputScript.IsJumpPress)
            {
                NextState = E_PlayerState.JUMP;
            }
            else if (PlayerInputScript.IsCrouchPress)
            {
                NextState = E_PlayerState.CROUCH;
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
        if (!PlayerIsMoving())
        {
            NextState = E_PlayerState.IDLE;
        }
        else
        {
            if (!PlayerInputScript.IsWalking)
            {
                NextState = E_PlayerState.RUN;
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
        if (!PlayerIsMoving())
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
        if (!PlayerIsMoving())
        {
            NextState = E_PlayerState.IDLE;
        }
        else
        {
            if (m_playerInputScript.IsJumpPress)
            {
                NextState = E_PlayerState.JUMP;
            }
            else if (!m_playerInputScript.IsSprintPress)
            {
                if (m_playerInputScript.IsWalking)
                {
                    NextState = E_PlayerState.WALK;
                }
                else
                {
                    NextState = E_PlayerState.RUN;
                }
            }
            else if (m_playerInputScript.IsCrouchPress)
            {
                NextState = E_PlayerState.SLIDE;
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
            case E_PlayerState.RUN:
                SetCurrentState(E_PlayerState.RUN);
                break;
            case E_PlayerState.JUMP:
                SetCurrentState(E_PlayerState.JUMP);
                break;
            case E_PlayerState.SLIDE:
                SetCurrentState(E_PlayerState.SLIDE);
                break;
        }
    }

    private void JumpUpdate()
    {
        // IS FALLING

        if (Rb.velocity.y == 0)
        {
            NextState = E_PlayerState.IDLE;
        }

        if (NextState == E_PlayerState.IDLE)
        {
            SetCurrentState(E_PlayerState.IDLE);
        }
    }

    private void CrouchUpdate()
    {
        if (!m_playerInputScript.IsCrouchPress)
        {
            if (!PlayerIsMoving())
            {
                NextState = E_PlayerState.IDLE;
            }
            else if (m_playerInputScript.IsJumpPress)
            {
                NextState = E_PlayerState.JUMP;
            }
            else if (m_playerInputScript.IsSprintPress)
            {
                NextState = E_PlayerState.SPRINT;
            }
            else if (m_playerInputScript.IsWalking)
            {
                NextState = E_PlayerState.WALK;
            }
            else
            {
                NextState = E_PlayerState.RUN;
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
            case E_PlayerState.RUN:
                SetCurrentState(E_PlayerState.RUN);
                break;
            case E_PlayerState.SPRINT:
                SetCurrentState(E_PlayerState.SPRINT);
                break;
            case E_PlayerState.JUMP:
                SetCurrentState(E_PlayerState.JUMP);
                break;
        }
    }

    private void SlideUpdate()
    {
        if (!PlayerIsMoving())
        {
            if(m_playerInputScript.IsJumpPress)
            {
                NextState = E_PlayerState.JUMP;
            }
            else if (m_playerInputScript.IsCrouchPress)
            {
                NextState = E_PlayerState.CROUCH;
            }
            else
            {
                NextState = E_PlayerState.IDLE;
            }
        }
        else
        {
            if(m_playerInputScript.IsJumpPress)
            {
                NextState = E_PlayerState.JUMP;
            }
            else if(!m_playerInputScript.IsCrouchPress)
            {
                if(m_playerInputScript.IsSprintPress)
                {
                    NextState = E_PlayerState.SPRINT;
                }
                else if(m_playerInputScript.IsWalking)
                {
                    NextState = E_PlayerState.WALK;
                }
                else
                {
                    NextState = E_PlayerState.RUN;
                }
            }
            else if(!m_playerInputScript.IsSprintPress)
            {
                NextState = E_PlayerState.CROUCH;
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

    #endregion


    #region Private methods

    private void SetCurrentState(E_PlayerState nextState)
    {
        PreviousState = CurrentState;
        CurrentState = nextState;
        m_timeChangeState = Time.time;
        Data.SetCurrentSpeed(CurrentState);

        Debug.Log(CurrentState);
    }

    private bool PlayerIsMoving()
    {
        return PlayerInputScript.DirectionMovement != Vector3.zero;
    }

    #endregion
}
