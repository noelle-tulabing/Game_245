using System;
using TMPro;
using UnityEngine;

public class TvPuzzle : MonoBehaviour
{
    private int targetHour = 12;
    private int targetMinute = 40;
    
    public int currentHour = 0;
    public int currentMinute = 0;

    private static bool isSolved;
    
    public TextMeshProUGUI clockDisplayText;

    public static event Action OnPuzzleSolved;

    void Start()
    {
        isSolved = false;
        UpdateClockDisplay();
    }

    public void OnEnable()
    {
        CameraController.OnTvFocus += UpdateClockDisplay;
    }

    public void OnDisable()
    {
        CameraController.OnTvFocus -= UpdateClockDisplay;
    }

    public void AddHour()
    {
        if (isSolved) return;
        Debug.Log("Adding hour");
        currentHour = (currentHour + 1) % 13;
        if (currentHour < 0) currentHour += 12;
        UpdateClockDisplay();
        CheckSolution();
    }

    public void SubtractHour()
    {
        if (isSolved) return;
        Debug.Log("Removing hour");
        currentHour = (currentHour - 1) % 12;
        if (currentHour < 0) currentHour += 12;
        UpdateClockDisplay();
        CheckSolution();
    }

    public void AddMinute()
    {
        if (isSolved) return;
        Debug.Log("Adding minute");
        currentMinute = (currentMinute + 1) % 60;
        if (currentMinute < 0) currentMinute += 65 - 5; // adjust for 60 min loop
        currentMinute = (currentMinute + 60) % 60;
        UpdateClockDisplay();
        CheckSolution();
    }

    public void SubtractMinute()
    {
        if (isSolved) return;
        Debug.Log("Removing minute");
        currentMinute = (currentMinute - 1) % 60;
        if (currentMinute < 0) currentMinute += 65 - 5; // adjust for 60 min loop
        currentMinute = (currentMinute + 60) % 60;
        UpdateClockDisplay();
        CheckSolution();
    }
    
    private void UpdateClockDisplay()
    {
        if (isSolved)
        {
            clockDisplayText.text = "something has changed outside";
            
        }
        else
        {
            clockDisplayText.text = $"{currentHour:00}:{currentMinute:00}";
        }
    }

    private void CheckSolution()
    {
        if (currentHour == targetHour && currentMinute == targetMinute)
        {
            isSolved = true;
            Debug.Log("Clock Puzzle Solved!");
            OnPuzzleSolved?.Invoke();
        }
    }

    public static bool IsSolved()
    {
        return isSolved;
    }
}
