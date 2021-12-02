using System;
using UnityEngine;
using UnityEngine.Events;

public class Mine : MonoBehaviour
{
    [SerializeField] TweenEffect tween;
    MineSO mineSO;
    int currentSteel;
    
    [SerializeField] UnityEvent onMineEmptied;

    public void StartMine(MineSO mineSO)
    {
        tween.transform.localScale = Vector3.zero;
        tween.PlayTweenToNormal();
        currentSteel = mineSO.steelAvailable;
        this.mineSO = mineSO;
    }

    public void MineMineral()
    {
        if (currentSteel > 0)
        {
            currentSteel--;
            mineSO.inventory.steelAvailable++;

            if (currentSteel <= 0)
            {
                onMineEmptied?.Invoke();
                Debug.Log("Base");
            }
        }
    }
}