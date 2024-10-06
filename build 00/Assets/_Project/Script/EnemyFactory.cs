using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace CarColector
{
    public class EnemyFactory
    {
       public GameObject CreateEnemy(EnemyType enemyType, SplineContainer spline) 
        {
            EnemyBuilder builder = new EnemyBuilder()
                .SetBasePrefab(enemyType.enemyPrefab)
                .SetSpline(spline)
                .SetSpeed(enemyType.speed);

            // weapons

            return builder.Build();
        }

        // More factory methods, for example enemies theat not follow a spline
    }
}
