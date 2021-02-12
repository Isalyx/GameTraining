using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    PlayerManager m_playerManagerScript;

    [SerializeField]
    [Range(1f, 100f)]
    private float m_normalSpeed;
    public float NormalSpeed
    {
        get { return m_normalSpeed; }
        private set { m_normalSpeed = value; }
    }

    [SerializeField]
    [Range(1f, 100f)]
    private float m_rotationSpeed;
    public float RotationSpeed
    {
        get { return m_rotationSpeed; }
        private set { m_rotationSpeed = value; }
    }



    [SerializeField]
    [Range(1, 10)]
    private int m_sprintMultiplicator;
    public int SprintMultiplicator
    {
        get { return m_sprintMultiplicator; }
        private set { m_sprintMultiplicator = value; }
    }


    [SerializeField]
    [Range(1f, 20f)]
    private float m_walkSpeed;
    public float WalkSpeed
    {
        get { return m_walkSpeed; }
        private set { m_walkSpeed = value; }
    }

    [SerializeField]
    [Range(1f, 100f)]
    private float m_jumpSpeed;
    public float JumpSpeed
    {
        get { return m_jumpSpeed; }
        private set { m_jumpSpeed = value; }
    }


    [SerializeField]
    [Range(0.1f, 1f)]
    private float m_crouchMultiplicator;
    public float CrouchMultiplicator
    {
        get { return m_crouchMultiplicator; }
        private set { m_crouchMultiplicator = value; }
    }


    private float m_currentSpeed;
    public float CurrentSpeed
    {
        get { return m_currentSpeed; }
        private set { m_currentSpeed = value; }
    }


    public void SetCurrentSpeed(E_PlayerState currentState)
    {
        switch (currentState)
        {
            case E_PlayerState.IDLE:
                CurrentSpeed = 0;
                break;
            case E_PlayerState.WALK:
                CurrentSpeed = WalkSpeed;
                break;
            case E_PlayerState.RUN:
                CurrentSpeed = NormalSpeed;
                break;
            case E_PlayerState.SPRINT:
                CurrentSpeed = NormalSpeed * SprintMultiplicator;
                break;
            case E_PlayerState.CROUCH:
                CurrentSpeed = CurrentSpeed * CrouchMultiplicator;
                break;
            default: CurrentSpeed = 0;
                break;
        }
    }


    public void Init(PlayerManager pm)
    {
        m_playerManagerScript = pm;
    }
}
