using System.Collections;
using UnityEngine;

public abstract class BasePool : MonoBehaviour
{
    public bool IsActive { get { return isActive; } }
    protected bool isActive = false;
    protected float dieDelay = 4f;
    protected Coroutine delayDeactive = null;

    protected virtual void ChangeActive(bool isActive)
    {
        gameObject.SetActive(isActive);
        this.isActive = isActive;
        ChangeDelayDeactive(isActive);
    }

    protected IEnumerator DelayDeactive()
    {
        yield return new WaitForSeconds(dieDelay);
        ChangeActive(false);
    }

    protected void ChangeDelayDeactive(bool isActive)
    {
        if (isActive)
        {
            delayDeactive = StartCoroutine(DelayDeactive());
        }
        else
        {
            if (delayDeactive != null)
            {
                StopCoroutine(delayDeactive);
                delayDeactive = null;
            }
        }
    }
}