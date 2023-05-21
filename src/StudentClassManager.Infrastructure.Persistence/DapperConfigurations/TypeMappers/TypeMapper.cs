using Dapper;
using StudentClassManager.Domain.Models;

namespace StudentClassManager.Infrastructure.Persistence.DapperConfigurations.TypeMappers;

public static class TypeMapper
{
    public static void Initialize(string @namespace = "StudentClassManager.Domain.Models")
    {
        Func<Type, bool> isValidType = type =>
            type.IsClass && type.Namespace!.StartsWith(@namespace) && !type.ContainsGenericParameters;

        var typesList = typeof(Student).Assembly.GetTypes().Where(isValidType).ToList();

        typesList.ForEach(type =>
        {
            var genericType = typeof(ColumnAttributeTypeMapper<>).MakeGenericType(type);
            var instance = Activator.CreateInstance(genericType);
            SqlMapper.SetTypeMap(type, instance as SqlMapper.ITypeMap);
        });
    }
}
