using System.Collections;
using UnityEngine.UI;
using static Enums;
using UnityEngine;

public class UIAim : MonoBehaviour
{
    [SerializeField] private Image aimImage = null;
    [SerializeField] private Color colorFind = default;
    [SerializeField] private Color colorNotFind = default;
    [SerializeField] private LayerMask layerMask = default;
    private Camera camera = null;
    private GameObject lastTarget = null;
    private RaycastHit hit = default;
    private float delayTime = 0.1f;
    private Tag enemyTag = Tag.Enemy;

    public void Init(Camera camera)
    {
        this.camera = camera;
        ChangeAim(false);
        StartCoroutine(DelayCheckRaycast());
    }

    private IEnumerator DelayCheckRaycast()
    {
        var delay = new WaitForSeconds(delayTime);
        while (true)
        {
            yield return delay;
            CheckRayCast();
        }
    }

    private void CheckRayCast()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, float.MaxValue, layerMask))
        {
            if (lastTarget != hit.transform.gameObject)
            {
                lastTarget = hit.transform.gameObject;
                CheckTarget();
            }
        }
        else
        {
            lastTarget = null;
            ChangeAim(false);
        }
    }

    private void CheckTarget()
    {
        if (lastTarget != null)
        {
            GameTag gameTag = lastTarget.GetComponent<GameTag>();
            if (gameTag != null && gameTag.MyTag == enemyTag)
            {
                ChangeAim(true);
            }
            else
            {
                ChangeAim(false);
            }
        }
        else
        {
            ChangeAim(false);
        }
    }

    private void ChangeAim(bool isFindTarget)
    {
        aimImage.color = isFindTarget ? colorFind : colorNotFind;
    }
}