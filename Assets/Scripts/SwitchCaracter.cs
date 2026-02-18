using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System;
 
public class SwitchCaracter : MonoBehaviour
{
    [Header("Input Fields")]
    [SerializeField] private TMP_InputField nameInput;     // Vārda ievades lauks
    [SerializeField] private TMP_InputField yearInput;    // Gada ievades lauks
    [Header("Button")]
    [SerializeField] private Button calculateButton;      // Poga vecuma aprēķinam
    [Header("Output Text")]
    [SerializeField] private TMP_Text resultText;         // Teksts, kur rādīt rezultātu
    [Header("Settings")]
    [SerializeField] private string characterPrefix = "Supervaronis"; 
    private void Start()
    {
        // Pārliecinās, ka gada ievades lauks pieņem TIKAI ciparus
        if (yearInput != null)
        {
            yearInput.contentType = TMP_InputField.ContentType.IntegerNumber;
            yearInput.characterValidation = TMP_InputField.CharacterValidation.Integer;
        }
        // Pievieno pogai klikšķa handleri
        if (calculateButton != null)
        {
            calculateButton.onClick.AddListener(CalculateAge);
        }
        // Sākotnējais teksts
        if (resultText != null)
        {
            resultText.text = "Ievadiet vārdu un dzimšanas gadu!";
        }
    }
    // Šo funkciju izsauc poga
    public void CalculateAge()
    {
        // Pārbauda, vai ievades lauki nav tukši
        if (nameInput == null || yearInput == null || resultText == null)
        {
            Debug.LogError("Trūkst atsauces uz UI elementiem!");
            return;
        }
        string playerName = nameInput.text.Trim();
        string yearText = yearInput.text.Trim();
        // Pārbauda, vai vārds nav tukšs
        if (string.IsNullOrEmpty(playerName))
        {
            resultText.text = "Lūdzu, ievadiet vārdu!";
            return;
        }
        // Pārbauda, vai gads nav tukšs
        if (string.IsNullOrEmpty(yearText))
        {
            resultText.text = "Lūdzu, ievadiet dzimšanas gadu!";
            return;
        }
        // Mēģina pārveidot gadu par skaitli
        if (int.TryParse(yearText, out int birthYear))
        {
            // Pārbauda, vai gads ir ticams (piemēram, no 1900 līdz 2025)
            int currentYear = DateTime.Now.Year;
            if (birthYear < 1900 || birthYear > currentYear)
            {
                resultText.text = $"Lūdzu, ievadiet ticamu gadu (1900-{currentYear})!";
                return;
            }
            // Aprēķina vecumu
            int age = currentYear - birthYear;
            // Pārbauda, vai vecums ir pozitīvs
            if (age < 0)
            {
                resultText.text = "Dzimšanas gads nevar būt nākotnē!";
                return;
            }
            // Attēlo rezultātu
            resultText.text = $"{characterPrefix} {playerName} ir {age} gadus vecs!";
        }
        else
        {
            // Ja ievade nav skaitlis
            resultText.text = "Lūdzu, ievadiet derīgu dzimšanas gadu (tikai ciparus)!";
        }
    }
    
}