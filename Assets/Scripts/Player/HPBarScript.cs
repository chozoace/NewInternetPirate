using UnityEngine;
using System.Collections;

public class HPBarScript : MonoBehaviour 
{
    float _maxHealth;
    public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
    float _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

	public void ModifyHealthBar(int newHealth)
    {
        float currentHealthPercent = _currentHealth / _maxHealth;
        float decreaseScale = currentHealthPercent - (newHealth / _maxHealth);
        _currentHealth = newHealth;
        this.gameObject.transform.localScale -= new Vector3(0, decreaseScale, 0);
        this.gameObject.transform.position -= new Vector3(0, .08f, 0);
    }
}
