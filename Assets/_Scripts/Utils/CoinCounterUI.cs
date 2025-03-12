using System.Collections;
using DG.Tweening;

using TMPro;

using UnityEngine;
public class CoinCounterUI : MonoBehaviour

{

    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;
    private float containerInitPosition;
    private float moveAmount;
    [SerializeField] private Ease animationCurve;

    private void Start()
    {
        if (current == null)
        {
            Debug.LogWarning("Current TextMeshProUGUI is not assigned in the CoinCounterUI.");
        }

        if (toUpdate == null)
        {
            Debug.LogWarning("ToUpdate TextMeshProUGUI is not assigned in the CoinCounterUI.");
        }

        if (coinTextContainer == null)
        {
            Debug.LogWarning("CoinTextContainer is not assigned in the CoinCounterUI.");
        }

        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdateScore(int score)
    {
        toUpdate.SetText($"{score}");
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration);
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount,duration).SetEase(animationCurve);
        StartCoroutine(ResetCoinContainer(score));


    }

    private IEnumerator ResetCoinContainer(int score)
    {
        // this tells the editor to wait for a given period of time
        yield return new WaitForSeconds(duration);
        // we use duration since that's the same time as the animation
        current.SetText($"{score}"); // update the original score
        Vector3 localPosition = coinTextContainer.localPosition;
        coinTextContainer.localPosition = new Vector3(localPosition.x,
        containerInitPosition, localPosition.z);
        // then reset the y-localPosition of the coinTextContainer

    }
}