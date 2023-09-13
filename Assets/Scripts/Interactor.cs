using System;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public LayerMask layer = 8;
    private Interactable interactable;
    private Events eventSystem;

    private void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<Events>();
    }

    private void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 4))
        {
            if(hit.collider.GetComponent<Interactable>() != false)
            {
                if (interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                }
                if ((Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Mouse0)) && !eventSystem.UIup && eventSystem.canSwitch)
                {
                    interactable.onInteract.Invoke();
                }
            }
        }
    }
}
