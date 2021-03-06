﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TableIO.PropertyMappers
{
    public enum AutoIndexPropertyTargetType
    {
        All,
        CanRead,
        CanWrite
    }

    public class AutoIndexPropertyMapper : IPropertyMapper
    {
        private readonly AutoIndexPropertyTargetType _targetType;

        public AutoIndexPropertyMapper(AutoIndexPropertyTargetType targetType = AutoIndexPropertyTargetType.All)
        {
            _targetType = targetType;
        }

        public PropertyMap[] CreatePropertyMaps(Type type, IList<string> header)
        {
            return type.GetProperties()
                .Where(p => _targetType != AutoIndexPropertyTargetType.CanRead || p.CanRead)
                .Where(p => _targetType != AutoIndexPropertyTargetType.CanWrite || p.CanWrite)
                .Select((p, i) => new PropertyMap
                {
                    ColumnIndex = i, Property = p
                })
                .ToArray();
        }
    }
}
