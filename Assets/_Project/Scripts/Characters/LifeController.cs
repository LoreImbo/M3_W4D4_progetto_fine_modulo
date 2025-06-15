using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _currentHp = 10;
    [SerializeField] private int _maxHp = 10;
    [SerializeField] private bool _fullHpOnStart = true;
    
    public int GetHp() => _currentHp;
    public int GetMaxHp() => _maxHp;

    public void SetHp(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHp);

        if (_currentHp != hp)
        {
            _currentHp = hp;

            if (_currentHp == 0)
            {
                Debug.Log($"Il GameObject {gameObject.name} è sceso a 0 HP!");
                Destroy(gameObject);
                }
            }

        }

    public void SetMaxHp(int maxHp)
    {
        _maxHp = Mathf.Max(1, maxHp);

        SetHp(_maxHp);
    }

    public void AddHp(int amount) => SetHp(_currentHp + amount);

    public void TakeDamage(int damage) => SetHp(_currentHp - damage);

    void Start()
    {
        if (_fullHpOnStart)
        {
            SetMaxHp(_maxHp);
        }
    }
}
