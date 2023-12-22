using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : CheckPosition
{
    public Transform groundChecck;
    public Vector2 rectangle;

    public LayerMask groundMask;

    public override bool Checked()
    {
        if (Physics2D.OverlapBox(groundChecck.position, rectangle, groundMask))
        {
            Collider2D collider = Physics2D.OverlapBox(groundChecck.position, rectangle, groundMask);
            if ((groundMask.value & 1 << collider.gameObject.layer) > 0)
                return true;
            else
                return false;
        }
        else
            return false;
    }
}
