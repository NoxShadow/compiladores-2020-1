using System;
using System.Collections.Generic;
using System.Text;

namespace Compiladores20201ProjetoCSharp.Compilador
{
    public class Semantico : Constants
    {
        private readonly StringBuilder _codigo = new StringBuilder();
        public string Codigo => _codigo.ToString();
        private readonly Queue<TipoEnum> _tipos = new Queue<TipoEnum>();
        private string _operadorRelacional;

        public void ExecuteAction(int action, Token token)
        {
            Console.WriteLine($"Ação #{action} , Token: {token}");

            switch (action)
            {
                case 1:
                    Acao1();
                    break;
                case 2:
                    Acao2();
                    break;
                case 3:
                    Acao3();
                    break;
                case 4:
                    Acao4();
                    break;
                case 5:
                    Acao5(token);
                    break;
                case 6:
                    Acao6(token);
                    break;
                case 7:
                    Acao7();
                    break;
                case 8:
                    Acao8();
                    break;
                case 9:
                    Acao9(token);
                    break;
                case 10:
                    Acao10();
                    break;
                case 11:
                    Acao11();
                    break;
                case 12:
                    Acao12();
                    break;
                case 13:
                    Acao13();
                    break;
                case 14:
                    Acao14();
                    break;
                case 15:
                    Acao15();
                    break;
                case 16:
                    Acao16();
                    break;
                case 17:
                    Acao17();
                    break;
                case 18:
                    Acao18();
                    break;
                case 19:
                    Acao19(token);
                    break;
                case 20:
                    Acao20(token);
                    break;
                case 21:
                    Acao21(token);
                    break;
                case 22:
                    Acao22();
                    break;
                case 23:
                    Acao23();
                    break;
                case 24:
                    Acao24();
                    break;

                default:
                    throw new SemanticError("Ação semântica não implementada");
            }
        }

        private void Acao1()
        {
            AcaoAritmeticaSimples("add");
        }

        private void Acao2()
        {
            AcaoAritmeticaSimples("sub");
        }

        private void Acao3()
        {
            AcaoAritmeticaSimples("mul");
        }

        private void AcaoAritmeticaSimples(string operacao)
        {
            var tipo1 = _tipos.Dequeue();
            var tipo2 = _tipos.Dequeue();

            if (!VerificaTipoExpressaoAritmetica(tipo1) || !VerificaTipoExpressaoAritmetica(tipo2))
            {
                throw new SemanticError("tipos incompatíveis em expressão aritmética");
            }

            if (tipo1 == TipoEnum.Real || tipo2 == TipoEnum.Real)
            {
                _tipos.Enqueue(TipoEnum.Real);
            }
            else
            {
                _tipos.Enqueue(TipoEnum.Inteiro);
            }

            _codigo.AppendLine(operacao);
        }

        private void Acao4()
        {
            var tipo1 = _tipos.Dequeue();
            var tipo2 = _tipos.Dequeue();

            if (!VerificaTipoExpressaoAritmetica(tipo1) || !VerificaTipoExpressaoAritmetica(tipo2))
            {
                throw new SemanticError("tipos incompatíveis em expressão aritmética");
            }

            if (tipo1 != tipo2)
            {
                throw new SemanticError("Tipos não podem ser diferentes em operação de divisão");
            }

            _tipos.Enqueue(TipoEnum.Real);

            _codigo.AppendLine("div");
        }

        private void Acao5(Token token)
        {
            _tipos.Enqueue(TipoEnum.Inteiro);
            _codigo.AppendLine($"ldc.r8 {token.Lexeme}");
        }

        private void Acao6(Token token)
        {
            _tipos.Enqueue(TipoEnum.Real);
            _codigo.AppendLine($"ldc.r8 {token.Lexeme}");
        }

        private void Acao7()
        {
            var tipo1 = _tipos.Dequeue();

            if (!VerificaTipoExpressaoAritmetica(tipo1))
            {
                throw new SemanticError("Tipo incompatível em expressão aritmética");
            }

            _tipos.Enqueue(tipo1);
        }

        private void Acao8()
        {
            var tipo1 = _tipos.Dequeue();

            if (!VerificaTipoExpressaoAritmetica(tipo1))
            {
                throw new SemanticError("Tipo incompatível em expressão aritmética");
            }

            _tipos.Enqueue(tipo1);
            _codigo.AppendLine("ldc.r8 - 1");
            _codigo.AppendLine("mul");
        }

        private void Acao9(Token token)
        {
            _operadorRelacional = token.Lexeme;
        }

        private void Acao10()
        {
            var tipo1 = _tipos.Dequeue();
            var tipo2 = _tipos.Dequeue();

            if (tipo1 != tipo2)
            {
                throw new SemanticError("Tipo incompatível em expressão relacional");
            }

            _tipos.Enqueue(TipoEnum.Logico);

            switch (_operadorRelacional)
            {
                case ">":
                    _codigo.AppendLine("cgt");
                    break;
                case "<":
                    _codigo.AppendLine("clt");
                    break;
                case "==":
                    _codigo.AppendLine("ceq");
                    break;
                case "!=":
                    _codigo.AppendLine("cnq");
                    break;
            }

        }

        private void Acao11()
        {
            _tipos.Enqueue(TipoEnum.Logico);
            _codigo.AppendLine("lcd.i4.1");
        }

        private void Acao12()
        {
            _tipos.Enqueue(TipoEnum.Logico);
            _codigo.AppendLine("lcd.i4.0");
        }

