using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHP;

    public int CurrentHP { get; private set; }
    public int MaxHP => _maxHP;

    private void Start()
    {
        CurrentHP = _maxHP;
    }

    public void Heal(int healQuantity)
    {
        CurrentHP += healQuantity;

        if (CurrentHP > _maxHP)
        {
            CurrentHP = _maxHP;
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;

        if (CurrentHP < 0)
        {
            CurrentHP = 0;
        }
    }
}
