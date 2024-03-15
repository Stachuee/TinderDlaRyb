using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimObserver 
{
    public void ChangeAnim(AnimStateController.AnimState newAnimState);
}
