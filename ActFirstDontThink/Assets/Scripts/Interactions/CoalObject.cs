using UnityEngine;
using System.Collections;

public class CoalObject : ActionObject {

    int m_reset = 0;

	override public void disableKillingZone()
    {
        ++m_reset;

        if(m_reset == 2)
        {
            m_reset = 0;
            m_killingZone.enabled = false;
        }
    }
}
