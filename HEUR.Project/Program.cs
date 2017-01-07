﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEUR.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Result> resultList = new List<Result>();
            do
            {
                Result result = ResultGenerator.NaiveResult();
                if (result.IsValid())
                {
                    resultList.Add(result);
                }

                while (!result.IsValid())
                {
                    result = ResultGenerator.TabuSearch(result);
                }

            } while (true);
        }
    }
}
