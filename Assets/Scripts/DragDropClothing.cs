using UnityEngine;
using UnityEngine.EventSystems;
 
public class DragDropClothing : MonoBehaviour,
    IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform trans;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
   
    [Header("Drop Target")]
    public string targetTag = "Character"; // Uz kā var nolikt (tēls)
   
    [Header("Clothing Info")]
    public string clothingType = "bikses"; // bikses, jakas, utt.
    public int clothingIndex = 1; // 1,2,3
   
    [Header("Sound")]
    [SerializeField] private SFXScript sfxScript; // Tava SFXScript atsauce
    [SerializeField] private bool enableSounds = true; // Iespēja izslēgt skaņas
   
    // Skaņu indeksi (pielāgo pēc vajadzības)
    private const int SOUND_CLICK = 0;
    private const int SOUND_DRAG = 1;
    private const int SOUND_SUCCESS = 2;
    private const int SOUND_FAIL = 3;
   
    // Sākotnējā pozīcija
    private Vector2 originalPosition;
    private Transform originalParent;
   
    void Start()
    {
        trans = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
       
        // Pievieno CanvasGroup ja nav
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
       
        // Atcerēties sākotnējo pozīciju
        originalPosition = trans.anchoredPosition;
        originalParent = transform.parent;
       
        // Mēģina atrast SFXScript ja nav norādīts
        if (sfxScript == null && enableSounds)
        {
            sfxScript = FindFirstObjectByType<SFXScript>();
            if (sfxScript == null)
                Debug.LogWarning("Nav SFXScript! Skaņas netiks atskaņotas.");
        }
       
        Debug.Log($"DragDropClothing start: {clothingType} {clothingIndex}");
    }
   
    // ĒRTA SKAŅAS FUNKCIJA
    private void PlaySound(int soundIndex)
    {
        if (!enableSounds) return; // Viegli izslēgt
        if (sfxScript == null) return;
       
        sfxScript.PlaySFX(soundIndex);
        Debug.Log($"Atskaņo skaņu {soundIndex}");
    }
 
    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log($"🖱️ Klikšķis uz {clothingType} {clothingIndex}");
        PlaySound(SOUND_CLICK); // Klikšķa skaņa
       
        // Paceļ objektu virs citiem
        transform.SetAsLastSibling();
    }
 
    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log($"Sāk vilkt {clothingType} {clothingIndex}");
       
        // Padara objektu caurspīdīgāku velkot
        canvasGroup.alpha = 0.8f;
       
        // Ļauj tam iet cauri raycast (lai var nolaist uz tēla)
        canvasGroup.blocksRaycasts = false;
       
        // Vilkšanas sākuma skaņa
        PlaySound(SOUND_DRAG);
    }
 
    public void OnDrag(PointerEventData data)
    {
        // Pārvieto objektu peles pozīcijā
        trans.anchoredPosition += data.delta / canvas.scaleFactor;
       
       
    }
 
    public void OnEndDrag(PointerEventData data)
    {
        Debug.Log($"Beidz vilkt {clothingType} {clothingIndex}");
       
        // Atjauno normālu izskatu
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
       
        // Pārbauda vai nolaists uz tēla
        GameObject droppedOn = data.pointerEnter;
       
        if (droppedOn != null && droppedOn.CompareTag(targetTag))
        {
            // NOLAISTS UZ TĒLA!
            Debug.Log($"{clothingType} {clothingIndex} nolaists uz tēla!");
           
            // Pievienojies tēlam kā bērns
            transform.SetParent(droppedOn.transform);
           
            // Veiksmes skaņa
            PlaySound(SOUND_SUCCESS);
           
            // Iespējams, pozicionē uz konkrētu vietu
            // trans.anchoredPosition = Vector2.zero;
        }
        else
        {
            // NOLAISTS ĀRPUS TĒLA - atgriežas atpakaļ
            Debug.Log($"{clothingType} {clothingIndex} nolaists ārpus tēla - atgriežas");
           
            transform.SetParent(originalParent);
            trans.anchoredPosition = originalPosition;
           
            // Kļūdas skaņa
            PlaySound(SOUND_FAIL);
        }
    }
   
    // Lai atiestatītu uz sākotnējo pozīciju
    public void ResetPosition()
    {
        transform.SetParent(originalParent);
        trans.anchoredPosition = originalPosition;
    }
}
 