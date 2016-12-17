﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEUR.Project
{
    public sealed class InputParameters
    {
        public static int numServers = 28;
        public static int numVms = 44;
        public static int numRes = 2;
        public static int numNodes = 8;
        public static int numServiceChains = 62;

        public static double[] P_max =
        {
            270.0, 220.0, 190.0, 220.0, 190.0, 290.0, 270.0, 260.0, 280.0, 180.0, 190.0,
            180.0, 160.0, 260.0, 260.0, 270.0, 260.0, 290.0, 160.0, 290.0, 160.0, 240.0, 220.0, 240.0, 270.0, 290.0,
            190.0, 160.0
        };

        public static double[] P_min =
        {
            108.0, 66.0, 38.0, 66.0, 38.0, 116.0, 108.0, 78.0, 112.0, 36.0, 38.0, 36.0, 32.0,
            78.0, 78.0, 108.0, 78.0, 116.0, 32.0, 116.0, 32.0, 72.0, 66.0, 72.0, 108.0, 116.0, 38.0, 32.0
        };

        public static double[,] req =
        {
            {
                0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6,
                0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.6, 0.4, 0.5, 0.5, 0.5, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3,
                0.3, 0.3
            },
            {
                0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3,
                0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.3, 0.4, 0.4, 0.4, 0.4, 0.2, 0.2, 0.2, 0.2, 0.2, 0.2, 0.2,
                0.2, 0.2
            }
        };

        public static double[,] av =
        {
            {
                2.0, 1.2, 0.8, 1.2, 0.8, 2.4, 2.0, 1.8, 2.0, 0.8, 1.2, 0.8, 0.6, 1.8, 1.8, 2.0, 1.8, 2.4, 0.6, 2.4, 0.6,
                1.6, 1.2, 1.6, 2.0, 2.4, 0.8, 0.6
            },
            {
                3.2, 1.6, 1.2, 1.6, 1.2, 1.6, 3.2, 2.2, 3.2, 1.2, 1.6, 1.2, 0.8, 2.2, 2.2, 3.2, 2.2, 1.6, 0.8, 1.6, 0.8,
                1.8, 1.6, 1.8, 3.2, 1.6, 1.2, 0.8
            }

        };

        public static int[,] al =   {
                                    {0,0,1,0,0,0,0,0},
                                    {0,1,0,0,0,0,0,0},
                                    {1,0,0,0,0,0,0,0},
                                    {0,1,0,0,0,0,0,0},
                                    {1,0,0,0,0,0,0,0},
                                    {0,0,1,0,0,0,0,0},
                                    {0,0,1,0,0,0,0,0},
                                    {0,1,0,0,0,0,0,0},
                                    {0,0,1,0,0,0,0,0},
                                    {1,0,0,0,0,0,0,0},
                                    {1,0,0,0,0,0,0,0},
                                    {1,0,0,0,0,0,0,0},
                                    {1,0,0,0,0,0,0,0},
                                    {0,1,0,0,0,0,0,0},
                                    {0,1,0,0,0,0,0,0},
                                    {0,0,1,0,0,0,0,0},
                                    {0,1,0,0,0,0,0,0},
                                    {0,0,1,0,0,0,0,0},
                                    {1,0,0,0,0,0,0,0},
                                    {0,0,1,0,0,0,0,0},
                                    {1,0,0,0,0,0,0,0},
                                    {0,1,0,0,0,0,0,0},
                                    {0,1,0,0,0,0,0,0},
                                    {0,1,0,0,0,0,0,0},
                                    {0,0,1,0,0,0,0,0},
                                    {0,0,1,0,0,0,0,0},
                                    {1,0,0,0,0,0,0,0},
                                    {1,0,0,0,0,0,0,0}
                                    };
        public static int[,] sc = {
                                    {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0},
                                    {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
                                    {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0},
                                    {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0},
                                    {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
                                    {0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
                                    {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                                    {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
                                    {0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,0,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1,0,1,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0}
                                    };

        public static int[] P = { 480, 350, 290, 350, 290, 600, 480, 600 };

        public static NodeConnection[] Edges = {
                                    new NodeConnection(1,4,1100,35.4,2),
                                    new NodeConnection(1,5,1100,35.4,2),
                                    new NodeConnection(1,6,1100,35.4,2),
                                    new NodeConnection(2,4,1100,25.4,1),
                                    new NodeConnection(2,5,1100,15.4,3),
                                    new NodeConnection(2,6,1100,25.4,1),
                                    new NodeConnection(3,4,1100,35.4,2),
                                    new NodeConnection(3,5,1100,35.4,1),
                                    new NodeConnection(3,6,1100,15.4,3),
                                    new NodeConnection(4,1,1100,35.4,2),
                                    new NodeConnection(4,2,1100,25.4,1),
                                    new NodeConnection(4,3,1100,35.4,2),
                                    new NodeConnection(4,7,733,35.4,4),
                                    new NodeConnection(4,8,550,35.4,1),
                                    new NodeConnection(5,1,1100,35.4,2),
                                    new NodeConnection(5,2,1100,15.4,3),
                                    new NodeConnection(5,3,1100,35.4,1),
                                    new NodeConnection(5,7,550,35.4,2),
                                    new NodeConnection(5,8,733,15.4,3),
                                    new NodeConnection(6,1,1100,35.4,2),
                                    new NodeConnection(6,2,1100,25.4,1),
                                    new NodeConnection(6,3,1100,15.4,3),
                                    new NodeConnection(6,7,550,35.4,2),
                                    new NodeConnection(6,8,733,35.4,4),
                                    new NodeConnection(7,4,733,35.4,4),
                                    new NodeConnection(7,5,550,35.4,2),
                                    new NodeConnection(7,6,550,35.4,2),
                                    new NodeConnection(8,4,550,35.4,1),
                                    new NodeConnection(8,5,733,15.4,3),
                                    new NodeConnection(8,6,733,35.4,4),
                                    };

        public static int[] lat = { 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20 };

        public static RequiredBandwidth[] VmDemands = {
                                    new RequiredBandwidth(1,32,15),
                                    new RequiredBandwidth(1,41,35),
                                    new RequiredBandwidth(2,32,15),
                                    new RequiredBandwidth(2,39,35),
                                    new RequiredBandwidth(3,32,15),
                                    new RequiredBandwidth(3,38,35),
                                    new RequiredBandwidth(4,32,15),
                                    new RequiredBandwidth(4,39,35),
                                    new RequiredBandwidth(5,32,15),
                                    new RequiredBandwidth(5,38,35),
                                    new RequiredBandwidth(6,32,15),
                                    new RequiredBandwidth(6,42,35),
                                    new RequiredBandwidth(7,32,15),
                                    new RequiredBandwidth(7,41,35),
                                    new RequiredBandwidth(8,32,15),
                                    new RequiredBandwidth(8,40,35),
                                    new RequiredBandwidth(9,32,15),
                                    new RequiredBandwidth(9,41,35),
                                    new RequiredBandwidth(10,32,15),
                                    new RequiredBandwidth(10,38,35),
                                    new RequiredBandwidth(11,32,15),
                                    new RequiredBandwidth(11,38,35),
                                    new RequiredBandwidth(12,32,15),
                                    new RequiredBandwidth(12,38,35),
                                    new RequiredBandwidth(13,32,15),
                                    new RequiredBandwidth(13,37,35),
                                    new RequiredBandwidth(14,32,15),
                                    new RequiredBandwidth(14,40,35),
                                    new RequiredBandwidth(15,32,15),
                                    new RequiredBandwidth(15,40,35),
                                    new RequiredBandwidth(16,32,15),
                                    new RequiredBandwidth(16,41,35),
                                    new RequiredBandwidth(17,32,15),
                                    new RequiredBandwidth(17,40,35),
                                    new RequiredBandwidth(18,32,15),
                                    new RequiredBandwidth(18,42,35),
                                    new RequiredBandwidth(19,32,15),
                                    new RequiredBandwidth(19,37,35),
                                    new RequiredBandwidth(20,32,15),
                                    new RequiredBandwidth(20,42,35),
                                    new RequiredBandwidth(21,32,15),
                                    new RequiredBandwidth(21,37,35),
                                    new RequiredBandwidth(22,32,15),
                                    new RequiredBandwidth(22,40,35),
                                    new RequiredBandwidth(23,32,15),
                                    new RequiredBandwidth(23,39,35),
                                    new RequiredBandwidth(24,32,15),
                                    new RequiredBandwidth(24,40,35),
                                    new RequiredBandwidth(25,32,15),
                                    new RequiredBandwidth(25,41,35),
                                    new RequiredBandwidth(26,32,15),
                                    new RequiredBandwidth(26,42,35),
                                    new RequiredBandwidth(27,32,15),
                                    new RequiredBandwidth(27,38,35),
                                    new RequiredBandwidth(28,32,15),
                                    new RequiredBandwidth(28,37,35),
                                    new RequiredBandwidth(29,32,15),
                                    new RequiredBandwidth(29,38,35),
                                    new RequiredBandwidth(30,32,15),
                                    new RequiredBandwidth(30,37,35),
                                    new RequiredBandwidth(31,32,15),
                                    new RequiredBandwidth(31,40,35),
                                    new RequiredBandwidth(32,33,240),
                                    new RequiredBandwidth(32,34,200),
                                    new RequiredBandwidth(32,35,180),
                                    new RequiredBandwidth(32,43,7),
                                    new RequiredBandwidth(33,36,240),
                                    new RequiredBandwidth(34,36,200),
                                    new RequiredBandwidth(35,36,180),
                                    new RequiredBandwidth(44,36,7)
                                    };
    }
}