﻿using System.Linq.Expressions;
using JeBalance.Domain.Contracts;

namespace ParkNGo.Infrastructure.SQLServer.Repositories;

public static class SpecificationExtensions
{
    public static Expression<Func<InfraType, bool>> ToSQLExpression<DomainType, InfraType>(
        this Specification<DomainType> specification)
        where InfraType : DomainType
    {
        var expression = specification.ToExpression();
        var param = Expression.Parameter(typeof(InfraType));
        return Expression.Lambda<Func<InfraType, bool>>(
            expression.Body.Replace(expression.Parameters[0], param),
            param);
    }

    private static Expression Replace(
        this Expression expression,
        Expression searchEx,
        Expression replaceEx)
    {
        return new ReplaceVisitor(searchEx, replaceEx).Visit(expression);
    }

    public static IQueryable<T> Apply<T>(
        this IQueryable<T> query,
        Expression<Func<T, bool>> predicate)
    {
        return query.Where(predicate);
    }

    public static bool IsNullOrDefault<T>(this T value)
    {
        return value == null || EqualityComparer<T>.Default.Equals(value, default);
    }
}

internal class ReplaceVisitor : ExpressionVisitor
{
    private readonly Expression _from, _to;

    public ReplaceVisitor(Expression from, Expression to)
    {
        _from = from;
        _to = to;
    }

    public override Expression Visit(Expression node)
    {
        return node == _from ? _to : base.Visit(node);
    }
}