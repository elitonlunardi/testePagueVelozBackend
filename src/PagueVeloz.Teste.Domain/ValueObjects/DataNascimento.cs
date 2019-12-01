﻿using System;
using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain
{
    public class DataNascimento : ValueObject<DataNascimento>
    {
        public readonly bool EhValido = false;
        public DateTime Value { get; private set; }

        private DataNascimento(DateTime value)
        {
            Value = value;

            if (Value == DateTime.MinValue)
            {
                Value = new DateTime(1753,01,02);
            }
            //validar
        }

        public static implicit operator DataNascimento(DateTime data) => new DataNascimento(data);
        protected override bool EqualsCore(DataNascimento other) => Value.Equals(other.Value);

        protected override int GetHashCodeCore()
        {
            return 0;
        }
    }
}