using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;


    int m_zValue = 0;
    int m_xValue = 0;

    Vector3 m_direction;
    Vector3 m_rotation;

    private void Update()
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
        ////transform.position += m_direction * Speed * Time.deltaTime;
        //transform.Translate(m_direction, Space.Self);


        //// METHOD 5 + ROTATION
        //m_direction = new Vector3(0, 0, Input.GetAxis("Vertical")) * Speed * Time.deltaTime;
        //m_rotation.y = Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime;

        //transform.Translate(m_direction);
        //transform.Rotate(m_rotation);

        // METHOD 6
        m_direction = (Input.GetKey(KeyCode.Z) ? Vector3.forward : Input.GetKey(KeyCode.S) ? Vector3.back : Vector3.zero) * Speed * Time.deltaTime;
        m_rotation.y = (Input.GetKey(KeyCode.Q) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0) * RotationSpeed * Time.deltaTime;

        transform.Translate(m_direction);
        transform.Rotate(m_rotation);


        // On va faire avancer le cube
    }
}
