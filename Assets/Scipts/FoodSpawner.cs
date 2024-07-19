using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject food;
    private GameObject _mainObject;

    private void OnEnable()
    {
        EatFood.instance += GenericFood;

    }
    void Start()
    {
        GenericFood();
        
    }

    
    private void GenericFood()
    {
        Vector3 RandomPosition = new Vector3(Random.Range(-8, 9) + 0.5f, Random.Range(-4, 5) + 0.5f,0);
        if (!Physics.CheckSphere(RandomPosition, 0.5f))
        {
            _mainObject = Instantiate(food, RandomPosition, Quaternion.identity);
        }
        else
        {
            GenericFood();
        }
        
    }

    private void OnDisable()
    {
        EatFood.instance -= GenericFood;
    }
}
