using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalisadorLexico
{
    public class Token
    {
        public TokenType Type { get; }
        public string Value { get; }
        public int Line { get; }
        public int Column { get; }

        public Token(TokenType type, string value, int line, int column)
        {
            Type = type;
            Value = value;
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return $"{Type} [{Value}] (Line: {Line}, Column: {Column})";
        }
    }
}