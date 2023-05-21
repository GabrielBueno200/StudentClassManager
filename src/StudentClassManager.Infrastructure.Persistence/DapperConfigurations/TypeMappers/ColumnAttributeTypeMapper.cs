using Dapper;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentClassManager.Infrastructure.Persistence.DapperConfigurations.TypeMappers;

public class ColumnAttributeTypeMapper<T> : FallbackTypeMapper
{
    private static readonly SqlMapper.ITypeMap[] CustomTypeMappers = new SqlMapper.ITypeMap[]
    {
        new CustomPropertyTypeMap(typeof(T), (type, columnName) =>
            type.GetProperties().FirstOrDefault(prop => {
                return prop.GetCustomAttributes(false)
                        .OfType<ColumnAttribute>()
                        .Any(attribute => attribute.Name == columnName);
            })
        ),
        new DefaultTypeMap(typeof(T))
    };

    public ColumnAttributeTypeMapper() : base(CustomTypeMappers) { }
}