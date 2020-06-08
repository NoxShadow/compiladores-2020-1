using Compiladores20201ProjetoCSharp.Compilador.JavaCsharp;

namespace Compiladores20201ProjetoCSharp.Compilador
{

    public abstract class ScannerConstants : ParserConstants
    {

        public static int[] TOKEN_STATE = { -2, 0, 37, -1, -1, 35, 29, 30, 40, 38, 42, 39, 43, 41, 5, 5, 45, 44, 33, 46, 34, 4, 36, 32, 7, -1, -1, 47, -2, 0, 48, -1, 31, 4, 4, 2, 3, 0, -2, 6, 4, 4, 0, -1 };

        public static int[] SPECIAL_CASES_INDEXES =
            { 0, 0, 0, 0, 0, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21 };

        public static string[] SPECIAL_CASES_KEYS =
            {  "bin", "bool", "def", "do", "elif", "else", "end", "false", "float", "hexa", "if", "int", "listen", "main", "speak", "str", "toBin", "toHexa", "toInt", "true", "whileFalse" };

        public static int[] SPECIAL_CASES_VALUES =
            {  8, 9, 10, 28, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 24, 25, 23, 26, 27 };


        public static string[] SCANNER_ERROR =
        {
        "símbolo inválido",
        "",
        "",
        "constante string inválida ou não finalizada",
        "constante binária ou hexadecimal inválida",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "constante binaria inválida",
        "constante hexadecimal inválida",
        "",
        "comentário de bloco inválido",
        "",
        "",
        "constante real inválida",
        "",
        "",
        "",
        "",
        "",
        "",
        "comentário de bloco inválido",
        "",
        "",
        "",
        "",
        "constante real inválida"
        };

    }
}