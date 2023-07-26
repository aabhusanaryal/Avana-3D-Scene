using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;  
using UnityEngine;
using UnityEngine.TestTools;

public class tests : MonoBehaviour
{
    // Start is called before the first frame update
    // A Test behaves as an ordinary method
    [Test]
    public void testtest()
    {
        Assert.AreEqual(new Vector3(90.0f, 0, 0), PlayerShoot.BulletRot);
        // Use the Assert class to test conditions
    }
}
