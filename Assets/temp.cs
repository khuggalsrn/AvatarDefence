using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class temp : MonoBehaviour
{
    public XRController Lxr;
    public XRController Rxr;
    // Start is called before the first frame update
    void Start()
    {
        // xr = (XRController) GameObject.FindObjectOfType(typeof(XRController));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("XRI_Right_GripButton")){//그립=중지버튼
            Debug.Log("Right1");
            Rxr.SendHapticImpulse(0.7f, 2f);
        }
        if(Input.GetButtonDown("XRI_Left_GripButton")){
            Debug.Log("Left2");
            Lxr.SendHapticImpulse(0.7f, 2f);
        }
        if(Input.GetButton("XRI_Right_TriggerButton")){//검지버튼
            Debug.Log("Right2");
            if(Vector3.Distance(Lxr.gameObject.transform.position,
            Rxr.gameObject.transform.position) < 0.1f){
                // Lxr.SendHapticImpulse(0.1f, 0.001f);
                Rxr.SendHapticImpulse(0.3f,0.001f);
            }
        }
        if(Input.GetButtonDown("XRI_Right_PrimaryButton")){
            Debug.Log("Right3");
        }
    }
}
