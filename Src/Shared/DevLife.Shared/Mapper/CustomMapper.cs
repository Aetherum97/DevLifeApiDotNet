
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace DevLife.Shared.Mapper
{
    public static class CustomMapper
    {
        public static TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
        {
            return (TTarget)Map(typeof(TSource), typeof(TTarget), source!);
        }

        private static object Map(Type sourceType, Type targetType, object sourceInstance)
        {
            var targetInstance = Activator.CreateInstance(targetType);
            var sourceProps = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var targetProps = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var targetProp in targetProps)
            {
                if (!targetProp.CanWrite)
                {
                    continue;
                }

                var mapFromAttribute = targetProp.GetCustomAttribute<MapFromAttribute>();
                var sourcePropName = mapFromAttribute?.SourceProperty ?? targetProp.Name;

                var sourceProp = sourceProps.FirstOrDefault(p => p.Name == sourcePropName && p.CanRead);
                if (sourceProp == null)
                {
                    continue;
                }

                var sourceValue = sourceProp.GetValue(sourceInstance);
                if (sourceValue == null)
                {
                    targetProp.SetValue(targetInstance, null);
                    continue;
                }

                var sourcePropType = sourceProp.PropertyType;
                var targetPropType = targetProp.PropertyType;

                if (targetPropType.IsAssignableFrom(sourcePropType))
                {
                    targetProp.SetValue(targetInstance, sourceValue);
                    continue;
                }

                try
                {
                    var convertedValue = Convert.ChangeType(sourceValue, targetPropType);
                    targetProp.SetValue(targetInstance, convertedValue);
                    continue;
                }
                catch { }

                if (typeof(IEnumerable).IsAssignableFrom(targetPropType) && targetPropType.IsGenericType && sourcePropType.IsGenericType)
                {
                    var sourceElementType = sourcePropType.GetGenericArguments().First();
                    var targetElementType = targetPropType.GetGenericArguments().First();

                    var sourceEnumerable = (IEnumerable)sourceValue;
                    var targetListType = typeof(List<>).MakeGenericType(targetElementType);
                    var targetList = (IList?)Activator.CreateInstance(targetListType);

                    foreach (var item in sourceEnumerable)
                    {
                        var mappedItem = Map(sourceElementType, targetElementType, item);
                        targetList!.Add(mappedItem);
                    }

                    targetProp.SetValue(targetInstance, targetList);
                    continue;
                }

                if (!targetPropType.IsPrimitive && !targetPropType.IsEnum && targetPropType != typeof(string))
                {
                    var recursiveObject = Map(sourcePropType, targetPropType, sourceValue);
                    targetProp.SetValue(targetInstance, recursiveObject);
                }

            }

            return targetInstance!;

        }

    }
}