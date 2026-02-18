using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AprakstaMaina : MonoBehaviour

{
     [SerializeField] private TMP_Text resultText; // ja izmantojam Textmeshpro tad lietojam šo

    [SerializeField] private TMP_Dropdown resultDropdown; //Dropdown kuru izmantojam

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      if(resultDropdown !=null)
        {
            resultDropdown.onValueChanged.AddListener(OnGenderChanged);
            OnGenderChanged(resultDropdown.value);  
        }  
    }

    // Update is called once per frame
    public void OnGenderChanged(int index)
    {
      if(resultText !=null)
        {
          if(index ==0)
            {
                resultText.text = "John is 27 years old and he is an manager!";
            }
            else if(index ==1)
            {
                resultText.text = "Karlina is 35 years old and she is a super hero!";
            }
        } 
    }
}

