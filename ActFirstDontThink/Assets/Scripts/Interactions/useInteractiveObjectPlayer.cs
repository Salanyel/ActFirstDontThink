using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class useInteractiveObjectPlayer : useInteractiveObject {

    public string m_virtualActivateButton;

    #region Methods

    override protected void shouldUseObject()
    {
        if (Input.GetButtonDown(m_virtualActivateButton))
        {
            useNeariestInteractibleObject();
        }        
    }

    #endregion

}