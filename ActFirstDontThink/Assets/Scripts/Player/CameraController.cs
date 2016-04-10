
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Vector3 m_offset;

    public GameObject m_player;

    void Start()
    {
        m_offset = new Vector3(0, 4, 0);
    }

    void Update()
    {
        if (m_player != null)
        { 
            transform.position = m_player.transform.position + m_offset;
        }
    }
}
