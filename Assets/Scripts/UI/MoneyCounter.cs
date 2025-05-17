using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] TMP_Text Text;

    private void OnEnable()
    {
        PlayerMoney.Instance?.AddActionOnMoneyChanged(SetValue);
    }

    private void SetValue(int moneyValue) 
    {
        Text.text = moneyValue.ToString();
    }

    private void OnDisable()
    {
        PlayerMoney.Instance?.RemoveActionOnMoneyChanged(SetValue);
    }
}
