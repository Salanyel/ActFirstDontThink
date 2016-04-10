
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Vector3 m_offset;
    public Vector3 m_offsetRotation;

    void Start()
    {
        m_offset = new Vector3(0, 3.44f, 0);
        m_offsetRotation = new Vector3(90, 0, 0);
    }

    public void setPosition()
    {
        transform.localPosition = m_offset;
        transform.localEulerAngles = m_offsetRotation;
        transform.localScale = new Vector3(1, 1, 1);
    }
}
