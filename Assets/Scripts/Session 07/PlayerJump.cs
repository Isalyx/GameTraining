using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    #region Properties

    private bool m_isGrounded;
    public bool IsGrounded
    {
        get { return m_isGrounded; }
        private set { m_isGrounded = value; }
    }

    #endregion


    PlayerManager m_playerManagerScript;

    bool m_isJump;
    bool m_isFall;

    bool m_jumpRequest;


    [SerializeField]
    private Transform m_rayGround;

    private void Awake()
    {
        m_playerManagerScript = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (m_playerManagerScript.PlayerInputScript.IsJumpPress && !m_isJump)
        //{
        //    m_isJump = true;
        //    m_currentTime = 0f;
        //}

        //SetJumpVector();
        //MakeJump();


        if (m_playerManagerScript.PlayerInputScript.IsJumpPress && !m_isJump)
        {
            m_jumpRequest = true;
        }

        CheckIsGrounded();
        

    }


    private void FixedUpdate()
    {
        if (m_jumpRequest)
        {
            MakeJump();
            m_jumpRequest = false;
        }
    }

    private void MakeJump()
    {
        m_isJump = true;
        m_playerManagerScript.Rb.AddForce(Vector3.up * m_playerManagerScript.Data.JumpSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
    }


    private void CheckIsGrounded()
    {
        if(Physics.Raycast(m_rayGround.position, -transform.up, 0.1f))
        {
            m_isGrounded = true;
            m_isJump = false;
        }
        else
        {
            m_isGrounded = false;
        }
    }


    private void OnDrawGizmos()
    {
        Debug.DrawRay(m_rayGround.position, -transform.up, Color.red);
    }


    // RAYCAST
}
