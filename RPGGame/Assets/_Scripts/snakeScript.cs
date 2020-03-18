using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeScript : MonoBehaviour
{
    //********************************SNAKE MOVEMENT****************************************8
    public GameObject snake;
    public GameObject snake1;
    public GameObject snake2;
    public GameObject snake3;
    public GameObject snake4;
    public GameObject snake5;
    private Vector2 _move;
    private bool _hasMoved = false;
    private int _count = 0;
    private int _num=0;

    //*****************************TAIL PROJECTILE***********************************************
    public Rigidbody2D tailProjRB;
    public float tailProjSpeed = 15f;
    private GameObject _tailProj;
    private Vector3 _tailProjMove;    
    private bool _tailReturn = false;

    //********************************HEAD PROJECTILE*********************************************
    public Rigidbody2D headProjRB;
    private GameObject _headProj;
    private Vector3 [] _headProjMove;    
    private int _paraPosCount=0;
    private bool _paraReturn = false;

    //**********************************MISC*************************************************
    public GameObject hero;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        _move.x =3;
        hero = PlayerSingleton.player;
    }

    // Update is called once per frame
    void Update()
    {
        if(_tailReturn == false && _paraReturn ==false)
        {
            if(Time.frameCount%5 ==0 && _hasMoved == false)
            {
                snake5.transform.position = snake4.transform.position;
                snake4.transform.position = snake3.transform.position;
                snake3.transform.position = snake2.transform.position;
                snake2.transform.position = snake1.transform.position;
                snake1.transform.position = snake.transform.position;
                snake.transform.position = new Vector3(snake.transform.position.x + _move.x,snake.transform.position.y + _move.y,0);
                _hasMoved = true;
                _count++;
            }

            if(Time.frameCount%5 ==1)
            {
                _hasMoved = false;
            }

            switch(_num)
            {
                case 0:
                if(_count == 7 && _move.x==3)
                {
                    _count = 0;
                    _move.y = _move.x * -1;
                    _move.x = 0;
                    _num++;
                }
                break;

                case 1:
                if(_count == 5 && _move.y==-3)
                {
                    _count = 0;
                    _move.x = _move.y;
                    _move.y = 0;
                    _num++;
                }
                break;

                case 2:
                if(_count == 7 && _move.x==-3)
                {
                    _count = 0;
                    _move.y = _move.x * -1;
                    _move.x = 0;
                    _num++;
                }
                break;

                case 3:
                if(_count == 5 && _move.y==3)
                {
                    _count = 0;
                    _move.x = _move.y;
                    _move.y = 0;
                    _num = 0;
                }
                break;
            }
        }

    }
    void FixedUpdate() 
    {
        
        if(Time.fixedTime%5 == 0)
        {
            if(_paraReturn == false && ((hero.transform.position.x > snake5.transform.position.x + 2 && hero.transform.position.x < snake.transform.position.x -2) || (hero.transform.position.x > snake.transform.position.x+2 && hero.transform.position.x < snake5.transform.position.x-2)))
            {
                _paraReturn = true;
                _headProj = Instantiate(prefab);
                _headProj.transform.position = snake.transform.position;
                _headProjMove = parabolicCoordinates(snake.transform.position,hero.transform.position,snake5.transform.position,(snake.transform.position.x > snake5.transform.position.x)?-1:1);
                snake5.SetActive(false);
                headProjRB = _headProj.GetComponent<Rigidbody2D>();
            }
            else
            {
            //Creates the projectile, sets the 5th block to inactive
            _tailProj = Instantiate(prefab);
            _tailProj.transform.position = snake5.transform.position;
            snake5.SetActive(false);
            _tailProjMove = hero.transform.position - _tailProj.transform.position;
            tailProjRB = _tailProj.GetComponent<Rigidbody2D>();
            }
        }
        if(_tailProj !=null)
        {
            tailProjRB.MovePosition(tailProjRB.position + (Vector2)_tailProjMove / unitVector(_tailProjMove) * tailProjSpeed * Time.fixedDeltaTime);
            if(_tailProj.transform.position.y > 10 || _tailProj.transform.position.y < -8 || _tailProj.transform.position.x > 8 || _tailProj.transform.position.x < -17)
            {
                //Triggers the return of the projectile
                _tailReturn = true;
                tailProjSpeed = 30;
            }
            if(_tailReturn == true)
            {
                _tailProjMove = snake5.transform.position - _tailProj.transform.position;
                if(_tailProj.transform.position.x > snake5.transform.position.x-1 && _tailProj.transform.position.x < snake5.transform.position.x+1 && _tailProj.transform.position.y < snake5.transform.position.y+1 && _tailProj.transform.position.y > snake5.transform.position.y -1)
                {
                    //When projectile disappears, destroy proj
                    Destroy(_tailProj);
                }
            }
        }
        else if(snake5.activeSelf == false && _paraReturn == false)
        {
            //When projectile disappers, spawn tail
            snake5.SetActive(true);
            _tailReturn = false;
            tailProjSpeed = 15;
        }
        if(_paraReturn == true)
        {
            headProjRB.MovePosition(_headProjMove[_paraPosCount]);
            if(_headProj.transform.position.x == _headProjMove[_paraPosCount].x)
            {
                _paraPosCount++;
            }
            if(_headProj.transform.position.x > snake5.transform.position.x-1 && _headProj.transform.position.x < snake5.transform.position.x+1 && _headProj.transform.position.y < snake5.transform.position.y+1 && _headProj.transform.position.y > snake5.transform.position.y -1 && _paraReturn ==true)
            {
                snake5.SetActive(true);
                Destroy(_headProj);
                _paraReturn = false;
                _paraPosCount = 0;
            }
        }


        //Tail Proj By iteself
        /*
        if(Time.fixedTime%5 == 0)
        {
            //Creates the projectile, sets the 5th block to inactive
            _tailProj = Instantiate(prefab);
            _tailProj.transform.position = snake5.transform.position;
            snake5.SetActive(false);
            _tailProjMove = hero.transform.position - _tailProj.transform.position;
            tailProjRB = _tailProj.GetComponent<Rigidbody>();
        }
        if(_tailProj !=null)
        {
            tailProjRB.MovePosition(tailProjRB.position + _tailProjMove / unitVector(_tailProjMove) * tailProjSpeed * Time.fixedDeltaTime);
            if(_tailProj.transform.position.y > 10 || _tailProj.transform.position.y < -8 || _tailProj.transform.position.x > 8 || _tailProj.transform.position.x < -17)
            {
                //Triggers the return of the projectile
                _tailReturn = true;
                tailProjSpeed = 30;
            }
            if(_tailReturn == true)
            {
                _tailProjMove = snake5.transform.position - _tailProj.transform.position;
                if(_tailProj.transform.position.x > snake5.transform.position.x-1 && _tailProj.transform.position.x < snake5.transform.position.x+1 && _tailProj.transform.position.y < snake5.transform.position.y+1 && _tailProj.transform.position.y > snake5.transform.position.y -1)
                {
                    //When projectile disappears, destroy proj
                    Destroy(_tailProj);
                }
            }
        }
        else if(snake5.activeSelf == false && _paraReturn == false)
        {
            //When projectile disappers, spawn tail
            snake5.SetActive(true);
            _tailReturn = false;
            tailProjSpeed = 15;
        }
        */
        
        //Head Proj By itself
        /*
        if(snake5.transform.position.y == snake.transform.position.y && _paraReturn == false && ((hero.transform.position.x > snake5.transform.position.x + 2 && hero.transform.position.x < snake.transform.position.x -2) || (hero.transform.position.x > snake.transform.position.x+2 && hero.transform.position.x < snake5.transform.position.x-2)))
        {
            _paraReturn = true;
            _headProj = Instantiate(prefab);
            _headProj.transform.position = snake.transform.position;
            _headProjMove = parabolicCoordinates(snake.transform.position,hero.transform.position,snake5.transform.position,(snake.transform.position.x > snake5.transform.position.x)?-1:1);
            snake5.SetActive(false);
            headProjRB = _headProj.GetComponent<Rigidbody>();
        }
        if(_paraReturn == true)
        {
            headProjRB.MovePosition(_headProjMove[_paraPosCount]);
            if(_headProj.transform.position.x == _headProjMove[_paraPosCount].x)
            {
                _paraPosCount++;
            }
            if(_headProj.transform.position.x > snake5.transform.position.x-1 && _headProj.transform.position.x < snake5.transform.position.x+1 && _headProj.transform.position.y < snake5.transform.position.y+1 && _headProj.transform.position.y > snake5.transform.position.y -1 && _paraReturn ==true)
            {
                snake5.SetActive(true);
                Destroy(_headProj);
                _paraReturn = false;
                _paraPosCount = 0;
            }
        }
        */
    }

    float unitVector(Vector3 num)
    {
        return Mathf.Sqrt(num.x*num.x+num.y*num.y+num.z+num.z);
    }

    Vector3 [] parabolicCoordinates(Vector3 start, Vector3 vertex, Vector3 end, int sign)
    {
        //y = ax^2 + bx + c

        //Keep this array at the value
        Vector3 [] array = new Vector3[35];
        float a,b,c;
        Matrix4x4 matrixA = new Matrix4x4();
        Matrix4x4 matrixB = new Matrix4x4();
        matrixA[0,0] = start.x * start.x;
        matrixA[0,1] = start.x;
        matrixA[0,2] = 1;
        matrixA[1,0] = vertex.x * vertex.x;
        matrixA[1,1] = vertex.x;
        matrixA[1,2] = 1;
        matrixA[2,0] = end.x * end.x;
        matrixA[2,1] = end.x;
        matrixA[2,2] = 1;
        matrixA[3,3] = 1;
        matrixB[0,0] = start.y;
        matrixB[1,0] = vertex.y;
        matrixB[2,0] = end.y;
        matrixB[3,0] = 0;
        a = (matrixA.inverse*matrixB)[0,0];
        b = (matrixA.inverse*matrixB)[1,0];
        c = (matrixA.inverse*matrixB)[2,0];

        //For loop at value
        for(int x = 0; x<35 ; x++)
        {
            //divided at value minus 1
            float temp = (Mathf.Abs(start.x) + Mathf.Abs(end.x))/34;
            float ex = snake.transform.position.x + (temp * x * sign);
            array[x] = new Vector3(ex , (a*ex*ex+b*ex+c) , 0);
        }
        return array;
    }
    
}
