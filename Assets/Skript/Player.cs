using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHP;

    private int _currentHP;

    public event UnityAction<int, int> HPChanged;

    private void Start()
    {
        _currentHP = _maxHP;
        _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
    }

    public void Heal(int healQuantity)
    {
        _currentHP += healQuantity;
        _currentHP = Math.Clamp(_currentHP, 0, _maxHP);
        HPChanged?.Invoke(_currentHP, _maxHP);
    }

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;
        _currentHP = Math.Clamp(_currentHP, 0, _maxHP);
        HPChanged?.Invoke(_currentHP, _maxHP);
    }
}
