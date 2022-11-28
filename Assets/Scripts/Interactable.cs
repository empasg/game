
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1.0f;

    public GameObject player;

    public GameObject GrabButton;

    private bool AlredySetted;

    public virtual void Interact()
    {



    }

    private void Update()
    {

        float distance = Vector3.Distance(player.transform.position,transform.position);
        if (distance <= radius)
        {
            GrabButton.GetComponent<GrabButton1>().SetObject(gameObject);
            GrabButton.SetActive(true);
            AlredySetted = false;

        }
        else if (AlredySetted == false)
        {
            GrabButton.SetActive(false);
            AlredySetted = true;
        }

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,radius);

    }

}
