using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Enemy shieldEnemy;
    
    public void ActivateStick()
    {
        shieldEnemy.ActivateStick();
    }
}
