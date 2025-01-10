﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace _97NorAja_TestProject.calculator
{
    public class StringProcessor
    {
        /*
        public string ToLowerCase(string input)
        {
            return input.ToLower();
        }
        */
      
        public string ToLowerCase(string input)
        {
            if (input == null)
                return null;

            return input.ToLower();
        }

        public string Sanitize(string input)
        {
            if (input == null)
                return null;

            // Regex för att ta bort allt som inte är bokstäver eller siffror
            return Regex.Replace(input, @"[^a-zA-Z0-9\s]", "");
            // Ta bort alla specialtecken
            string sanitized = Regex.Replace(input, @"[^a-zA-Z0-9\s]", ""); 

            // Lägg till mellanrum mellan ord genom att hitta gränser mellan bokstäver och siffror
            string spacedResult = Regex.Replace(sanitized, @"(?<=[a-zA-Z])(?=[0-9])|(?<=[0-9])(?=[a-zA-Z])", " ");

            return spacedResult;
        }
    }

}

