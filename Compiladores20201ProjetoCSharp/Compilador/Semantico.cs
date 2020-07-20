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
        private int _operadorRelacional;
        private int _operadorAtribuicao;
        private TipoEnum _tipoVariavel;
        private string _valorVar;
        private readonly Queue<object> _rotulos = new Queue<object>();
        private readonly Dictionary<string, TipoEnum> _tabelaSimbolo = new Dictionary<string, TipoEnum>();
        private readonly List<string> _identificadoresTemporarios = new List<string>();

        private int _linha = 0;

        public void ExecuteAction(int action, Token token)
        {
            AtualizarLinha(token);
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
                case 30:
                    Acao30(token);
                    break;
                case 31:
                    Acao31();
                    break;
                case 32:
                    Acao32(token);
                    break;
                case 33:
                    Acao33(token);
                    break;
                case 34:
                    Acao34(token);
                    break;
                case 35:
                    Acao35();
                    break;
                case 36:
                    Acao36(token);
                    break;
                case 37:
                    Acao37(token);
                    break;
                case 38:
                    Acao38(token);
                    break;
                case 39:
                    Acao39();
                    break;
                case 40:
                    Acao40();
                    break;
                case 41:
                    Acao41();
                    break;
                case 42:
                    Acao42();
                    break;
                case 43:
                    Acao43();
                    break;
                case 44:
                    Acao44();
                    break;
                default:
                    AcaoSemanticaNaoImplementada(); ;
                    break;
            }
        }

        private void AtualizarLinha(Token token)
        {
            if (token == null)
            {
                return;
            }

            _linha = token.Line;
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

        private void Acao4()
        {
            var tipo1 = _tipos.Dequeue();
            var tipo2 = _tipos.Dequeue();

            var tipo = GetTipoExpressaoAritmetica(tipo1, tipo2);

            _tipos.Enqueue(tipo);

            AdicionarLinha("div");
        }

        private void Acao5(Token token)
        {
            _tipos.Enqueue(TipoEnum.Inteiro);

            GuardarValorInteiro(token.Lexeme);
        }

        private void Acao6(Token token)
        {
            _tipos.Enqueue(TipoEnum.Real);

            GuardarValorReal(token.Lexeme);
        }

        private void Acao7()
        {
            var tipo = _tipos.Dequeue();

            VerificaTipoExpressaoAritmeticaUnaria(tipo);

            _tipos.Enqueue(tipo);
        }

        private void Acao8()
        {
            var tipo = _tipos.Dequeue();

            VerificaTipoExpressaoAritmeticaUnaria(tipo);

            _tipos.Enqueue(tipo);

            GuardarValorInteiro("-1");
            AdicionarLinha("mul");
        }

        private void Acao9(Token token)
        {
            _operadorRelacional = token.Id;
        }

        private void Acao10()
        {
            var tipo1 = _tipos.Dequeue();
            var tipo2 = _tipos.Dequeue();

            if (!VerificaTipoExpressaoRelacional(tipo1, tipo2))
            {
                TipoInvalidoOperacaoRelacional();
            }

            _tipos.Enqueue(TipoEnum.Logico);

            switch (_operadorRelacional)
            {
                // >
                case t_TOKEN_34:
                    AdicionarLinha("cgt");
                    break;
                // <
                case t_TOKEN_33:
                    AdicionarLinha("clt");
                    break;
                // ==
                case t_TOKEN_31:
                    AdicionarLinha("ceq");
                    break;
                // !=
                case t_TOKEN_32:
                    AdicionarLinha("cnq");
                    break;
            }

        }

        private void Acao11()
        {
            _tipos.Enqueue(TipoEnum.Logico);

            GuardarValorLogico(true);
        }

        private void Acao12()
        {
            _tipos.Enqueue(TipoEnum.Logico);

            GuardarValorLogico(true);
        }

        private void Acao13()
        {
            var tipo = _tipos.Dequeue();

            if (tipo != TipoEnum.Logico)
            {
                TipoInvalidoOperacaoLogica(); ;
            }

            _tipos.Enqueue(TipoEnum.Logico);

            GuardarValorLogico(true);
            AdicionarLinha("xor");
        }

        private void Acao14()
        {
            var tipo = _tipos.Dequeue();

            if (tipo == TipoEnum.Inteiro)
            {
                ConverterParaReal();
            }
            else if (tipo == TipoEnum.Binario)
            {
                AdicionarLinha("ldstr \"#b\"");
                AdicionarLinha("call void [mscorlib]System.Console::Write(string)");
                AdicionarLinha("ldc.i4 2");
                AdicionarLinha("call string [mscorlib]System.Convert::ToString(int64, int32)");

                tipo = TipoEnum.Literal;
            }
            else if (tipo == TipoEnum.Hexadecimal)
            {
                AdicionarLinha("ldstr \"#x\"");
                AdicionarLinha("call void [mscorlib]System.Console::Write(string)");
                AdicionarLinha("ldc.i4 16");
                AdicionarLinha("call string [mscorlib]System.Convert::ToString(int64, int32)");

                tipo = TipoEnum.Literal;
            }

            AdicionarLinha($"call void [mscorlib]System.Console::Write({ TipoEnumToString(tipo) })");
        }

        private void Acao15()
        {
            AdicionarLinha(".assembly extern mscorlib {}");
            AdicionarLinha(".assembly _codigo_objeto { }");
            AdicionarLinha(".module _codigo_objeto.exe");
            AdicionarLinha(".class public _UNICA{");
            AdicionarLinha(".method static public void _principal() {");
            AdicionarLinha(".entrypoint");
        }

        private void Acao16()
        {
            AdicionarLinha("ret");
            AdicionarLinha("}");
            AdicionarLinha("}");
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

            GuardarValorLiteral(token.Lexeme);
        }

        private void Acao20(Token token)
        {
            _tipos.Enqueue(TipoEnum.Binario);

            GuardarValorBinario(token.Lexeme.Replace("#b", ""));
        }

        private void Acao21(Token token)
        {
            _tipos.Enqueue(TipoEnum.Hexadecimal);

            GuardarValorHexadecimal(token.Lexeme.Replace("#x", ""));
        }

        private void Acao22()
        {
            var tipo = _tipos.Dequeue();

            if (tipo != TipoEnum.Binario && tipo != TipoEnum.Hexadecimal)
            {
                TipoInvalidoConversaoValor();
            }

            _tipos.Enqueue(TipoEnum.Inteiro);
            ConverterParaReal();
        }

        private void Acao23()
        {
            var tipo = _tipos.Dequeue();

            if (tipo != TipoEnum.Inteiro && tipo != TipoEnum.Hexadecimal)
            {
                TipoInvalidoConversaoValor();
            }

            _tipos.Enqueue(TipoEnum.Binario);
            ConverterParaInteiro();
        }

        private void Acao24()
        {
            var tipo = _tipos.Dequeue();

            if (tipo != TipoEnum.Binario && tipo != TipoEnum.Inteiro)
            {
                TipoInvalidoConversaoValor();
            }

            _tipos.Enqueue(TipoEnum.Hexadecimal);
            ConverterParaInteiro();
        }

        private void Acao30(Token token)
        {
            var tipo = LexemaToTipoEnum(token.Id);

            _tipoVariavel = tipo;
        }

        private void Acao31()
        {
            var tipoVariavelLocal = _tipoVariavel == TipoEnum.Hexadecimal || _tipoVariavel == TipoEnum.Binario ? TipoEnum.Inteiro : _tipoVariavel;

            foreach (var identificador in _identificadoresTemporarios)
            {
                if (_tabelaSimbolo.ContainsKey(identificador))
                {
                    IdentificadorJaDeclarado();
                }

                AdicionarVariavel(tipoVariavelLocal, identificador);
            }

            _identificadoresTemporarios.Clear();
        }

        private void Acao32(Token token)
        {
            _identificadoresTemporarios.Add(token.Lexeme);
        }

        private void Acao33(Token token)
        {
            var identificador = token.Lexeme;

            if (!_tabelaSimbolo.ContainsKey(identificador))
            {
                IdentificadorNaoDeclarado();
            }

            var tipo = _tabelaSimbolo[identificador];

            _tipos.Enqueue(tipo);
            TravarValorVariavel(identificador);

            if (tipo == TipoEnum.Inteiro)
            {
                ConverterParaReal();
            }
        }

        private void Acao34(Token token)
        {
            if (_operadorAtribuicao == t_TOKEN_46)
            {

            }
            IdentificadorNaoDeclarado();
        }

        private void Acao35()
        {
            IdentificadorNaoDeclarado();
            throw new NotImplementedException();
        }

        private void Acao36(Token token)
        {
            _valorVar = token.Lexeme;
        }

        private void Acao37(Token token)
        {
            var tipoVariavelLocal = TipoDoValor(token.Id);

            foreach (var identificador in _identificadoresTemporarios)
            {
                if (_tabelaSimbolo.ContainsKey(identificador))
                {
                    IdentificadorJaDeclarado();
                }

                AdicionarVariavel(tipoVariavelLocal, identificador);

                GuardarValorTipo(tipoVariavelLocal, token);

                AtribuirValor(identificador);
            }

            _identificadoresTemporarios.Clear();
        }

        private void Acao38(Token token)
        {
            _operadorAtribuicao = token.Id;

            // -= || +=
            if (token.Id == t_TOKEN_47 || token.Id == t_TOKEN_48)
            {
                foreach (var identificador in _identificadoresTemporarios)
                {
                    TravarValorVariavel(identificador);

                    if (_tabelaSimbolo[identificador] == TipoEnum.Inteiro)
                    {
                        ConverterParaReal();
                    }
                }
            }
        }

        private void Acao39()
        {
            throw new NotImplementedException();
        }

        private void Acao40()
        {
            throw new NotImplementedException();
        }

        private void Acao41()
        {
            throw new NotImplementedException();
        }

        private void Acao42()
        {
            throw new NotImplementedException();
        }

        private void Acao43()
        {
            throw new NotImplementedException();
        }

        private void Acao44()
        {
            throw new NotImplementedException();
        }

        private void AcaoAritmeticaSimples(string operacao)
        {
            var tipo1 = _tipos.Dequeue();
            var tipo2 = _tipos.Dequeue();

            var tipo = GetTipoExpressaoAritmetica(tipo1, tipo2);

            _tipos.Enqueue(tipo);

            AdicionarLinha(operacao);
        }

        private void AcaoLogicaSimples(string operacao)
        {
            var tipo1 = _tipos.Dequeue();
            var tipo2 = _tipos.Dequeue();

            if (tipo1 != TipoEnum.Logico || tipo2 != TipoEnum.Logico)
            {
                TipoInvalidoOperacaoLogica();
            }

            _tipos.Enqueue(TipoEnum.Logico);

            AdicionarLinha(operacao);
        }

        private bool VerificaTipoExpressaoRelacional(TipoEnum tipo1, TipoEnum tipo2)
        {
            if (tipo1 == TipoEnum.Literal && tipo2 == TipoEnum.Literal)
            {
                return true;
            }

            if ((tipo1 == TipoEnum.Real || tipo1 == TipoEnum.Inteiro) &&
                (tipo2 == TipoEnum.Real || tipo2 == TipoEnum.Inteiro))
            {
                return true;
            }

            return false;
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

        private TipoEnum LexemaToTipoEnum(int idLexema)
        {
            switch (idLexema)
            {
                case t_int:
                    return TipoEnum.Inteiro;
                case t_float:
                    return TipoEnum.Real;
                case t_str:
                    return TipoEnum.Literal;
                case t_bool:
                    return TipoEnum.Logico;
                case t_bin:
                    return TipoEnum.Binario;
                case t_hexa:
                    return TipoEnum.Hexadecimal;
                default:
                    return TipoEnum.Erro;
            }
        }

        private void VerificaTipoExpressaoAritmeticaUnaria(TipoEnum tipo)
        {
            if (tipo == TipoEnum.Real || tipo == TipoEnum.Inteiro)
            {
                return;
            }

            TipoIncompativelExpressaoAritmetica();
        }

        private TipoEnum GetTipoExpressaoAritmetica(TipoEnum tipo1, TipoEnum tipo2, bool isDivisao = false)
        {
            if (tipo1 == TipoEnum.Binario && tipo2 == TipoEnum.Binario)
            {
                return TipoEnum.Binario;
            }

            if (tipo1 == TipoEnum.Hexadecimal && tipo2 == TipoEnum.Hexadecimal)
            {
                return TipoEnum.Hexadecimal;
            }

            if (tipo1 == TipoEnum.Inteiro && tipo2 == TipoEnum.Inteiro)
            {
                return isDivisao ? TipoEnum.Real : TipoEnum.Inteiro;
            }

            if (tipo1 == TipoEnum.Real && tipo2 == TipoEnum.Inteiro ||
                tipo1 == TipoEnum.Inteiro && tipo2 == TipoEnum.Real ||
                tipo1 == TipoEnum.Real && tipo2 == TipoEnum.Real)
            {
                return TipoEnum.Real;
            }

            return TipoIncompativelExpressaoAritmetica();
        }

        private TipoEnum TipoDoValor(int idLexeme)
        {
            switch (idLexeme)
            {
                case t_binario:
                    return TipoEnum.Binario;
                case t_true:
                case t_false:
                    return TipoEnum.Logico;
                case t_inteira:
                    return TipoEnum.Inteiro;
                case t_real:
                    return TipoEnum.Real;
                case t_string:
                    return TipoEnum.Literal;
                case t_hexadecimal:
                    return TipoEnum.Hexadecimal;
                default:
                    return TipoEnum.Erro;
            }
        }

        private void GuardarValorLogico(bool valor)
        {
            var valorLogico = valor ? 1 : 0;

            AdicionarLinha($"lcd.i4.{ valorLogico }");
        }

        private void GuardarValorInteiro(string lexeme)
        {
            AdicionarLinha($"ldc.r8 { lexeme }");
        }

        private void GuardarValorReal(string lexeme)
        {
            AdicionarLinha($"ldc.r8 { lexeme }");
        }

        private void GuardarValorLiteral(string lexeme)
        {
            AdicionarLinha($"ldstr { lexeme }");
        }

        private void GuardarValorBinario(string valor)
        {
            GuardarValorBaseDiferente(valor, 2);
        }

        private void GuardarValorHexadecimal(string valor)
        {
            GuardarValorBaseDiferente(valor, 16);
        }

        private void GuardarValorBaseDiferente(string valor, int baseValor)
        {
            AdicionarLinha($"ldstr \"{ valor }\"");
            AdicionarLinha($"ldc.i4 { baseValor }");
            AdicionarLinha("call int64 [mscorlib]System.Convert::ToInt64(string, int32)");
        }

        private void GuardarValorTipo(TipoEnum tipo, Token token)
        {
            switch (tipo)
            {
                case TipoEnum.Binario:
                    GuardarValorBinario(token.Lexeme);
                    break;
                case TipoEnum.Hexadecimal:
                    GuardarValorHexadecimal(token.Lexeme);
                    break;
                case TipoEnum.Inteiro:
                    GuardarValorInteiro(token.Lexeme);
                    break;
                case TipoEnum.Literal:
                    GuardarValorLiteral(token.Lexeme);
                    break;
                case TipoEnum.Logico:
                    GuardarValorLogico(token.Id == t_true);
                    break;
                case TipoEnum.Real:
                    GuardarValorReal(token.Lexeme);
                    break;
            }
        }

        private void AdicionarVariavel(TipoEnum tipo, string identificador)
        {
            _tabelaSimbolo.Add(identificador, _tipoVariavel);

            AdicionarLinha($".locals { TipoEnumToString(tipo) } { identificador }");
        }

        private void AtribuirValor(string identificador)
        {
            AdicionarLinha($"stloc { identificador }");
        }

        private void TravarValorVariavel(string identificador)
        {
            AdicionarLinha($"ldloc {identificador}");
        }

        private void ConverterParaReal()
        {
            AdicionarLinha("conv.r8");
        }

        private void ConverterParaInteiro()
        {
            AdicionarLinha("conv.i8");
        }

        private void AdicionarLinha(string linha)
        {
            _codigo.AppendLine(linha);
        }

        private void AcaoSemanticaNaoImplementada()
        {
            ErroSemantico("Ação semântica não implementada");
        }

        private void TipoInvalidoOperacaoRelacional()
        {
            ErroSemantico("tipo incompatível em expressão relacional");
        }

        private TipoEnum TipoIncompativelExpressaoAritmetica()
        {
            ErroSemantico("Tipo incompatível em expressão aritmética");

            return TipoEnum.Erro;
        }

        private void TipoInvalidoOperacaoLogica()
        {
            ErroSemantico("tipo incompatível em expressão lógica");
        }

        private void TipoInvalidoConversaoValor()
        {
            ErroSemantico("tipo incompatível em operação de conversão de valor");
        }

        private void IdentificadorJaDeclarado()
        {
            ErroSemantico("identificador já declarado");
        }

        private void IdentificadorNaoDeclarado()
        {
            ErroSemantico("identificador não declarado");
        }

        private void ErroSemantico(string mensagem)
        {
            throw new SemanticError(mensagem, _linha);
        }
    }
}
