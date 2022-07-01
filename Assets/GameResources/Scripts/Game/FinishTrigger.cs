using UnityEngine;
using System;

public class FinishTrigger : MonoBehaviour
{
    public static Action OnFinishEvent = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            GameTag gameTag = other.gameObject.GetComponentInChildren<GameTag>();
            if (gameTag != null && gameTag.MyTag == Enums.Tag.Player)
            {
                OnFinishEvent?.Invoke();
            }
        }
    }
}