using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownSystem : MonoBehaviour
{
    //This entire script is inheritance, more or less.
    private readonly List<CooldownData> cooldowns = new List<CooldownData>();

    public void PutOnCooldown(IHasCoolDown cooldown)
    {
        cooldowns.Add(new CooldownData(cooldown));
    }
    private void Update()
    {
        ProcessCooldowns();
    }

    public bool IsOnCooldown(int id)
    {
        foreach (CooldownData cooldown in cooldowns)
        {
            if (cooldown.Id == id)
            {
                return true;
            }
        }
        return false;
    }

    public float GetRemainingDuration(int id)
    {
        foreach (CooldownData cooldown in cooldowns)
        {
            if (cooldown.Id != id)
            {
                continue;
            }
            return cooldown.RemainingTime;
        }
        return 0f;
    }

    private void ProcessCooldowns()
    {
        float deltaTime = Time.deltaTime;

        for (int i = cooldowns.Count - 1; i >= 0; i--)
        {
            if (cooldowns[i].DecrementCooldown(deltaTime))
            {
                cooldowns.RemoveAt(i);
            }
        }
    }
}

public class CooldownData
{
    public CooldownData(IHasCoolDown cooldown)
    {
        Id = cooldown.Id;
        RemainingTime = cooldown.CooldownDuration;
    }

    public int Id { get; }
    public float RemainingTime { get; private set; }

    public bool DecrementCooldown(float deltaTime)
    {
        RemainingTime = Mathf.Max(RemainingTime - deltaTime, 0f);

        return RemainingTime == 0;
    }
}
