using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour 
{

    public float speed = 1;
    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    public Direction dir = Direction.Right;


    private float _heightCamera;
    private float _widthCamera;

    private Vector3 _positionCam;
    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;
        _heightCamera = 2f * _cam.orthographicSize;
        _widthCamera = _heightCamera * _cam.aspect;
    }

    void Update ()
    {
        foreach (var item in sprites)
        {
            if(dir == Direction.Left)
            {
                if (item.transform.position.x + item.bounds.size.x / 2 < _cam.transform.position.x - _widthCamera / 2)
                {
                    SpriteRenderer sprite = sprites[0];
                    foreach (var i in sprites)
                    {
                        if (i.transform.position.x > sprite.transform.position.x)
                            sprite = i;
                    }

                    item.transform.position = new Vector2((sprite.transform.position.x + (sprite.bounds.size.x / 2) + (item.bounds.size.x / 2)), sprite.transform.position.y);
                }
            }
            else if (dir == Direction.Right)
            {
                if (item.transform.position.x - item.bounds.size.x / 2 > _cam.transform.position.x + _widthCamera / 2)
                {
                    SpriteRenderer sprite = sprites[0];
                    foreach (var i in sprites)
                    {
                        if (i.transform.position.x < sprite.transform.position.x)
                            sprite = i;
                    }

                    item.transform.position = new Vector2((sprite.transform.position.x - (sprite.bounds.size.x / 2) - (item.bounds.size.x / 2)), sprite.transform.position.y);
                }
            }
            else if(dir == Direction.Down)
            {
                if (item.transform.position.y + item.bounds.size.y / 2 < _cam.transform.position.y - _heightCamera / 2)
                {
                    SpriteRenderer sprite = sprites[0];
                    foreach (var i in sprites)
                    {
                        if (i.transform.position.y > sprite.transform.position.y)
                            sprite = i;
                    }

                    item.transform.position = new Vector2(sprite.transform.position.x, (sprite.transform.position.y + (sprite.bounds.size.y / 2) + (item.bounds.size.y / 2)));
                }
            }
            else if (dir == Direction.Up)
            {
                if (item.transform.position.y - item.bounds.size.y / 2 > _cam.transform.position.y + _heightCamera / 2)
                {
                    SpriteRenderer sprite = sprites[0];
                    foreach (var i in sprites)
                    {
                        if (i.transform.position.y < sprite.transform.position.y)
                            sprite = i;
                    }

                    item.transform.position = new Vector2(sprite.transform.position.x,(sprite.transform.position.y - (sprite.bounds.size.y / 2) - (item.bounds.size.y / 2)));
                }
            }


            if (dir == Direction.Left)
                item.transform.Translate(new Vector2(Time.deltaTime * speed * -1, 0));
            else if (dir == Direction.Right)
                item.transform.Translate(new Vector2(Time.deltaTime * speed, 0));
            else if (dir == Direction.Down)
                item.transform.Translate(new Vector2(0,Time.deltaTime * speed * -1));
            else if (dir == Direction.Up)
                item.transform.Translate(new Vector2(0, Time.deltaTime * speed));
        }

    }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}
