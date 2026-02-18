using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CaracterSwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown characterDropdown; // Parastais Dropdown
    public Image characterImage;
    public Sprite boySprite;
    public Sprite girlSprite;
    void Start()
    {
        // Iztīra un pievieno opcijas
        characterDropdown.ClearOptions();
        characterDropdown.options.Add(new TMP_Dropdown.OptionData("Zēns"));
        characterDropdown.options.Add(new TMP_Dropdown.OptionData("Meitene"));
        characterDropdown.RefreshShownValue();
        // Pievieno listeneri
        characterDropdown.onValueChanged.AddListener(OnCharacterChanged);
        // Iestata sākotnējo
        OnCharacterChanged(0);
    }
    void OnCharacterChanged(int index)
    {
        if (index == 0 && boySprite != null)
            characterImage.sprite = boySprite;
        else if (index == 1 && girlSprite != null)
            characterImage.sprite = girlSprite;
    }
}