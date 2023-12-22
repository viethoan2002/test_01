using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckWall : CheckPosition
{
    public Transform groundChecck;
    public Vector2 rectangle;

    public LayerMask wallMask;

    public override bool Checked()
    {
        if (Physics2D.OverlapBox(groundChecck.position, rectangle, wallMask))
        {
            Collider2D collider = Physics2D.OverlapBox(groundChecck.position, rectangle, wallMask);
            if ((wallMask.value & 1 << collider.gameObject.layer) > 0)
                return false;
            else
                return true;
        }
        else
            return true;
    }
}
