using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    // Manages the ant simulation, including spawning ants and ticking simulation time.
    public class SimulationManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject antPrefab; // Prefab for instantiating ants. Assign this in the Unity Editor.

        [SerializeField]
        private SimulationSettings simulationSettings; // Simulation settings as a ScriptableObject. Assign this in the Unity Editor.

        private List<GameObject> ants = new List<GameObject>(); // List to keep track of all spawned ants.
        private float tickTimer; // Timer to track time between simulation ticks.

        private void Start()
        {
            // Generate the initial population of ants based on the simulation settings.
            GenerateAnts(simulationSettings.NumberOfAnts);
        }

        private void Update()
        {
            // Increment the tick timer based on the elapsed time since the last frame.
            tickTimer += Time.deltaTime;
            
            // Check if the tick timer has exceeded the interval defined in simulation settings.
            if (tickTimer >= simulationSettings.SimulationTickInterval)
            {
                tickTimer = 0f; // Reset the tick timer for the next interval.
            }
        }

        // Generates a specified number of ants and places them in the world.
        private void GenerateAnts(int numAnts)
        {
            for (int i = 0; i < numAnts; i++)
            {
                SpawnAnt();
            }
        }

        // Spawns a single ant at a random position.
        private void SpawnAnt()
        {
            Vector3 spawnPosition = GetSpawnPosition(); // Determine a random spawn position.
            GameObject ant = Instantiate(antPrefab, spawnPosition, Quaternion.identity); // Instantiate the ant prefab at the spawn position.
            ants.Add(ant); // Add the new ant to the list of ants.
        }

        // Determines a random spawn position for an ant.
        private Vector3 GetSpawnPosition()
        {
            // Example logic to determine a random position within a specified range.
            // Adjust this method to suit the specifics of your game's world, such as terrain and boundaries.
            int x = Random.Range(1, 100 - 1); // Random x position within a predefined range.
            int z = Random.Range(1, 100 - 1); // Random z position within a predefined range.
            Vector3 spawnPosition = new Vector3(x, 0, z); // Construct the spawn position vector, assuming a flat terrain at y = 0.

            // Additional checks for spawn validity can be added here, such as avoiding spawning inside obstacles.

            return spawnPosition;
        }

        // Removes an ant from the simulation and destroys its GameObject.
        public void KillAnt(GameObject ant)
        {
            ants.Remove(ant); // Remove the ant from the list of ants.
            Destroy(ant); // Destroy the ant GameObject.
        }
    }

    // ScriptableObject for storing simulation settings, such as tick interval and number of ants.
    [CreateAssetMenu(fileName = "SimSettings", menuName = "Simulation/SimSettings", order = 0)]
    public class SimulationSettings : ScriptableObject
    {
        public float SimulationTickInterval = 1.0f; // Time in seconds between simulation ticks.
        public int NumberOfAnts = 10;

         // The following settings are placeholders for future features related to evolution and mutation.
        public int TicksUntilEvolution; // Number of ticks until a new generation is created.
        public float ProbabilityOfMutation; // Chance of mutation occurring.
        public float MutationPercentage; // Maximum percentage a gene can be mutated.
        public int NumberOfNewOffspring; // Number of new ants to create each generation.
    }
}