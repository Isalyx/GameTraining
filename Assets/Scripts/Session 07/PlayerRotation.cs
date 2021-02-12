using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    PlayerManager m_playerManagerScript;

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
        transform.Rotate(m_playerManagerScript.PlayerInputScript.RotationVector * m_playerManagerScript.Data.RotationSpeed * Time.deltaTime);
    }
}

