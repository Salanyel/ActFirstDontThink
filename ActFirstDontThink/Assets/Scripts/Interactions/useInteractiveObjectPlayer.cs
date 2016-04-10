using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class useInteractiveObjectPlayer : useInteractiveObject {

    string m_virtualActivateButton;

    #region Methods

    override protected void initialize()
    {
        m_virtualActivateButton = "UseP" + GetComponent<PlayerId>().m_id;
    }

    override protected void shouldUseObject()
    {
        if (Input.GetButtonUp(m_virtualActivateButton))
        {
            useNeariestInteractibleObject();
        }        
    }

    #endregion

}