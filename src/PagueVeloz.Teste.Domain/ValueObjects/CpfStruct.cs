﻿using System;

namespace PagueVeloz.Teste.Domain
{
    public struct CpfStruct
    {
        private readonly string _value;
        public readonly bool EhValido;
        private CpfStruct(string value)
        {
            try
            {


                _value = value;

                if (value == null)
                {
                    EhValido = false;
                    return;
                }

                var posicao = 0;
                var totalDigito1 = 0;
                var totalDigito2 = 0;
                var dv1 = 0;
                var dv2 = 0;

                bool digitosIdenticos = true;
                var ultimoDigito = -1;

                foreach (var c in value)
                {
                    if (char.IsDigit(c))
                    {
                        var digito = c - '0';
                        if (posicao != 0 && ultimoDigito != digito)
                        {
                            digitosIdenticos = false;
                        }

                        ultimoDigito = digito;
                        if (posicao < 9)
                        {
                            totalDigito1 += digito * (10 - posicao);
                            totalDigito2 += digito * (11 - posicao);
                        }
                        else if (posicao == 9)
                        {
                            dv1 = digito;
                        }
                        else if (posicao == 10)
                        {
                            dv2 = digito;
                        }

                        posicao++;
                    }
                }

                if (posicao > 11)
                {
                    EhValido = false;
                    return;
                }

                if (digitosIdenticos)
                {
                    EhValido = false;
                    return;
                }

                var digito1 = totalDigito1 % 11;
                digito1 = digito1 < 2
                    ? 0
                    : 11 - digito1;

                if (dv1 != digito1)
                {
                    EhValido = false;
                    return;
                }

                totalDigito2 += digito1 * 2;
                var digito2 = totalDigito2 % 11;
                digito2 = digito2 < 2
                    ? 0
                    : 11 - digito2;

                EhValido = dv2 == digito2;
                _value = long.Parse(_value).ToString(@"000\.000\.000\-00");
                //106.029.459-17
                var a = 1 + 1;
            }
            catch (Exception)
            {
                EhValido = false;
                _value = "";
            }
        }

        public static implicit operator CpfStruct(string value)
            => new CpfStruct(value);

        public override string ToString() => _value;
    }
}
