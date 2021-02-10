using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float JumpTime;


    public float NormalSpeed;
    public float WalkSpeed;
    public float JumpSpeed;
    public float RotationSpeed;


    public float SprintMultiplicator;
    public float CrouchMultiplicator;


    private float m_currentSpeed;

    private bool m_isIdle;
    private bool m_isWalking;
    private bool m_isJumping;
    private bool m_isCrouching;
    private bool m_isSprinting;

    private float m_currentTime;





    int m_zValue = 0;
    int m_xValue = 0;

    Vector3 m_direction;
    Vector3 m_rotation;
    Vector3 m_currentScale;
    Vector3 m_jump;

    private void Update()
    {
        GetMovement();
        GetRotation();

        GetSprint();
        GetCrouch();

        GetWalk();

        SetCurrentSpeed();


        GetJump();
        SetJumpSpeed();




        MakeMovement();


        // On va faire avancer le cube
    }

    private void SampleMovement()
    {
        // On va récupérer les inputs du player
        //if(Input.GetKeyDown(KeyCode.Z))
        //{
        //    Debug.Log("J'appuie sur la touche Z");
        //}

        //if(Input.GetKey(KeyCode.Z))
        //{
        //    Debug.Log("Je reste appuyé sur le Z");
        //}

        //if(Input.GetKeyUp(KeyCode.Z))
        //{
        //    Debug.Log("Je relache la touche Z");
        //}

        //// METHOD 1
        //m_zValue = 0;
        //m_xValue = 0;


        //if (Input.GetKey(KeyCode.Z))
        //{
        //    m_zValue = 1;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    m_zValue = -1;
        //}

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    m_xValue = -1;
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    m_xValue = 1;
        //}

        //transform.position = new Vector3(transform.position.x + (m_xValue * Speed * Time.deltaTime), transform.position.y, transform.position.z + (m_zValue * Speed * Time.deltaTime));

        //// METHOD 2
        //m_direction = Vector3.zero; // new Vector3();

        //if (Input.GetKey(KeyCode.Z))
        //{
        //    m_direction += transform.forward;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    m_direction -= transform.forward;
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    m_direction += transform.right;
        //}
        //else if (Input.GetKey(KeyCode.Q))
        //{
        //    m_direction -= transform.right;
        //}

        //// METHOD 3
        //m_direction = Vector3.zero; // new Vector3();

        //if (Input.GetKey(KeyCode.Z))
        //{
        //    m_direction += Vector3.forward;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    m_direction += Vector3.back;
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    m_direction += Vector3.right;
        //}
        //else if (Input.GetKey(KeyCode.Q))
        //{
        //    m_direction += Vector3.left;
        //}

        //transform.position += m_direction * Speed * Time.deltaTime;


        //// METHOD 3 RACCOURCI
        //m_direction += Input.GetKey(KeyCode.Z) ? Vector3.forward : Input.GetKey(KeyCode.S) ? Vector3.back : Vector3.zero;
        //m_direction += Input.GetKey(KeyCode.Q) ? Vector3.left : Input.GetKey(KeyCode.D) ? Vector3.right : Vector3.zero;

        //transform.position += m_direction * Speed * Time.deltaTime;

        //// METHOD 4
        //m_direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Speed * Time.deltaTime;
        //transform.position += m_direction * Speed * Time.deltaTime;
        //transform.Translate(m_direction, Space.Self);


        //// METHOD 5 + ROTATION
        //m_direction = new Vector3(0, 0, Input.GetAxis("Vertical")) * Speed * Time.deltaTime;
        //m_rotation.y = Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime;

        //transform.Translate(m_direction);
        //transform.Rotate(m_rotation);
    }

    private void GetMovement()
    {
        m_direction = Vector3.zero;

        m_direction += (Input.GetKey(KeyCode.Z) ? Vector3.forward : Input.GetKey(KeyCode.S) ? Vector3.back : Vector3.zero);
        m_direction += (Input.GetKey(KeyCode.A) ? Vector3.left : Input.GetKey(KeyCode.E) ? Vector3.right : Vector3.zero);


        // Equivalent en if / else

        //m_direction = Vector3.zero;
        //if (Input.GetKey(KeyCode.Z))
        //{
        //    m_direction += Vector3.forward;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    m_direction += Vector3.back;
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    m_direction += Vector3.left;
        //}
        //else if (Input.GetKey(KeyCode.E))
        //{
        //    m_direction += Vector3.right;
        //}
    }

    private void GetRotation()
    {

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    m_rotation.y -= 1;
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    m_rotation.y += 1;
        //}

        m_rotation.y = (Input.GetKey(KeyCode.Q) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0) * RotationSpeed * Time.deltaTime;
    }

    private void GetSprint()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            m_direction *= SprintMultiplicator;
        }
    }

    private void GetCrouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            m_currentScale = transform.localScale;
            m_currentScale.y /= 2;
            transform.localScale = m_currentScale;
        }
        else if(Input.GetKey(KeyCode.C))
        {
            m_direction /= CrouchMultiplicator;
        }
        else if(Input.GetKeyUp(KeyCode.C))
        {
            m_currentScale = transform.localScale;
            m_currentScale.y *= 2;
            transform.localScale = m_currentScale;
        }
    }

    private void GetWalk()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            m_isWalking = !m_isWalking;

            //Equivalent :

            //if(m_isWalking == true)
            //{
            //    m_isWalking = false;
            //}
            //else if(m_isWalking == false)
            //{
            //    m_isWalking = true;
            //}
        }
    }

    private void SetCurrentSpeed()
    {
        m_currentSpeed = m_isWalking ? WalkSpeed : NormalSpeed;
    }

    private void GetJump()
    {
        if (!m_isJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_currentTime = 0f;
                m_isJumping = true;
            }
        }
    }

    private void SetJumpSpeed()
    {
        if(m_isJumping)
        {
            if (m_currentTime < JumpTime)
            {
                m_jump = Vector3.up;
            }
            else if(m_currentTime > JumpTime && m_currentTime < JumpTime * 2)
            {
                m_jump = Vector3.down;
            }
            else if(m_currentTime > JumpTime * 2)
            {
                m_jump = Vector3.zero;
                m_isJumping = false;
            }
            m_currentTime += Time.deltaTime;
        }
    }

    private void MakeMovement()
    {
        // SET VALUES
        m_direction *= m_currentSpeed * Time.deltaTime;
        m_jump *= JumpSpeed * Time.deltaTime;
        m_rotation *= RotationSpeed * Time.deltaTime;


        // MAKE TRANSLATE / ROTATION
        transform.Translate(m_direction + m_jump);
        transform.Rotate(m_rotation);
    }
}
