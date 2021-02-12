using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerManager m_playerManagerScript;


    //private float m_verticalMovement;
    //public float VerticalMovement
    //{
    //    get { return m_verticalMovement; }
    //    private set { m_verticalMovement = value; }
    //}

    //private float m_horizontalMovement;
    //public float HorizontalMovement
    //{
    //    get { return m_horizontalMovement; }
    //    private set { m_horizontalMovement = value; }
    //}

    private Vector3 m_directionMovement;
    public Vector3 DirectionMovement
    {
        get { return m_directionMovement; }
        set { m_directionMovement = value; }
    }



    //private float m_rotationY;
    //public float RotationY
    //{
    //    get { return  m_rotationY; }
    //    private set {  m_rotationY = value; }
    //}

    private Vector3 m_rotationVector;
    public Vector3 RotationVector
    {
        get { return m_rotationVector; }
        private set { m_rotationVector = value; }
    }



    private bool m_isJumpPress;
    public bool IsJumpPress
    {
        get { return m_isJumpPress; }
        private set { m_isJumpPress = value; }
    }

    private bool m_isSprintPress;
    public bool IsSprintPress
    {
        get { return m_isSprintPress; }
        private set { m_isSprintPress = value; }
    }


    private bool m_isCrouchPress;
    public bool IsCrouchPress
    {
        get { return m_isCrouchPress; }
        private set { m_isCrouchPress = value; }
    }


    private bool m_isWalking;
    public bool IsWalking
    {
        get { return m_isWalking; }
        private set { m_isWalking = value; }
    }


    private void Awake()
    {
        m_playerManagerScript = GetComponent<PlayerManager>();
    }



    // Update is called once per frame
    void Update()
    {
        GetMovementInput();

        GetRotationInput();

        GetJumpInput();

        GetSprintInput();

        GetCrouchInput();

        GetWalkInput();
    }



    private void GetMovementInput()
    {
        DirectionMovement = Vector3.zero;

        DirectionMovement += (Input.GetKey(KeyCode.Z) ? Vector3.forward : Input.GetKey(KeyCode.S) ? Vector3.back : Vector3.zero);
        DirectionMovement += (Input.GetKey(KeyCode.A) ? Vector3.left : Input.GetKey(KeyCode.E) ? Vector3.right : Vector3.zero);

        // EQUIVALENT

        //// Déplacement HAUT / BAS
        //if (Input.GetKey(KeyCode.Z))
        //{
        //    VerticalMovement = 1;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    VerticalMovement = -1;
        //}


        //// Déplacement GAUCHE/DROITE
        //if(Input.GetKey(KeyCode.A))
        //{
        //    HorizontalMovement = -1;
        //}
        //else if(Input.GetKey(KeyCode.E))
        //{
        //    HorizontalMovement = 1;
        //}
    }

    private void GetRotationInput()
    {
        RotationVector = new Vector3(0, (Input.GetKey(KeyCode.Q) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0), 0);


        /*
        //Rotation GAUCHE/DROITE
        if (Input.GetKey(KeyCode.Q))
        {
            RotationY = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotationY = 1;
        }
        else
        {
            RotationY = 0;
        }
        */
    }

    private void GetJumpInput()
    {
        IsJumpPress = Input.GetKey(KeyCode.Space);

        ////Jump
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    IsJumpPress = true;
        //}
        //else
        //{
        //    IsJumpPress = false;
        //}
    }

    private void GetSprintInput()
    {
        IsSprintPress = Input.GetKey(KeyCode.LeftShift);


        ////Sprint
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    IsSprintPress = true;
        //}
        //else
        //{
        //    IsSprintPress = false;
        //}
    }

    private void GetCrouchInput()
    {
        IsCrouchPress = Input.GetKey(KeyCode.C);

        ////Crouch
        //if (Input.GetKey(KeyCode.C))
        //{
        //    IsCrouchPress = true;
        //}
        //else
        //{
        //    IsCrouchPress = false;
        //}
    }

    private void GetWalkInput()
    {
        //Walk
        if (Input.GetKeyDown(KeyCode.W))
            IsWalking = !IsWalking;

        // EQUIVALENT 
        //IsWalking = Input.GetKeyDown(KeyCode.W) ? !IsWalking : IsWalking;
    }


}
