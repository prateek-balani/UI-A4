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

}