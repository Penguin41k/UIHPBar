using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    [SerializeField] private UnityEvent<int, int> _hpChanged;

    private int _currentHP;

    private void Start()
    {
        _currentHP = _maxHP;
    }

    public void Heal(int healQuantity)
    {
        _currentHP += healQuantity;

        if (_currentHP > _maxHP)
        {
            _currentHP = _maxHP;
        }

        _hpChanged?.Invoke(_currentHP, _maxHP);
    }

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;

        if (_currentHP < 0)
        {
            _currentHP = 0;
        }

        _hpChanged?.Invoke(_currentHP, _maxHP);
    }
}
