using UnityEngine;
using UnityEngine.InputSystem;

public class scButtonCheck : MonoBehaviour {
    public GameObject normalButton, longButton;

    public bool isButtonHover;

    private void Update(){
        if(normalButton.GetComponent<ScHooverImage>().isHoovered || longButton.GetComponent<ScHooverImage>().isHoovered) {
            isButtonHover =true;
        }
        else {
            isButtonHover =false;
        }
    }

    public void Click(InputAction.CallbackContext ctx) {
        if (ctx.performed){
            if( !isButtonHover  ) {
                ScTimerN.Instance.RemoveTime(300f);
            }
        }
    }



}
