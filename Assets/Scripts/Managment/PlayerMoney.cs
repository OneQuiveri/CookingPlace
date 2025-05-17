using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : Singleton<PlayerMoney>
{
    private int money;
    public int Money 
    {
        get
        {
            return money;
        }
    }

    private List<Action<int>> actionsConteiner = new List<Action<int>>();

    private Action<int> OnMoneyChanged;

    private void Start()
    {
        Instance.AddMoney(100);
    }

    public void AddActionOnMoneyChanged(Action<int> onMoneyChanged) 
    {
        actionsConteiner.Add(onMoneyChanged);
        OnMoneyChanged += onMoneyChanged;
    }

    public void RemoveActionOnMoneyChanged(Action<int> onMoneyChanged) 
    {
        actionsConteiner.Remove(onMoneyChanged);
        OnMoneyChanged -= onMoneyChanged;
    }

    public void SetMoney(int value) 
    {
        int targetValue = Mathf.Max(0, value);
        money = targetValue;
        OnMoneyChanged?.Invoke(money);
    }

    public void AddMoney(int value) 
    {
        money += value;
        OnMoneyChanged?.Invoke(money);
    }

    public void ReduceMoney(int value) 
    {
        int targetValue = Mathf.Max(0, money - value);
        money = targetValue;
        OnMoneyChanged?.Invoke(money);
    }

    protected override void OnDestroy()
    {
        foreach (var action in actionsConteiner) 
        {
            OnMoneyChanged -= action;
        }
        base.OnDestroy();
    }
}
