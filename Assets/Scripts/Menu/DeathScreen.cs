using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{

    #region Singleton

    public static DeathScreen instance;

    void Awake()
    {
        instance = this;
    }
    #endregion    

    public GameObject ResetButton;

    public GameObject ExitButton;

    public GameObject DeadImage;

    private Vector3 vel = Vector3.zero;
    private Vector3 vel2 = Vector3.zero;
    private Vector3 vel3 = Vector3.zero;
    private bool DoAnimation = false;

    public void DoDeathScreen()
    {
        DoAnimation = true;
        print("DoAnimation");
    }

    private void Update()
    {
        if (!DoAnimation)
            return;

        print("update");

        Vector3 SmothPosRB = Vector3.SmoothDamp(ResetButton.transform.position, new Vector3(ResetButton.transform.position.x,200,ResetButton.transform.position.z), ref vel, 2);
        ResetButton.transform.position = SmothPosRB;

        Vector3 SmothPosDI = Vector3.SmoothDamp(DeadImage.transform.position, new Vector3(DeadImage.transform.position.x,300,DeadImage.transform.position.z), ref vel2, 2);
        DeadImage.transform.position = SmothPosDI; 
     
        Vector3 SmothPosEB = Vector3.SmoothDamp(ExitButton.transform.position, new Vector3(ExitButton.transform.position.x,100,ExitButton.transform.position.z), ref vel3, 2);
        ExitButton.transform.position = SmothPosEB; 

    }

}
