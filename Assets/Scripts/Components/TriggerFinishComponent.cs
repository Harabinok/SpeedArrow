using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinishComponent : MonoBehaviour
{
    public void Finish()
    {
        PlayerManager.playerManager.Finish();
    }
}
