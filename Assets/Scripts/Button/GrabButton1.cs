using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class GrabButton1 : MonoBehaviour, IPointerDownHandler {
 
    public bool buttonPressed;

    private GameObject _Obj;

    public GameObject Player;

    private void Start()
    {

        gameObject.SetActive(false);

    }
    
    public void OnPointerDown(PointerEventData eventData)
    {

        _Obj.GetComponent<Interactable>().Interact();

    }

    public void GrabButton1SetActive(bool b)
    {

        gameObject.SetActive(b);

    }

    public void SetObject(GameObject Obj)
    {

        _Obj = Obj;

    }    
    private void Update()
    {
        if (_Obj == null)
        {
            gameObject.SetActive(false);
        }
    }
}