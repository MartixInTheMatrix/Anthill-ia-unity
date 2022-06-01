using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antIA : MonoBehaviour
{
    public GameObject Self;
    public Sprite NormalSprite;
    public Sprite WithFoodSprite;
    public Transform house;

    public bool FoundFood;
    public Vector3 FoodPosition;
    private Transform AntTransform;
    private float rotation;
    

    void Start()
    {
        Self.GetComponent<SpriteRenderer>().sprite = NormalSprite;
        AntTransform = Self.GetComponent<Transform>();
        if(Random.Range(1, 2) == 1)
        {
            AntTransform.Rotate(0, 0, Random.Range(0, 180));
        }
        else
        {
            AntTransform.Rotate(0, 0, Random.Range(-180, 0));
        }
        
    }
    void Update()
    {
        if (!FoundFood)
        {
            rotation = Random.Range(AntTransform.rotation.x - 10, AntTransform.rotation.x + 10);
            AntTransform.Translate(0.01f, 0, 0);
            AntTransform.Rotate(0, 0, rotation);
        }else if (FoodPosition.x != 0 && !FoundFood)
        {
            Vector3 directionToMove = FoodPosition - AntTransform.position;
            AntTransform.Rotate(0, 0, 0);       
            directionToMove = directionToMove.normalized * Time.deltaTime * 0.01f;

            float maxDistance = Vector3.Distance(AntTransform.position, FoodPosition);
            AntTransform.position = AntTransform.position + Vector3.ClampMagnitude(directionToMove, maxDistance);
        }
        else
        {
            Vector3 direction = house.position - AntTransform.position;
            float dist = direction.magnitude;
            direction = direction.normalized;
            float move  = 0.01f;
            if (move > dist) move = dist;
            AntTransform.Rotate(0,0,0);
            transform.Translate(direction * move);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // When target is hit
        if(col.gameObject.tag == "food")
        {
            Self.GetComponent<SpriteRenderer>().sprite = WithFoodSprite;
            FoodPosition = AntTransform.position;
            FoundFood = true;
            Debug.Log("Target was Hit!");
        }
        else if(col.gameObject.tag == "border")
        {
            if (AntTransform.rotation.x > 0)
            {
                AntTransform.Rotate(0, 0, -180);
            }
            else
            {
                AntTransform.Rotate(0, 0, 180);
            }
        }else if(col.gameObject.tag == "ant" && FoundFood)
        {
            col.gameObject.GetComponent<antIA>().FoodPosition = FoodPosition;
        }

    }
}
