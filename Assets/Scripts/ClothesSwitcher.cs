using UnityEngine;
using UnityEngine.UI;
 
public class ClothesSwitcher : MonoBehaviour
{
    
    public GameObject bikses1;
    public GameObject bikses2;
    
    public GameObject biksesToggle;  
 
    
    public GameObject jakas1;
    public GameObject jakas2;
    
    public GameObject jakasToggle;
 
    void Start()
    {
        Debug.Log("=== ClothingUI Start ===");
       
        
        if (biksesToggle == null)
        {
            Debug.LogError("biksesToggle NAV pieslēgts Inspectorā!");
            return;
        }
       
        if (jakasToggle == null)
        {
            Debug.LogError("jakasToggle NAV pieslēgts Inspectorā!");
            return;
        }
       
        
        Toggle biksesToggleComp = biksesToggle.GetComponent<Toggle>();
        Toggle jakasToggleComp = jakasToggle.GetComponent<Toggle>();
       
        
        if (biksesToggleComp == null)
        {
            Debug.LogError($"biksesToggle '{biksesToggle.name}' nav Toggle komponentes!");
            return;
        }
       
        if (jakasToggleComp == null)
        {
            Debug.LogError($"jakasToggle '{jakasToggle.name}' nav Toggle komponentes!");
            return;
        }
       
        
        biksesToggleComp.onValueChanged.RemoveAllListeners();
        jakasToggleComp.onValueChanged.RemoveAllListeners();
       
        
        biksesToggleComp.onValueChanged.AddListener(ToggleBikses);
        jakasToggleComp.onValueChanged.AddListener(ToggleJakas);
       
        
        biksesToggleComp.isOn = false;  // Sākumā izslēgts
        jakasToggleComp.isOn = false;   // Sākumā izslēgts
       
        // Izsauc funkcijas ar sākotnējām vērtībām
        ToggleBikses(biksesToggleComp.isOn);
        ToggleJakas(jakasToggleComp.isOn);
       
        Debug.Log($"BiksesToggle sākotnējā vērtība: {biksesToggleComp.isOn}");
        Debug.Log($"JakasToggle sākotnējā vērtība: {jakasToggleComp.isOn}");
    }
 
    // Bikšu toggle
    public void ToggleBikses(bool val)
    {
        Debug.Log($"ToggleBikses IZSAUKTS! Vērtība: {val}");
       
        // Pārbauda vai objekti eksistē
        if (bikses1 == null) Debug.LogError("bikses1 = null!");
        if (bikses2 == null) Debug.LogError("bikses2 = null!");
       
       
        // Uzstāda aktīvumu
        if (bikses1 != null)
        {
            bikses1.SetActive(val);
            Debug.Log($"   bikses1.SetActive({val}) -> tagad: {bikses1.activeSelf}");
        }
       
        if (bikses2 != null) bikses2.SetActive(val);
        
    }
 
    // Jaku toggle
    public void ToggleJakas(bool val)
    {
        Debug.Log($" ToggleJakas IZSAUKTS! Vērtība: {val}");
       
        if (jakas1 != null)
        {
            jakas1.SetActive(val);
            Debug.Log($"   jakas1.SetActive({val}) -> tagad: {jakas1.activeSelf}");
        }
       
        if (jakas2 != null) jakas2.SetActive(val);
        
    }
}