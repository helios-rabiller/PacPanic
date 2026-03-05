    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Tilemaps;

    public struct cell
    {
        public int wallType;        // 0 -> no walls (floor), 1-8 -> wall type, 9 -> prison wall
        public int pelletType;      // 10 -> no pellets, 11 -> small, 12 -> big
                                    //Note that pellet is present only if the wall type = 0
        public bool hasPellet;      // Is pellet present or not (eaten or not)
        public bool hasCharacter;   // Pacman or ghost in

    };

    public class Map : MonoBehaviour
    {
        
        /*

            Walls / floors
            0) floor
            1) top 
            2) top right
            3) right
            4) Bottom right
            5) bottom 
            6) Bottom left
            7) left 
            8) Top left   
            9) prison floor
            
            
            Pellets
            10) no pellet
            11) small pellet
            12) Big pellet (power)

        */

        public Tilemap tilemap;
        public Tile floor;
        public Tile topWallTile;
        public Tile topRightWallTile;
        public Tile rightWallTile;
        public Tile bottomRightWallTile;
        public Tile bottomWallTile;
        public Tile bottomLeftTile;
        public Tile leftTile;
        public Tile topLeftTile;
        public Tile prisonTile;
        public Tile pelletTile;
        public Tile bigPelletTile;

        // Start is called before the first frame update
        private cell[,] level = new cell[8,8];
        private int[,] wallData = new int[,] {
            {8,1,1,1,1,1,1,2},
            {7,0,0,0,0,0,0,3},
            {7,0,0,0,0,0,0,3},
            {7,0,0,0,0,0,0,3},
            {7,0,0,0,0,0,0,3},
            {7,0,0,0,0,0,0,3},
            {7,0,0,0,0,0,0,3},
            {6,5,5,5,5,5,5,4}
        };

        void Start() {
            Debug.Log("Nombre de lignes: " + level.GetLength(0));
            Debug.Log("Nombre de colonnes: " + level.GetLength(1));
            for (int row = 0; row < level.GetLength(0); row++)
            {
                for (int column = 0; column < level.GetLength(1); column++)
                {
                    
                    Vector3Int position = new Vector3Int(column, -row, -10);
                    level[row, column] = new cell {
                        wallType = wallData[row, column],
                        pelletType = 10,
                        hasPellet = true,
                        hasCharacter = false
                    };

                    switch (level[row,column].wallType)
                    {
                        case 0:
                            tilemap.SetTile(position,floor);
                            //Debug.Log(string.Format("No walls at ( {0} , {1} )",row,column)); 
                            break;
                        case 1:
                            tilemap.SetTile(position, topWallTile);
                            //Debug.Log(string.Format("Top wall at ( {0} , {1} )",row,column)); 
                            break;
                        case 2:
                            tilemap.SetTile(position, topRightWallTile);
                            //Debug.Log(string.Format("Right wall at ( {0} , {1} )",row,column)); 
                            break;
                        case 3:
                            tilemap.SetTile(position, rightWallTile);
                            //Debug.Log(string.Format("Bottom wall at ( {0} , {1} )",row,column)); 
                            break;
                        case 4:
                            tilemap.SetTile(position, bottomRightWallTile);
                            //Debug.Log(string.Format("Left wall at ( {0} , {1} )",row,column)); 
                            break;
                        case 5:
                            tilemap.SetTile(position, bottomWallTile);
                            //Debug.Log(string.Format("No pellets at ( {0} , {1} )",row,column)); 
                            break;
                        case 6:
                            tilemap.SetTile(position, bottomLeftTile);
                            //Debug.Log(string.Format("Pellets at ( {0} , {1} )",row,column)); 
                            break;
                        case 7:
                            tilemap.SetTile(position, leftTile);
                            //Debug.Log(string.Format("Big pellets at ( {0} , {1} )",row,column)); 
                            break;
                        case 8:
                            tilemap.SetTile(position, topLeftTile);
                            //Debug.Log(string.Format("Big pellets at ( {0} , {1} )",row,column)); 
                            break;
                        case 9:
                            tilemap.SetTile(position, prisonTile);
                            //Debug.Log(string.Format("Big pellets at ( {0} , {1} )",row,column)); 
                            break;
                        default:
                            break;
                    }
                    //Debug.Log(string.Format("coordonnees a ( {0} , {1} )",row,column));        
                }
            }
            Debug.Log("Total de tiles placés: " + (level.GetLength(0) * level.GetLength(1)));
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }