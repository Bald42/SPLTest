using UnityEngine.UI;
using static Enums;
using UnityEngine;
using DG.Tweening;
using System;

public class UIFinish : MonoBehaviour
{
    [SerializeField] private Text finishText = null;
    [SerializeField] private CanvasGroup canvasGroup = null;
    [SerializeField] private Transform panel = null;

    private float speed = 0.3f;
    private const string WIN_MESSAGE = "you win";
    private const string LOSE_MESSAGE = "you lose";

    private Action onRestartEvent = null;

    public void Init()
    {
        gameObject.SetActive(false);
    }

    public void Show(GameState gameState, Action onRestartEvent)
    {
        this.onRestartEvent += onRestartEvent;
        if (gameState == GameState.Win)
        {
            finishText.text = WIN_MESSAGE.ToUpper();
        }
        else if (gameState == GameState.Lose)
        {
            finishText.text = LOSE_MESSAGE.ToUpper();
        }
        else
        {
            return;
        }

        canvasGroup.alpha = 0f;
        panel.localScale = Vector3.zero;
        gameObject.SetActive(true);
        ViewAnim();
    }

    private void ViewAnim()
    {
        panel.DOScale(Vector3.one * 0.8f, speed).SetEase(Ease.InExpo);
        canvasGroup.DOFade(1f, speed);
    }

    public void OnClickRestart()
    {
        onRestartEvent?.Invoke();
    }
}