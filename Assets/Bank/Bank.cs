using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayBalance;

    [SerializeField] int startingBalance = 150;
    
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        displayBalance.text = $"Gold: {currentBalance}";
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        
        if(currentBalance < 0)
        {
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}
