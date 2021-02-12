using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerManager m_playerManagerScript;

    private void Awake()
    {
        m_playerManagerScript = GetComponent<PlayerManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if(m_playerManagerScript.Data.CurrentSpeed != 0)
            transform.Translate(m_playerManagerScript.PlayerInputScript.DirectionMovement * m_playerManagerScript.Data.CurrentSpeed * Time.deltaTime);
    }
}
