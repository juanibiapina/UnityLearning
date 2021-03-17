using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Levels
{
    static int level = 1;

    static AsteroidSpec[][] specs = new AsteroidSpec[][] {
        new AsteroidSpec[] {
            new AsteroidSpec(4, 0, 0, null),
        },
        new AsteroidSpec[] {
            new AsteroidSpec(4, 2, 2, new AsteroidSpec(2, 4, 0, null)),
            new AsteroidSpec(4, 2, 2, new AsteroidSpec(2, 4, 0, null)),
        },
        new AsteroidSpec[] {
            new AsteroidSpec(4, 2, 2, new AsteroidSpec(2, 4, 2, new AsteroidSpec(1, 8, 0, null))),
            new AsteroidSpec(4, 2, 2, new AsteroidSpec(2, 4, 2, new AsteroidSpec(1, 8, 0, null))),
        },
    };

    public static void Reset() {
        level = 1;
    }
    
    public static AsteroidSpec[] SpecsForCurrentLevel()
    {
        return specs[level - 1];
    }

    public static void NextLevel() {
        level++;
    }

    public static int Level() {
        return level;
    }
}
