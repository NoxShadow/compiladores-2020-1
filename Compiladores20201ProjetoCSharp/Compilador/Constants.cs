namespace Compiladores20201ProjetoCSharp.Compilador
{
    public abstract class Constants : ScannerConstants
    {
        public const int EPSILON = 0;
        public const int DOLLAR = 1;

        public const int t_binario = 2;
        public const int t_hexadecimal = 3;
        public const int t_identificador = 4;
        public const int t_inteira = 5;
        public const int t_real = 6;
        public const int t_string = 7;
        public const int t_bin = 8;
        public const int t_bool = 9;
        public const int t_def = 10;
        public const int t_elif = 11;
        public const int t_else = 12;
        public const int t_end = 13;
        public const int t_false = 14;
        public const int t_float = 15;
        public const int t_hexa = 16;
        public const int t_if = 17;
        public const int t_int = 18;
        public const int t_listen = 19;
        public const int t_main = 20;
        public const int t_speak = 21;
        public const int t_str = 22;
        public const int t_toInt = 23;
        public const int t_toBin = 24;
        public const int t_toHexa = 25;
        public const int t_true = 26;
        public const int t_whileFalse = 27;
        public const int t_do = 28;
        public const int t_TOKEN_29 = 29;   //  "("
        public const int t_TOKEN_30 = 30;   //  ")"
        public const int t_TOKEN_31 = 31;   //  "=="
        public const int t_TOKEN_32 = 32;   //  "!="
        public const int t_TOKEN_33 = 33;   //  "<"
        public const int t_TOKEN_34 = 34;   //  ">"
        public const int t_TOKEN_35 = 35;   //  "&"
        public const int t_TOKEN_36 = 36;   //  "|"
        public const int t_TOKEN_37 = 37;   //  "!"
        public const int t_TOKEN_38 = 38;   //  "+"
        public const int t_TOKEN_39 = 39;   //  "-"
        public const int t_TOKEN_40 = 40;   //  "*"
        public const int t_TOKEN_41 = 41;   //  "/"
        public const int t_TOKEN_42 = 42;   //  ","
        public const int t_TOKEN_43 = 43;   //  "."
        public const int t_TOKEN_44 = 44;   //  ";"
        public const int t_TOKEN_45 = 45;   //  ":"
        public const int t_EQUAL = 46;      //  "="
        public const int t_PLUS_EQUAL = 47; //  "+="
        public const int t_MINUS_EQUAL = 48;//  "-="

        public static readonly string[] CLASSES =
            {
                "símbolo especial",      // &
                "símbolo especial",      // $
                "constante binaria",     // #b1
                "constante hexadecimal", // #h2
                "identificador",         // identificador
                "constante inteira",     // 1
                "constante real",        // 1.0
                "constante literal",     // "string"
                "palavra reservada",     // bin
                "palavra reservada",     // bool
                "palavra reservada",     // def
                "palavra reservada",     // elif
                "palavra reservada",     // else
                "palavra reservada",     // end
                "palavra reservada",     // false
                "palavra reservada",     // float
                "palavra reservada",     // hexa
                "palavra reservada",     // if
                "palavra reservada",     // int
                "palavra reservada",     // listen
                "palavra reservada",     // main
                "palavra reservada",     // speak
                "palavra reservada",     // str
                "palavra reservada",     // toInt
                "palavra reservada",     // toBin
                "palavra reservada",     // toHexa
                "palavra reservada",     // true
                "palavra reservada",     // whileFalse
                "palavra reservada",     // do
                "símbolo especial",      // "("
                "símbolo especial",      // ")"
                "símbolo especial",      // "=="
                "símbolo especial",      // "!="
                "símbolo especial",      // "<"
                "símbolo especial",      // ">"
                "símbolo especial",      // "&"
                "símbolo especial",      // "|"
                "símbolo especial",      // "!"
                "símbolo especial",      // "+"
                "símbolo especial",      // "-"
                "símbolo especial",      // "*"
                "símbolo especial",      // "/"
                "símbolo especial",      // ","
                "símbolo especial",      // "."
                "símbolo especial",      // ";"
                "símbolo especial",      // ":"
                "símbolo especial",      // "="
                "símbolo especial",      // "+="
                "símbolo especial",      // "-="
            };
    }
}