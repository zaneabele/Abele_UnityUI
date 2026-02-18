using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject bean;
    public GameObject teddy;
    public GameObject granny;
    public GameObject car;
    public GameObject toggleLeft;
    public GameObject toggleRight;
    public GameObject imageField;
    public Sprite[] sprites;
    public GameObject rotationSlider;
    public GameObject scaleSlider;


    public void ToggleBean (bool val) {
        bean.SetActive(val);
        toggleLeft.GetComponent<Toggle>().interactable = val;
        toggleRight.GetComponent<Toggle>().interactable = val;
    }

    public void ToggleTeddy (bool val) {
        teddy.SetActive(val);
    }

    public void ToggleGranny (bool val) {
        granny.SetActive(val);
    }

    public void ToggleCar (bool val) {
        car.SetActive(val);
    }

    public void Flip(int val) {
        bean.transform.localScale = new Vector2(val, 1);
    }

    public void ChangeSprite(int val) {
        imageField.GetComponent<Image>().sprite = sprites[val];
    }

    public void Rotate() {
        float currentValue = rotationSlider.GetComponent<Slider>().value;
        imageField.transform.rotation = Quaternion.Euler(0, 0, currentValue * 360);
    }

    public void Scale() {
        float currentValue = scaleSlider.GetComponent<Slider>().value;
        imageField.transform.localScale = new Vector2(1f * currentValue, 1f * currentValue);
    }
}
