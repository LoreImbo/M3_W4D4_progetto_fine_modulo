using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private GameObject weaponPrefab;  // Prefab dell'arma da instanziare
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Transform weaponHolder = other.transform.Find("WeaponHolder");

            if (weaponHolder.childCount > 0)
            {
                foreach (Transform child in weaponHolder)
                {
                    Destroy(child.gameObject);
                }
            }

            Instantiate(weaponPrefab, weaponHolder.position, Quaternion.identity, weaponHolder);

            Destroy(gameObject);
        }
    }
}