        private void Acao13()
        {
            var tipo = _tipos.Dequeue();

            if(tipo != TipoEnum.Logico)
            {
                throw new SemanticError("tipo incompatível em expressão lógica");
            }

            _tipos.Enqueue(TipoEnum.Logico);

            _codigo.AppendLine("ldc.i4.1");
            _codigo.AppendLine("xor");
        }

        private void Acao14()
        {
            var tipo = _tipos.Dequeue();

            if (tipo == TipoEnum.Inteiro)
            {
                _codigo.AppendLine("conv.i8");
            }
            if(tipo == TipoEnum.Binario)
            {
                _codigo.AppendLine("ldstr \"#b\"");
                _codigo.AppendLine("call void [mscorlib]System.Console::Write(string)");
                _codigo.AppendLine("ldc.i4 2");
                _codigo.AppendLine("call string [mscorlib]System.Convert::ToString(int64, int32)");

                tipo = TipoEnum.Literal;
            }
            if (tipo == TipoEnum.Hexadecimal)
            {
                _codigo.AppendLine("ldstr \"#x\"");
                _codigo.AppendLine("call void [mscorlib]System.Console::Write(string)");
                _codigo.AppendLine("ldc.i4 16");
                _codigo.AppendLine("call string [mscorlib]System.Convert::ToString(int64, int32)");

                tipo = TipoEnum.Literal;
            }

            _codigo.AppendLine($"call void [mscorlib]System.Console::Write({ TipoEnumToString(tipo) })");
        }

        private void Acao15()
        {
            _codigo.AppendLine(".assembly extern mscorlib {}");
            _codigo.AppendLine(".assembly _codigo_objeto { }");
            _codigo.AppendLine(".module _codigo_objeto.exe");
            _codigo.AppendLine(".class public _UNICA{");
            _codigo.AppendLine(".method static public void _principal() {");
            _codigo.AppendLine(".entrypoint");
        }

        private void Acao16()
        {
            _codigo.AppendLine("ret");
            _codigo.AppendLine("}");
            _codigo.AppendLine("}");
        }

        private void Acao17()
        {
            AcaoLogicaSimples("and");
        }

        private void Acao18()
        {
            AcaoLogicaSimples("or");
        }

        private void Acao19(Token token)
        {
            _tipos.Enqueue(TipoEnum.Literal);
            _codigo.AppendLine($"ldstr { token.Lexeme }");
        }

        private void Acao20(Token token)
        {
            _tipos.Enqueue(TipoEnum.Binario);

            _codigo.AppendLine($"ldstr \"{ token.Lexeme.Replace("#b", "") }\"");
            _codigo.AppendLine("ldc.i4 2");
            _codigo.AppendLine("call int64 [mscorlib]System.Convert::ToInt64(string, int32)");
        }

        private void Acao21(Token token)
        {
            _tipos.Enqueue(TipoEnum.Hexadecimal);

            _codigo.AppendLine($"ldstr \"{ token.Lexeme.Replace("#x", "") }\"");
            _codigo.AppendLine("ldc.i4 16");
            _codigo.AppendLine("call int64 [mscorlib]System.Convert::ToInt64(string, int32)");
        }

        private void Acao22()
        {
            var tipo = _tipos.Dequeue();

            if(tipo != TipoEnum.Binario && tipo != TipoEnum.Hexadecimal)
            {
                throw new SemanticError("tipo incompatível em operação de conversão de valor");
            }

            _tipos.Enqueue(TipoEnum.Inteiro);
            _codigo.AppendLine("conv.r8");
        }

        private void Acao23()
        {
            var tipo = _tipos.Dequeue();

            if (tipo != TipoEnum.Inteiro && tipo != TipoEnum.Hexadecimal)
            {
                throw new SemanticError("tipo incompatível em operação de conversão de valor");
            }

            _tipos.Enqueue(TipoEnum.Binario);
            _codigo.AppendLine("conv.i8");
        }

        private void Acao24()
        {
            var tipo = _tipos.Dequeue();

            if (tipo != TipoEnum.Binario && tipo != TipoEnum.Inteiro)
            {
                throw new SemanticError("tipo incompatível em operação de conversão de valor");
            }

            _tipos.Enqueue(TipoEnum.Hexadecimal);
            _codigo.AppendLine("conv.i8");
        }

        private void AcaoLogicaSimples(string operacao)
        {
            var tipo1 = _tipos.Dequeue();
            var tipo2 = _tipos.Dequeue();

            if (!VerificaTipoExpressaoLogica(tipo1) || !VerificaTipoExpressaoLogica(tipo2))
            {
                throw new SemanticError("tipos incompatíveis em expressão lógica");
            }

            _tipos.Enqueue(TipoEnum.Logico);

            _codigo.AppendLine(operacao);
        }

        private string TipoEnumToString(TipoEnum tipo)
        {

            switch (tipo)
            {
                case TipoEnum.Inteiro:
                    return "int64";
                case TipoEnum.Real:
                    return "float64";
                case TipoEnum.Literal:
                    return "string";
            }

            return "";
        }

        private bool VerificaTipoExpressaoAritmetica(TipoEnum tipo)
        {
            switch (tipo)
            {
                case TipoEnum.Inteiro:
                case TipoEnum.Real:
                case TipoEnum.Binario:
                case TipoEnum.Hexadecimal:
                    return true;
                default:
                    return false;
            }

        }

        private bool VerificaTipoExpressaoLogica(TipoEnum tipo)
        {
            switch (tipo)
            {
                case TipoEnum.Logico:
                    return true;
                default:
                    return false;
            }

        }
    }
}
