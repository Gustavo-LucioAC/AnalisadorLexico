using AnalisadorLexico;

class Program
{
    static void Main(string[] args)
    {
        string input = @"if (x == 42) {
            return ""hello"";
        } else {
            y = 3.14;
        }";
        
        Lexer lexer = new Lexer(input);
        Token token;
        
        do
        {
            token = lexer.NextToken();
            Console.WriteLine(token);
        } while (token.Type != TokenType.EOF);
    }
}