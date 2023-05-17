using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int Health { get; set; }

    //Temporary solutior for the UI, delete later.
    public static int _Health;

    private void Start()
    {
        Health = MaxHealth;
    }

    private void Update()
    {
        _Health = Health;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
            Destroy(gameObject);
    }
}