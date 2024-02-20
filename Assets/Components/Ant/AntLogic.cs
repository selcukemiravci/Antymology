using UnityEngine;

namespace Components.Ant
{
    // Defines settings for ants, including health and behavior parameters.
    [CreateAssetMenu(fileName = "Ants", menuName = "Simulation/Ants", order = 1)]
    public class AntSettings : ScriptableObject
    {
        [Tooltip("Health that each ant starts at")]
        public float initialHealth = 100f;

        [Tooltip("Amount by which ants health decreases every timestep")]
        public float healthDecreaseAmount = 1f;

        [Tooltip("Amount by which ants health increases after eating mulch")]
        public float healthIncreaseAmount = 5f;

        [Tooltip("Amount of health an ant gives to another ant")]
        public float healthDonationAmount = 2f;
        
        [Tooltip("Time step duration for each simulation tick")]
        public float timeStep = 1f;
    }

    // Simplified AntLogic responsible for basic ant decision-making.
    public class AntLogic : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float turnSpeed = 200f;

        private void Update()
        {
            RandomMovement();
        }

        private void RandomMovement()
        {
            if (Random.Range(0, 2) == 0)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up, Random.Range(-1f, 1f) * turnSpeed * Time.deltaTime);
            }
        }
    }

    // Simplified AntHouse class focusing on essential ant functionality.
    public class AntHouse : MonoBehaviour
    {
        [SerializeField]
        public AntSettings antSettings;

        private float health;

        private void Awake()
        {
            // Add AntLogic component to handle decision-making.
            gameObject.AddComponent<AntLogic>();
        }

        private void Start()
        {
            health = antSettings.initialHealth;
        }

        private void Update()
        {
            DepleteHealthOnTick();
        }

        private void DepleteHealthOnTick()
        {
            // Health depletes over time. This could be expanded with more complex interactions.
            health -= antSettings.healthDecreaseAmount * antSettings.timeStep;
            if (health <= 0)
            {
                Die();
            }
        }

        public void IncrementHealth(float amount)
        {
            health += amount;
            health = Mathf.Clamp(health, 0, antSettings.initialHealth);
        }

        private void Die()
        {
            Destroy(gameObject); // Destroy the ant when its health reaches 0.
        }

        // Additional methods for health and interaction can be added here, including handling health donation.
    }
}
