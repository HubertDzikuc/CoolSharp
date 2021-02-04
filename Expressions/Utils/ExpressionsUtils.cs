using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoolSharp.Expressions
{
    public static class ExpressionsUtils
    {
        public static T GenerateLambdaFromInvoker<T>(object obj, Action<object[]> invoker) where T : Delegate
        {
            var parameters = typeof(T).GetMethod("Invoke").GetParameters().Select(p => Expression.Parameter(p.ParameterType)).ToList();

            return Expression.Lambda<T>(Expression.Call(Expression.Constant(obj), invoker.Method, CreateParameterExpressions(parameters)), parameters).Compile();
        }

        public static Expression CreateParameterExpressions(List<ParameterExpression> parameters)
        {
            return Expression.NewArrayInit(typeof(object), parameters.Select(parameter => Expression.Convert(parameter, typeof(object))));
        }

    }
}