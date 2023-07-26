using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MoveTest: MonoBehaviour
{
 
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator MovesForward()
    {
        var gameObject = new GameObject();
        var character = gameObject.AddComponent<CharacterController>();
        var player = gameObject.AddComponent<PlayerMotor>();
        yield return new WaitForSeconds(1);
         //
        //var rb = gameObject.AddComponent<Rigidbody>();
        var input = new Vector2(0f, 10f);
        
        player.ProcessMove(input);

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(0.05f);
        float x_t = Vector3.Dot(gameObject.transform.forward, gameObject.transform.position);
        Debug.Log(gameObject.transform.position);
        Debug.Log(gameObject.transform.forward);
        Assert.IsTrue(x_t>0.001f);
    }

    [UnityTest]
    public IEnumerator MovesLeft()
    {
        var gameObject1 = new GameObject();
        var character = gameObject1.AddComponent<CharacterController>();
        var player = gameObject1.AddComponent<PlayerMotor>();
        yield return new WaitForSeconds(1);

        //var rb = gameObject1.AddComponent<Rigidbody>();
        var input = new Vector2(-10f, 0);

        player.ProcessMove(input);

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(0.05f);
        float y_t = Vector3.Dot(gameObject1.transform.right, gameObject1.transform.position);
        Debug.Log(gameObject1.transform.position);
        Debug.Log(gameObject1.transform.forward);
        Assert.IsTrue(y_t < -0.001f);
    }

    [UnityTest] 
    public IEnumerator Jumps()
    {
        //var a = Resources.Load("grndCube") as GameObject
        GameObject.Instantiate(Resources.Load("grndCube") as GameObject, new Vector3(0,-10,0),Quaternion.identity);
        var gameObject1 = new GameObject();
        var character = gameObject1.AddComponent<CharacterController>();
        var player = gameObject1.AddComponent<PlayerMotor>();
        //var col = gameObject1.AddComponent<CapsuleCollider>();
        //var rb = gameObject1.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1);

        //var input = new Vector2(-10f, 0);
        while (!player.isGrounded)
        {
            //Debug.Log(player.isGrounded);
            player.ProcessMove(new Vector2(0, 0));
            //player.Jump();
            yield return new WaitForFixedUpdate();
        }
        Debug.Log(gameObject1.transform.position);
        yield return new WaitForSeconds(1);
        player.Jump();
        player.ProcessMove(new Vector2(0, 0));
        yield return new WaitForFixedUpdate();
        yield return new WaitForSeconds(1);
        //float y_t = Vector3.Dot(gameObject1.transform.up, );
        Debug.Log(gameObject1.transform.position);
        Debug.Log(gameObject1.transform.up);
        Debug.Log(gameObject1.GetComponent<CharacterController>().velocity.y);
        Assert.IsTrue(gameObject1.GetComponent<CharacterController>().velocity.y > 0.1f);
    }
}
