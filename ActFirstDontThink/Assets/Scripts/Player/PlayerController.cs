using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    Rigidbody m_rigidBody;
    Animator m_animator;
    string m_horizontal;
    string m_vertical;

    public bool m_isInteracting;

    public float m_speed;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
        m_horizontal = "Horizontal" + GetComponent<PlayerId>().m_id;
        m_vertical = "Vertical" + GetComponent<PlayerId>().m_id;
    }

    void Update()
    {

        if (m_isInteracting)
        {
            m_rigidBody.velocity = Vector3.zero;
            return;
        }    

        float moveHorizontal = Input.GetAxis(m_horizontal);
        float moveVertical = -Input.GetAxis(m_vertical);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement * m_speed == Vector3.zero)
        {
            setWalk(false);
            m_rigidBody.velocity = Vector3.zero;
        }
        else
        {
            setWalk(true);
            m_rigidBody.velocity = movement * m_speed;
            transform.LookAt(transform.position + movement);
        }        
    }

    void setWalk(bool p_value)
    {
        m_animator.SetBool(AnimationsVariables.m_avatar_isWalking, p_value);
    }

    public void interactionFinished()
    {
        m_isInteracting = false;
    }

    public void launchInteraction()
    {
        m_isInteracting = true;
        float value = Random.Range(0f, 1f);
        int animation;

        if (value <= 0.5)
        {
            animation = 0;
        }
        else if (0.5 < value && value < 0.75)
        {
            animation = 1;
        }
        else
        {
            animation = 2;
        }


        m_animator.SetInteger(AnimationsVariables.m_avatar_Use, animation);
        m_animator.SetBool(AnimationsVariables.m_avatar_isInteracting, true);
    }

}
