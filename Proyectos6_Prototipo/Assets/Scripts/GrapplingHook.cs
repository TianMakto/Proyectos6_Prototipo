using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    DistanceJoint2D hook;
    Vector3 targetedPos;
    RaycastHit2D hit;
    [SerializeField] LineRenderer lineHook;
    [SerializeField] float distance = 10;
    [SerializeField] LayerMask mask;

    private void Start()
    {
        hook = GetComponent<DistanceJoint2D>();
        hook.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!hook.isActiveAndEnabled)
            {
                targetedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetedPos.z = 0;

                hit = Physics2D.Raycast(transform.position, targetedPos - transform.position, distance, mask);
                if(hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    Debug.DrawRay(transform.position, targetedPos - transform.position, Color.green, 5);
                    hook.enabled = true;
                    hook.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                    hook.distance = Vector2.Distance(transform.position, hit.point);
                    lineHook.SetPosition(1, hit.collider.gameObject.transform.position);
                }
            }
            else
            {
                hook.enabled = false;
                lineHook.SetPosition(1, this.transform.position);
                lineHook.SetPosition(0, this.transform.position);
            }
        }

        if (HookActive())
        {
            lineHook.SetPosition(0, this.transform.position);
        }
    }

    public bool HookActive()
    {
        if (!hook.isActiveAndEnabled)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
