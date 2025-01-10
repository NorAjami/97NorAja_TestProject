﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _97NorAja_TestProject
{
    internal class Calculator
    {
        public float Add(float a, float b)
        {
            return a + b;
        }

        public float Subtract(float a, float b)
        {
            return a - b;
        }

        public float Multiply(float a, float b)
        {
            return a * b;
        }

        // kommenterade bort denna då jag ej kunde köra den andra med float exception
        /* public float Divide(float a, float b)
         {
             return a / b;
         }
        */

        public float Divide(float a, float b)
        {
            if (b == 0.0f) 
                throw new DivideByZeroException("Division med 0 är inte tillåten."); //throw new DivideByZeroException("Division by zero is not allowed.");

            return a / b;
        }








        //råkade missa float i början, körde int. men extra gör inget.
        /*
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            return a / b;
        }
        */
    }
}
