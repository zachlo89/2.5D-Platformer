using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _targetA, _targetB;
    [SerializeField] private float _speed = 2.0f;
    // create a var to tell switch from tarA to tarB
    [SerializeField] private bool _isSwitch;

    void FixedUpdate()
    {
        /**
         * curr tform val; transform.position = Vector3.Movetowards(curr pos, target, max dist delta aka speed)
         * go to point b
         * if at point b
         * go to point a
         * if at point a 
         * go to point b
         * */
        if (_isSwitch == false)
        {
            // move to tarB
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        }
        else if (_isSwitch == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }

        // when turn _isSwitch from true to false
        if (transform.position == _targetB.position)
        {
            _isSwitch = true;
        }
        else if (transform.position == _targetA.position)
        {
            _isSwitch = false;
        }
    }

    /**
     * create collision detection
     * if we collide with player
     * tk player parent and assign it to this GO
     * 
     * exit collision
     * chk if player exited
     * tk player parent = null and assign to null so it's free to move off platform
     **/


    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // tell player has new tform and it's this obj
            // assign the parent to the tform this script attached to aka moving platform
            other.transform.parent = this.transform; 
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
