using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasCoolDown
{
    //ENCAPSULATION
    int Id { get; }
    float CooldownDuration { get; }
}
