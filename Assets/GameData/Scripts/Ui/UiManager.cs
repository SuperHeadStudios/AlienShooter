using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro coinText; // Assign this in the Unity Inspector
    [SerializeField] private int coinCount = 0;

    void Start()
    {
        UpdateCoinUI();
    }

    public void CollectCoin()
    {
        coinCount++;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        coinText.text = "Coins: " + coinCount;
    }
}
