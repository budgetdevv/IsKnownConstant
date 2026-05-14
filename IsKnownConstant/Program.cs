using System.Runtime.CompilerServices;

namespace IsKnownConstant
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(CallerMethod());
        }

        // The constant folding doesn't happen in T0 compilation
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static bool CallerMethod()
        {
            return InlinedMethod(69);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool InlinedMethod<T>(T value) where T: struct
        {
            return IsKnownConstant(@class: null, value);
        }

        private const string
            IS_KNOWN_CONSTANT_METHOD_NAME = "IsKnownConstant",
            RUNTIME_HELPERS_TYPE_NAME = "System.Runtime.CompilerServices.RuntimeHelpers, System.Private.CoreLib";

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