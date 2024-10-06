using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Utilities;

namespace CarColector
{
    public class EnemyBuilder
    {
        GameObject enemyPrefab;
        SplineContainer spline;
        GameObject weaponPrefab;
        float speed;

        public EnemyBuilder SetBasePrefab(GameObject prefab)
        {
            enemyPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSpline(SplineContainer spline) 
        {
            this.spline = spline;
            return this;
        }

        public EnemyBuilder SetWeaponPrefab(GameObject Prefab) 
        {
            weaponPrefab = Prefab;
            return this;
        }

        public EnemyBuilder SetSpeed (float speed) 
        {
            this.speed = speed;
            return this;
        }

        public GameObject Build() 
        {
            GameObject instance = GameObject.Instantiate(enemyPrefab);

            SplineAnimate splineAnimate = instance.GetOrAdd<SplineAnimate>(); 
            splineAnimate.Container = spline;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineComponent.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = speed;

            // Weepons

            // Set instance transform to spline start position
            instance.transform.position = (Vector3)spline.EvaluatePosition(0f);
            // if instantiating waves, could set position along the spline in a staggered value 0f to 1f

            return instance;
        }
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
