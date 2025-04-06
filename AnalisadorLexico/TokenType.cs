public enum TokenType
{
    // Palavras-chave
    If, Else, While, For, Return,
    
    // Identificadores e literais
    Identifier, Number, String,
    
    // Operadores
    Plus, Minus, Multiply, Divide, Assign, Equal, NotEqual,
    LessThan, GreaterThan, LessOrEqual, GreaterOrEqual,
    
    // Delimitadores
    LeftParen, RightParen, LeftBrace, RightBrace,
    Comma, Semicolon,
    
    // Fim de arquivo
    EOF,
    
    // Token inválido
    Invalid
}