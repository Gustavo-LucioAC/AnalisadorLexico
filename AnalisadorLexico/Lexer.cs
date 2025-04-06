using AnalisadorLexico;
public class Lexer
{
    private readonly string _input;
    private int _position;
    private int _line;
    private int _column;

    public Lexer(string input)
    {
        _input = input;
        _position = 0;
        _line = 1;
        _column = 1;
    }

    public Token NextToken()
    {
        if (_position >= _input.Length)
        {
            return new Token(TokenType.EOF, "", _line, _column);
        }

        char current = _input[_position];

        // Pular espaços em branco
        if (char.IsWhiteSpace(current))
        {
            if (current == '\n')
            {
                _line++;
                _column = 1;
            }
            else
            {
                _column++;
            }
            
            _position++;
            return NextToken();
        }

        // Reconhecer números
        if (char.IsDigit(current))
        {
            return ReadNumber();
        }

        // Reconhecer identificadores e palavras-chave
        if (char.IsLetter(current) || current == '_')
        {
            return ReadIdentifier();
        }

        // Reconhecer strings
        if (current == '"')
        {
            return ReadString();
        }

        // Reconhecer operadores e símbolos
        switch (current)
        {
            case '+':
                _position++;
                _column++;
                return new Token(TokenType.Plus, "+", _line, _column - 1);
            case '-':
                _position++;
                _column++;
                return new Token(TokenType.Minus, "-", _line, _column - 1);
            case '*':
                _position++;
                _column++;
                return new Token(TokenType.Multiply, "*", _line, _column - 1);
            case '/':
                _position++;
                _column++;
                return new Token(TokenType.Divide, "/", _line, _column - 1);
            case '=':
                _position++;
                _column++;
                if (_position < _input.Length && _input[_position] == '=')
                {
                    _position++;
                    _column++;
                    return new Token(TokenType.Equal, "==", _line, _column - 2);
                }
                return new Token(TokenType.Assign, "=", _line, _column - 1);
            // Adicione outros casos conforme necessário
            default:
                _position++;
                _column++;
                return new Token(TokenType.Invalid, current.ToString(), _line, _column - 1);
        }
    }

    private Token ReadNumber()
    {
        int start = _position;
        while (_position < _input.Length && char.IsDigit(_input[_position]))
        {
            _position++;
            _column++;
        }

        string value = _input.Substring(start, _position - start);
        return new Token(TokenType.Number, value, _line, _column - value.Length);
    }

    private Token ReadIdentifier()
    {
        int start = _position;
        while (_position < _input.Length && (char.IsLetterOrDigit(_input[_position]) || _input[_position] == '_'))
        {
            _position++;
            _column++;
        }

        string value = _input.Substring(start, _position - start);
        
        // Verificar se é uma palavra-chave
        TokenType type = value switch
        {
            "if" => TokenType.If,
            "else" => TokenType.Else,
            "while" => TokenType.While,
            "for" => TokenType.For,
            "return" => TokenType.Return,
            _ => TokenType.Identifier
        };

        return new Token(type, value, _line, _column - value.Length);
    }

    private Token ReadString()
    {
        _position++; // Pular a aspa inicial
        _column++;
        
        int start = _position;
        while (_position < _input.Length && _input[_position] != '"')
        {
            if (_input[_position] == '\n')
            {
                _line++;
                _column = 1;
            }
            else
            {
                _column++;
            }
            _position++;
        }

        if (_position >= _input.Length)
        {
            return new Token(TokenType.Invalid, "String não terminada", _line, _column);
        }

        string value = _input.Substring(start, _position - start);
        _position++; // Pular a aspa final
        _column++;
        
        return new Token(TokenType.String, value, _line, _column - value.Length - 2);
    }
}