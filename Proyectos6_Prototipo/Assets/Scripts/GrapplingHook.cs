using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    DistanceJoint2D hook;
    Vector3 targetedPos;
    RaycastHit2D hit;
    LineRenderer lineHook;
    [SerializeField] float distanceToHook = 15;
    [SerializeField] LayerMask mask;

    private void Start()
    {
        hook = GetComponent<DistanceJoint2D>();
        lineHook = GetComponent<LineRenderer>();
        hook.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !GetComponent<Life_Base>().dead && GetComponent<Skills_and_Tools>().hasHooK())
        {
            if (!hook.isActiveAndEnabled)
            {
                targetedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetedPos.z = 0;

                hit = Physics2D.Raycast(transform.position, targetedPos - transform.position, distanceToHook, mask);
                if(hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    Debug.DrawRay(transform.position, targetedPos - transform.position, Color.green, 5);
                    hook.enabled = true;
                    hook.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                    hook.distance = Vector2.Distance(transform.position, hit.point);
                    Vector3 pos = hit.collider.gameObject.transform.position;
                    lineHook.SetPosition(1, new Vector3(pos.x, pos.y, -0.5f));
                }
            }
            else
            {
                hook.enabled = false;
                Vector3 pos = this.transform.position;
                lineHook.SetPosition(1, new Vector3(pos.x, pos.y, -0.5f));
                lineHook.SetPosition(0, new Vector3(pos.x, pos.y, -0.5f));
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
