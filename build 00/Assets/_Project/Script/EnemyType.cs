using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarColector
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "CarColector/EnemyType", order = 0)]
    public class EnemyType : ScriptableObject
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
