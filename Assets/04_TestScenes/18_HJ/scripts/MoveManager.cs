using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void movePlayer(GameObject player, Direction dir)
    {

        changeRotation(player, dir);

    }

    public void changeRotation(GameObject player, Direction dir)
    {

        int rotation = 0;

        switch (dir)
        {
            case Direction.UP: rotation = 0; break;
            case Direction.DOWN: rotation = 180; break;
            case Direction.RIGHT: rotation = 90; break;
            case Direction.LEFT: rotation = -90; break;
        }

        Tween tween = player.transform.DORotate(new Vector3(0, rotation, 0), 1f);

        tween.OnComplete(() =>
        {
            StartCoroutine(Move(player, dir));
        });
    }

    public IEnumerator Move(GameObject player, Direction dir)
    {

        switch (dir)
        {
            case Direction.UP: break;

        }
        Vector3 dest = player.transform.position + player.transform.forward;
        float dist = Vector3.Distance(player.transform.position, dest);
        float speed = 4 * Time.deltaTime;

        while (dist >= 0.000001)
        {
            dist = Vector3.Distance(player.transform.position, dest);
            if (dist > speed) player.transform.Translate(player.transform.forward * speed);
            else player.transform.Translate(player.transform.forward * dist);
            yield return 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log(Direction.UP);
    }
}
public enum Direction
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}