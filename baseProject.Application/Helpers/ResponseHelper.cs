﻿using BaseProject.Domain.Exceptions;
using System.Collections;

namespace BaseProject.Application.Helpers
{
    internal class MResult
    {
        public string Message { get; set; }
        public object Result { get; set; }
    }

    public class ResponseHelper
    {

        internal static MResult Create(string message, object result = null)
        {

            if (result == null)
            {
                result = new { };
            }
            else if (result is IEnumerable)
            {
                throw new InvalidTypeException("A propriedade Result não pode ser uma lista ou array de items");
            }

            return new MResult { Message = message, Result = result };
        }
    }
}
