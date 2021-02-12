using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    PlayerManager m_playerManagerScript;

    bool m_isJump;
    private float m_currentTime;

    [SerializeField]
    private float m_jumpTime;

    private Vector3 m_jumpVector;

    private void Awake()
    {
        m_playerManagerScript = GetComponent<PlayerManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerManagerScript.PlayerInputScript.IsJumpPress && !m_isJump)
        {
            m_isJump = true;
            m_currentTime = 0f;
        }

        SetJumpVector();
        MakeJump();
    }



    private void SetJumpVector()
    {
        if (m_isJump)
        {
            if (m_currentTime < m_jumpTime)
            {
                m_jumpVector = Vector3.up;
            }
            else if (m_currentTime.IsBetween(m_jumpTime, m_jumpTime * 2))
            {
                m_jumpVector = Vector3.zero;
            }
            else if (m_currentTime > m_jumpTime * 2)
            {
                m_jumpVector = Vector3.zero;
                m_isJump = false;
            }
            m_currentTime += Time.deltaTime;
        }
    }

    private void MakeJump()
    {
        transform.Translate(m_jumpVector * m_playerManagerScript.Data.JumpSpeed * Time.deltaTime);
    }
}
