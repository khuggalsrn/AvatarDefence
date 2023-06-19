using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowHand : MonoBehaviour
{
    public XRController BowXr;
    public XRController ArrowXr;
    public GameObject ArrowXrObject;
    public GameObject Arrow;
    bool HoldingArrow;
    float Force;
    float Time;
    // Start is called before the first frame update
    void Start()
    {
        HoldingArrow=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("XRI_Right_TriggerButton")){//검지버튼
            if(Vector3.Distance(BowXr.gameObject.transform.position,
            ArrowXr.gameObject.transform.position) < 0.2f){
                HoldingArrow = true;
            }
        }
        if(Input.GetButtonUp("XRI_Right_TriggerButton")){//검지버튼
            HoldingArrow = false;
            HoldoutArrowHaptic();
            GameObject arrow = Instantiate(Arrow,gameObject.transform.position,gameObject.transform.rotation);
            arrow.GetComponent<Rigidbody>().velocity =
            new Vector3
            (ArrowXrObject.transform.position.x - transform.position.x,
             ArrowXrObject.transform.position.y - transform.position.y,
             ArrowXrObject.transform.position.z - transform.position.z);
        }
        if (HoldingArrow){
            HoldingArrowHaptic();
        }
    }
    void HoldingArrowHaptic(){
        ArrowXr.SendHapticImpulse(0.1f,0.001f);
        BowXr.SendHapticImpulse(0.3f,0.001f);
    }
    void HoldoutArrowHaptic(){
        ArrowXr.SendHapticImpulse(1f,0.001f);
        BowXr.SendHapticImpulse(1f,0.1f);
    }
}
