using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class BlockButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
 
    public bool buttonPressed;

    public GameObject Player;
    
    public void OnPointerDown(PointerEventData eventData)
    {

        Player.GetComponent<Block>().PlayerBlock(true);

    }
    
    public void OnPointerUp(PointerEventData eventData)
    {

        Player.GetComponent<Block>().PlayerBlock(false);

    }
}