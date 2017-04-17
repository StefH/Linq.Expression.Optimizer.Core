using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Linq.Expression.Optimizer;

namespace Linq.Expression.Optimizer.Tests
{
    public class ExpressionOptimizerTests : IDisposable
    {
		private List<T> ExecuteExpression<T>(System.Linq.Expressions.Expression e)
        {
            return ((IEnumerable)System.Linq.Expressions.Expression.Lambda(e).Compile().DynamicInvoke()).Cast<T>().ToList();
        }

        private Tuple<List<T>, List<T>> TestExpression<T>(IQueryable<T> qry)
        {
            var expressionNormal = qry.Expression;
            var expressionOptimized = ExpressionOptimizer.visit(qry.Expression);

            List<T> itemNormal = ExecuteExpression<T>(expressionNormal);
            List<T> listOptimized = ExecuteExpression<T>(expressionOptimized);

            return new Tuple<List<T>, List<T>>(itemNormal, listOptimized);
        }

        // Expression optimizer generates equal results on 1-2-3-4-5 array
        [Fact]
        public void ExpressionOptimizer1()
        {
            var query = new [] { 1, 2, 3, 4, 5 }.AsQueryable();
            var result = TestExpression(query.Select(i => !!!(i > 3)));
  
            Assert.Equal(result.Item1, result.Item2);
        }

        public void Dispose()
        {
        }
    }
}