namespace Compiladores20201ProjetoCSharp.Compilador
{

    public abstract class ScannerConstants
    {

        public static int[] TOKEN_STATE = { -2, 0, 36, -1, -1, 34, 28, 29, 39, 37, 41, 38, 42, 40, 5, 5, 44, 43, 32, 45, 33, 4, 35, 31, 7, -1, -1, 46, -2, 0, 47, -1, 30, 4, 4, 2, 3, 0, -2, 6, 0, -1 };

        public static int[] SPECIAL_CASES_INDEXES =
            { 0, 0, 0, 0, 0, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20 };

        public static string[] SPECIAL_CASES_KEYS =
            {  "bin", "bool", "def", "elif", "else", "end", "false", "float", "hexa", "if", "int", "listen", "main", "speak", "str", "toBin", "toHexa", "toInt", "true", "whileFalse" };

        public static int[] SPECIAL_CASES_VALUES =
            {  8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 24, 25, 23, 26, 27 };

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
        "constante real inválida"
        };

    }
}