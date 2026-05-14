using System.Runtime.CompilerServices;

namespace IsKnownConstant
{
    internal static class ConstantHelpers
    {
        private const string
            IS_KNOWN_CONSTANT_METHOD_NAME = "IsKnownConstant",
            RUNTIME_HELPERS_TYPE_NAME = "System.Runtime.CompilerServices.RuntimeHelpers, System.Private.CoreLib";

        public static bool IsKnownConstant(string value)
            => IsKnownConstant(@class: null, value);

        public static bool IsKnownConstant(char value)
            => IsKnownConstant(@class: null, value);

        public static bool IsKnownConstant(Type? value)
            => IsKnownConstant(@class: null, value);

        public static bool IsKnownConstant<T>(T value) where T: struct
            => IsKnownConstant(@class: null, value);

        [UnsafeAccessor(kind: UnsafeAccessorKind.StaticMethod, Name = IS_KNOWN_CONSTANT_METHOD_NAME)]
        private static extern bool IsKnownConstant(
            [UnsafeAccessorType(typeName: RUNTIME_HELPERS_TYPE_NAME)]
            object? @class,
            string? value
        );

        [UnsafeAccessor(kind: UnsafeAccessorKind.StaticMethod, Name = IS_KNOWN_CONSTANT_METHOD_NAME)]
        private static extern bool IsKnownConstant(
            [UnsafeAccessorType(typeName: RUNTIME_HELPERS_TYPE_NAME)]
            object? @class,
            char value
        );

        [UnsafeAccessor(kind: UnsafeAccessorKind.StaticMethod, Name = IS_KNOWN_CONSTANT_METHOD_NAME)]
        private static extern bool IsKnownConstant(
            [UnsafeAccessorType(typeName: RUNTIME_HELPERS_TYPE_NAME)]
            object? @class,
            Type? value
        );

        [UnsafeAccessor(kind: UnsafeAccessorKind.StaticMethod, Name = IS_KNOWN_CONSTANT_METHOD_NAME)]
        private static extern bool IsKnownConstant<T>(
            [UnsafeAccessorType(typeName: RUNTIME_HELPERS_TYPE_NAME)]
            object? @class,
            T value
        ) where T: struct;
    }
}